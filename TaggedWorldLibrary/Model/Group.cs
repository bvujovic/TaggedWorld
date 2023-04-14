using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        //B public List<Target> Sharings { get; set; }

        public override string ToString()
            => Name;
    }
}
