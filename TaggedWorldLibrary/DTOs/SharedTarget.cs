using System;

namespace TaggedWorldLibrary.DTOs
{
    /// <summary>
    /// Share-ovani tj. podeljeni target: svi podaci o targetu, grupa i korisnik koji je podelio target.
    /// </summary>
    public class SharedTarget : Model.Target
    {
        /// <summary>Grupa korisnika u okviru koje je target deljen.</summary>
        public string ShareGroupName { get; set; }

        /// <summary>Korisnik koji je podelio target.</summary>
        public string ShareUserName { get; set; }
    }
}
