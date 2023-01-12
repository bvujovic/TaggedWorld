using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaggedWorldLibrary.DTOs;

namespace WinAppTaggedWorld.Data
{
    public class DataGetter
    {
        public static async Task LoginAsync(UserLoginReq req)
        {
            var body = JsonConvert.SerializeObject(req);
            WebApi.Token = await WebApi.PostForJson(WebApi.ReqEnum.Users_login, body);
        }

        public static async Task LogoutAsync()
        {
            await WebApi.PostForJson(WebApi.ReqEnum.Users_logout, "");
        }

        public static async Task RegisterAsync(UserRegistrationReq req)
        {
            var body = JsonConvert.SerializeObject(req);
            await WebApi.PostForJson(WebApi.ReqEnum.Users_register, body);
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
