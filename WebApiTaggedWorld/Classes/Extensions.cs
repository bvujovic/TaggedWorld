using System.Security.Claims;

namespace WebApiTaggedWorld.Classes
{
    /// <summary>
    /// Razne C# extension metode.
    /// </summary>
    public static class Extensions
    {
        /// <summary></summary>
        public static string GetString(this ClaimsIdentity ci, string claimType)
        {
            var claim = ci.Claims.First(it => it.Type == claimType);
            return claim.Value;
        }

        /// <summary>Vraca Id (int) iz Claims kolekcije ClaimsIdentity objekta.</summary>
        public static int GetId(this ClaimsIdentity ci)
            => int.Parse(GetString(ci, ClaimType.Id));
    }
}
