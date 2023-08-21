using System;
using System.Net;
using System.Net.Http.Headers;

namespace WinAppTaggedWorld.Data
{
    /// <summary>
    /// Komunikacija sa Web API delom sistema.
    /// </summary>
    public static class WebApi
    {
        public static string? Token { get; set; }

        public static bool IsUserLoggedIn => Token != null;

        /// <summary>Dohvata listu trazenih objekata od WebAPI-a.</summary>
        public async static Task<List<T>?> GetList<T>(ReqEnum reqEnum, string? param = null)
        {
            var json = await GetJson(reqEnum, param);
            return DeserializeList<T>(json);
        }

        public static List<T>? DeserializeList<T>(string json)
            => Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(json);

        /// <summary>Dohvata trazeni objekat od WebAPI-a.</summary>
        public async static Task<T?> GetObject<T>(ReqEnum reqEnum, string? param = null)
        {
            var json = await GetJson(reqEnum, param);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>Dohvata (GET) JSON podatke od WebAPI-a.</summary>
        /// <see cref="https://stackoverflow.com/questions/14627399/setting-authorization-header-of-httpclient"/>
        public static async Task<string> GetJson(string url)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            try
            {
                return await client.GetStringAsync(url);
            }
            catch (HttpRequestException ex)
            {
                if (ex.StatusCode == HttpStatusCode.Unauthorized)
                    Token = await GetJWT();
                return await client.GetStringAsync(url);
            }
        }

        public static async Task<string> GetJWT()
        {
            var baseAddress = new Uri(UrlBase);
            var cookieContainer = new CookieContainer();
            using var handler = new HttpClientHandler() { CookieContainer = cookieContainer };
            using var client = new HttpClient(handler) { BaseAddress = baseAddress };
            var user = LocalData.GetInstance().User;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            var content = new StringContent($"\"{user.Username}\"", System.Text.Encoding.UTF8, "application/json");
            cookieContainer.Add(baseAddress, new Cookie("refreshToken", RefreshToken));
            var result = await client.PostAsync("Users/getJWT", content);
            result.EnsureSuccessStatusCode();
            var str = await result.Content.ReadAsStringAsync();
            return str;
        }

        /// <summary>Dohvata (GET) JSON podatke od WebAPI-a.</summary>
        /// <see cref="https://stackoverflow.com/questions/14627399/setting-authorization-header-of-httpclient"/>
        public static async Task<string> GetJson(ReqEnum reqEnum, string? param = null)
        {
            return await GetJson(UrlForReq(reqEnum, param));
        }

        /// <summary>Dohvata (POST) JSON podatke od WebAPI-a.</summary>
        public static async Task<string> PostForJson(ReqEnum reqEnum, string body, string? param = null)
            => await ReqForJson(HttpVerb.Post, reqEnum, body, param);

        /// <summary>Salje DELETE zahtev WebAPI-u.</summary>
        public static async Task Delete(ReqEnum reqEnum, int id)
            => await ReqForJson(HttpVerb.Delete, reqEnum, "", id.ToString());

        /// <summary>String uz pomoc kojeg se obnavlja JWT.</summary>
        private static string? RefreshToken = null;

        /// <summary>Salje zahtev (POST/PUT/DELETE) WebAPI-u.</summary>
        public static async Task<string> ReqForJson(HttpVerb verb, ReqEnum reqEnum, string body, string? param = null)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

            var url = UrlForReq(reqEnum, param);
            var content = new StringContent(body, System.Text.Encoding.UTF8, "application/json");
            var res = verb switch
            {
                HttpVerb.Post => await client.PostAsync(url, content),
                HttpVerb.Patch => await client.PatchAsync(url, content),
                HttpVerb.Put => await client.PutAsync(url, content),
                HttpVerb.Delete => await client.DeleteAsync(url),
                _ => throw new Exception("Unkown verb: " + verb),
            };
            var str = await res.Content.ReadAsStringAsync();
            // kada se korisnik uloguje, preuzima se Refresh Token
            if (reqEnum == ReqEnum.Users_login)
            {
                var x = res.Headers.FirstOrDefault(it => it.Key == "Set-Cookie");
                var c = x.Value.FirstOrDefault();
                var labelRefToken = "refreshToken=";
                var idxStart = c.IndexOf(labelRefToken) + labelRefToken.Length;
                var len = c.IndexOf(';') - labelRefToken.Length;
                RefreshToken = c.Substring(idxStart, len);
            }

            if (res.IsSuccessStatusCode)
                return str;
            else
                throw new Exception(str);
        }

        ///// <summary>Dohvata (POST) trazeni objekat od WebAPI-a.</summary>
        //public async static Task<T?> PostForObject<T>(ReqEnum reqEnum, string body, string? param = null)
        //{
        //    var json = await PostForJson(reqEnum, body, param);
        //    return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
        //}

        ///// <summary>Dohvata (POST) listu trazenih objekata od WebAPI-a.</summary>
        //public async static Task<List<T>?> PostForList<T>(ReqEnum reqEnum, string body, string? param = null)
        //{
        //    var json = await PostForJson(reqEnum, body, param);
        //    return DeserializeList<T>(json);
        //}

        public enum HttpVerb
        {
            Post,
            Delete,
            Put,
            Patch,
        }

        public enum ReqEnum
        {
            Users_login,
            Users_userDto,
            Users_logout,
            Users_register,
            Users_getJWT,
            Users_update,

            Targets,
            Targets_Id,
            TargetsShared,
            TargetsNotif,
            TargetsAccept,

            Groups_All,
            Groups_My,

            Members,
            MemberJoin,
            MemberLeave,
        }

        private static string UrlBase => "https://localhost:7299/api/";
        // private static string UrlBase => "https://webapitaggedworld.azurewebsites.net/api/";

        public static string UrlForReq(ReqEnum reqEnum, string? param = null)
        {
            //B
            //var urlBase = "https://localhost:7299/api/";
            //var urlBase = "https://webapitaggedworld.azurewebsites.net/api/";
            return reqEnum switch
            {
                ReqEnum.Users_login => UrlBase + "Users/login",
                ReqEnum.Users_userDto => UrlBase + "Users/userDto",
                ReqEnum.Users_logout => UrlBase + "Users/logout",
                ReqEnum.Users_register => UrlBase + "Users/register",
                ReqEnum.Users_getJWT => UrlBase + "Users/getJWT",
                ReqEnum.Users_update => UrlBase + "Users/update",

                ReqEnum.Targets => UrlBase + "Targets",
                ReqEnum.Targets_Id => UrlBase + "Targets?targetId=" + param,
                ReqEnum.TargetsShared => UrlBase + "Sharings",
                ReqEnum.TargetsAccept => UrlBase + "Sharings/accept?targetId=" + param,
                ReqEnum.TargetsNotif => UrlBase + "Targets/notifications",

                ReqEnum.Groups_All => UrlBase + "Groups",
                ReqEnum.Groups_My => UrlBase + "Groups/myGroups",

                ReqEnum.Members => UrlBase + "Members?groupId=" + param,
                ReqEnum.MemberJoin => UrlBase + "Members?" + param,
                ReqEnum.MemberLeave => UrlBase + "Members?" + param,

                _ => throw new Exception("Nepostojeci reqEnum: " + reqEnum),
            };
        }
    }
}
