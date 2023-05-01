using System;
using System.ComponentModel.DataAnnotations;

namespace TaggedWorldLibrary.Model
{
    /// <summary>
    /// Grupa korisnika.
    /// </summary>
    public class Group
    {
        [Key]
        public int GroupId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        /// <summary>Tagovi za pretragu grupa spakovani u string.</summary>
        public string StrTags { get; set; }

        public DateTime Created { get; set; }

        public List<Member>? Members { get; set; }

        public override string ToString()
            => Name;
    }
}
