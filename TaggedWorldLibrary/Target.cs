using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaggedWorldLibrary
{
    /// <summary>
    /// Target tj. resurs koji se pamti i pretražuje: link/fajl/folder/dokument.
    /// </summary>
    public class Target
    {
        [Key]
        public int TargetId { get; set; }

        /// <summary>Naslov dokumenta ili naslov/kratak opis linka/fajla/foldera.</summary>
        public string Title { get; set; }

        /// <summary>Tip targeta, tacnije contenta: link/fajl/folder/doc</summary>
        public string Type { get; set; }

        /// <summary>Adresa linka/fajla/foldera ili tekst dokumenta.</summary>
        public string Content { get; set; }

        /// <summary>Tagovi za pretragu ovog target-a spakovani u string.</summary>
        /// <example>raf, tagged-world, projekat, c#, web-api</example>
        public string StrTags { get; set; }
        //TODO validacija datog stringa (tagova)

        [NotMapped]
        public List<string> Tags { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime AccessedDate { get; set; }

        //[NotMapped]
        public User UserOwner { get; set; }
        [ForeignKey(nameof(UserOwner))]
        public int UserOwnerId { get; set; }

        //[NotMapped]
        public User UserModified { get; set; }
        [ForeignKey(nameof(UserModified))]
        public int UserModifiedId { get; set; }

        //[NotMapped]
        public User UserAccessed { get; set; }
        [ForeignKey(nameof(UserAccessed))]
        public int UserAccessedId { get; set; }

        public List<Sharing> Sharings { get; set; }

        public override string ToString()
            => $"{Title}";

        /// <summary>Inicijalni target koji se automatski dodaje kao primer za svakog korisnika.</summary>
        public static Target InitTarget(User creator)
            => CreateTarget("Tagged World GitHub page"
                , TargetTypes.Link
                , "https://github.com/bvujovic/TaggedWorld"
                , "raf, tagged-world, project, c#, web-api"
                , new DateTime(2022, 06, 01), creator);

        public static Target CreateTarget(string title, string type, string content, string strTags
            , DateTime created, User creator)
        {
            return new Target()
            {
                Title = title,
                Type = type,
                Content = content,
                StrTags = strTags,
                CreatedDate = created,
                ModifiedDate = created,
                AccessedDate = created,
                UserOwner = creator,
                UserModified = creator,
                UserAccessed = creator,
            };
        }
    }
}