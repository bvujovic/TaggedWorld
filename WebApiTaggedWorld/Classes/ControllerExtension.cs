using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaggedWorldLibrary.Model;
using WebApiTaggedWorld.Data;

namespace WebApiTaggedWorld.Classes
{
    /// <summary>
    /// Extension metode za kontrolere.
    /// </summary>
    public static class ControllerExtension
    {
        /// <summary>Detaljan prikaz podataka (poruke) iz izuzetka kroz BadRequest http odgovor.</summary>
        public static BadRequestObjectResult Bad(this ControllerBase ctrl, Exception ex)
        {
            var msg = ex.Message;
            if (ex.InnerException != null)
                msg += Environment.NewLine + ex.InnerException.Message;
            return ctrl.BadRequest(msg);
        }

        /// <summary>DataContext for the controller.</summary>
        public static DataContext? Db { get; set; }

        /// <summary>Dohvata korisnika koji je ulogovan - onog koji je poslao http zahtev.</summary>
        public static async Task<User> GetUser(this ControllerBase ctrl)
        {
            if (Db == null)
                throw new Exception("Db/DataContext is not set for this controller.");
            var user = await Db.Users.FindAsync(GetUserId(ctrl));
            if (user == null)
                throw new Exception("User not found.");
            return user;
        }

        /// <summary>Dohvata ID korisnika koji je ulogovan - onog koji je poslao http zahtev.</summary>
        public static int GetUserId(this ControllerBase ctrl)
        {
            if (ctrl.HttpContext.User?.Identity is not ClaimsIdentity ident)
                throw new UnauthorizedAccessException("ClaimsIdentity not found.");
            return ident.GetId();
        }
    }
}
