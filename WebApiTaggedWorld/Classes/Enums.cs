namespace WebApiTaggedWorld.Classes
{
    /// Sve enumeracije koriscene u ovom projektu.

    /// <summary>Vrste podataka koji se koriste u HttpContext.User.Identity</summary>
    public static class ClaimType
    {
        /// <summary>Id (int) nekog entiteta.</summary>
        public static string Id => nameof(Id);
        /// <summary>Naziv (string) nekog entiteta.</summary>
        public static string Name => nameof(Name);
    }
}
