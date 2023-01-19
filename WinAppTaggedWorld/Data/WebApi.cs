using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace WinAppTaggedWorld.Data
{
    /// <summary>
    /// Komunikacija sa Web API delom sistema.
    /// </summary>
    public static class WebApi
    {
        public static string Token { get; set; }

        /// <summary>Dohvata listu trazenih objekata od WebAPI-a.</summary>
        public async static Task<List<T>?> GetList<T>(ReqEnum reqEnum)
        {
            var json = await GetJson(reqEnum);
            return DeserializeList<T>(json);
        }

        public static List<T>? DeserializeList<T>(string json)
            => Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(json);

        /// <summary>Dohvata trazeni objekat od WebAPI-a.</summary>
        public async static Task<T?> GetObject<T>(ReqEnum reqEnum, string param = null)
        {
            var json = await GetJson(reqEnum, param);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>Dohvata trazeni objekat od WebAPI-a.</summary>
        public async static Task<T?> GetObject<T>(string url)
        {
            var json = await GetJson(url);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>Dohvata (GET) JSON podatke od WebAPI-a.</summary>
        /// <see cref="https://stackoverflow.com/questions/14627399/setting-authorization-header-of-httpclient"/>
        public static async Task<string> GetJson(string url)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            return await client.GetStringAsync(url);
        }

        /// <summary>Dohvata (GET) JSON podatke od WebAPI-a.</summary>
        /// <see cref="https://stackoverflow.com/questions/14627399/setting-authorization-header-of-httpclient"/>
        public static async Task<string> GetJson(ReqEnum reqEnum, string param = null)
        {
            return await GetJson(UrlForReq(reqEnum, param));
        }

        /// <summary>Dohvata (POST) JSON podatke od WebAPI-a.</summary>
        public static async Task<string> PostForJson(ReqEnum reqEnum, string body, string? param = null)
            => await ReqForJson(HttpVerb.Post, reqEnum, body, param);

        /// <summary>Salje DELETE zahtev WebAPI-u.</summary>
        public static async Task Delete(ReqEnum reqEnum, int id)
            => await ReqForJson(HttpVerb.Post, reqEnum, "", id.ToString());

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
                HttpVerb.Put => await client.PutAsync(url, content),
                HttpVerb.Delete => await client.DeleteAsync(url),
                _ => throw new Exception("Unkown verb: " + verb),
            };
            var str = await res.Content.ReadAsStringAsync();
            if (res.IsSuccessStatusCode)
                return str;
            else
                //B throw new Exception($"POST response error: {res.ReasonPhrase}");
                throw new Exception(str);
        }

        /// <summary>Dohvata (POST) trazeni objekat od WebAPI-a.</summary>
        public async static Task<T?> PostForObject<T>(ReqEnum reqEnum, string param = null)
        {
            var json = await PostForJson(reqEnum, param);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>Dohvata (POST) listu trazenih objekata od WebAPI-a.</summary>
        public async static Task<List<T>?> PostForList<T>(ReqEnum reqEnum, string body, string param = null)
        {
            var json = await PostForJson(reqEnum, body, param);
            return DeserializeList<T>(json);
        }

        public enum HttpVerb
        {
            Post,
            Delete,
            Put,
        }

        public enum ReqEnum
        {
            Users_login,
            Users_logout,
            Users_register,
            Users_getJWT,
            Users_update,

            Targets,
            Targets_Update,
            Groups,
        }

        public static string UrlForReq(ReqEnum reqEnum, string? param = null)
        {
            var urlBase = "https://localhost:7299/api/";
            return reqEnum switch
            {
                ReqEnum.Users_login => urlBase + "Users/login",
                ReqEnum.Users_logout => urlBase + "Users/logout",
                ReqEnum.Users_register => urlBase + "Users/register",
                ReqEnum.Users_getJWT => urlBase + "Users/getJWT",
                ReqEnum.Users_update => urlBase + "Users/update",

                ReqEnum.Targets => urlBase + "Targets",
                ReqEnum.Targets_Update => urlBase + "Targets?targetId=" + param,
                ReqEnum.Groups => urlBase + "Groups",

                _ => throw new Exception("Nepostojeci reqEnum: " + reqEnum),
            };
        }
    }
}
