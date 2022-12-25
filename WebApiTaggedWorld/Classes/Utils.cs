using Microsoft.AspNetCore.Mvc;

namespace WebApiTaggedWorld.Classes
{
    /// <summary>
    /// Razne "utility" metode.
    /// </summary>
    public static class Utils
    {
        /// <summary>Detaljan prikaz podataka (poruke) iz izuzetka kroz BadRequest http odgovor.</summary>
        public static BadRequestObjectResult Bad(this ControllerBase ctrl, Exception ex)
        {
            var msg = ex.Message;
            if (ex.InnerException != null)
                msg += Environment.NewLine + ex.InnerException.Message;
            return ctrl.BadRequest(msg);
        }
    }
}
