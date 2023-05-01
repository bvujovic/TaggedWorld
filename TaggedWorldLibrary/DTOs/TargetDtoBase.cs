namespace TaggedWorldLibrary.DTOs
{
    public class TargetDtoBase
    {
        ///// <summary>Naslov dokumenta ili naslov/kratak opis linka/fajla/foldera.</summary>
        //public string Title { get; set; }

        ///// <summary>Tip targeta, tacnije contenta: link/fajl/folder/doc</summary>
        //public string Type { get; set; }

        /// <summary>Adresa linka/fajla/foldera ili tekst dokumenta.</summary>
        public string Content { get; set; }

        /// <summary>Tagovi za pretragu ovog target-a spakovani u string.</summary>
        /// <example>raf, tagged-world, projekat, c#, web-api</example>
        public string StrTags { get; set; }

        public override string ToString()
        {
            return Content;
        }
    }
}
