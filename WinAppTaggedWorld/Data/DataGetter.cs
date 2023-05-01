using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using TaggedWorldLibrary.DTOs;
using TaggedWorldLibrary.Model;
using static WinAppTaggedWorld.Data.WebApi;

namespace WinAppTaggedWorld.Data
{
    public class DataGetter
    {
        public static async Task UserLoginAsync(UserLoginReq req)
        {
            var body = JsonConvert.SerializeObject(req);
            WebApi.Token = await WebApi.PostForJson(WebApi.ReqEnum.Users_login, body);
        }

        public static async Task UserLogoutAsync()
        {
            await WebApi.PostForJson(WebApi.ReqEnum.Users_logout, "");
        }

        public static async Task UserRegisterAsync(UserRegistrationReq req)
        {
            var body = JsonConvert.SerializeObject(req);
            await WebApi.PostForJson(WebApi.ReqEnum.Users_register, body);
        }

        public static async Task<IEnumerable<TargetDto>?> GetTargetsAsync()
        {
            return await WebApi.GetList<TargetDto>(WebApi.ReqEnum.Targets);
        }

        private static string TargetToDtoJson(Target t)
            => JsonConvert.SerializeObject(new TargetDtoBase
            {
                Content = t.Content,
                StrTags = TaggedWorldLibrary.Utils.Tags.JoinTags(t.Tags),
            });

        public static async Task CreateTarget(Target target)
        {
            var id = await WebApi.PostForJson(WebApi.ReqEnum.Targets, TargetToDtoJson(target));
            target.TargetId = int.Parse(id);
        }

        public static async Task DeleteTarget(int targetId)
        {
            await WebApi.Delete(WebApi.ReqEnum.Targets_Id, targetId);
        }

        public static async Task UpdateTarget(Target target)
        {
            await WebApi.ReqForJson(WebApi.HttpVerb.Put, WebApi.ReqEnum.Targets_Id
                , TargetToDtoJson(target), target.TargetId.ToString());
        }

        //TODO videti da li je ovaj metod zaista neophodan
        public static async Task<IEnumerable<SharedTarget>?> GetSharedTargetsAsync()
        {
            return await GetList<SharedTarget>(ReqEnum.TargetsShared);
        }

        public static async Task<IEnumerable<VM.GroupVM>?> GetGroupsAsync()
        {
            return await GetList<VM.GroupVM>(ReqEnum.Groups_All);
        }

        public static async Task<IEnumerable<UserDto>?> GetMembersAsync(int groupId)
        {
            return await GetList<UserDto>(ReqEnum.Members, groupId.ToString());
        }

        public static async Task SendTarget(SharingDto sharingDto)
        {
            var json = JsonConvert.SerializeObject(sharingDto);
            await PostForJson(ReqEnum.TargetsShared, json);
        }

        public static async Task MemberJoin(MemberDto member)
        {
            var json = JsonConvert.SerializeObject(member);
            await PostForJson(ReqEnum.MemberJoin, json);
        }

        public static async Task MemberLeave(int groupId, int userId)
        {
            await ReqForJson(HttpVerb.Delete, ReqEnum.MemberLeave, "", $"groupId={groupId}&userId={userId}");
        }

        public static async Task<IEnumerable<SharedTargetDto>?> GetNotifications()
        {
            return await GetList<SharedTargetDto>(ReqEnum.TargetsNotif);
        }

        //public static async Task GetCenusAsync()
        //{
        //    var json = await WebApi.GetJson(WebApi.ReqEnum.Ustanova_Cenus, WebApi.SV_SAVA_ID);
        //    dynamic obj = Newtonsoft.Json.Linq.JObject.Parse(json);
        //    Poruke.CenusId = (int)obj.id;
        //}

        ///// <summary>Učitava podateke u tabelu SistematizacijaDetalji.</summary>
        //public static async Task GetSistematizacijaDetaljiAsync(Ds.SistematizacijaRow sis)
        //{
        //    var body = $"{{\"skolskaGodina\":{sis.SkolskaGodinaId},\"regUstUstanovaId\":{WebApi.SV_SAVA_ID},\"radnoMestoId\":{sis.RadnoMestoId},\"predmetId\":{sis.PredmetId},\"podnivoPredmetaId\":{sis.PodnivoPredmetaId},\"jezikNastaveId\":{sis.JezikNastaveId}}}";
        //    var json = await WebApi.PostForJson(WebApi.ReqEnum.Zap_SistematizacijaDetalji, body);
        //    dynamic arr = Newtonsoft.Json.Linq.JArray.Parse(json);

        //    foreach (var detalj in sis.GetSistematizacijaDetaljiRows().ToList())
        //        AppData.Ds.SistematizacijaDetalji.RemoveSistematizacijaDetaljiRow(detalj);

        //    foreach (var item in arr)
        //    {
        //        var det = AppData.Ds.SistematizacijaDetalji.NewSistematizacijaDetaljiRow();
        //        det.IdSistematizacije = sis.IdSistematizacije;
        //        det.Zaposleni = item.ime + " " + item.prezime;
        //        det.TipUgovora = item.tipUgovora;
        //        det.ProcenatAngazovanja = item.procenatAngazovanja;
        //        AppData.Ds.SistematizacijaDetalji.AddSistematizacijaDetaljiRow(det);
        //    }
        //}
    }
}
