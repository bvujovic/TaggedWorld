using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TaggedWorldLibrary.Model
{
    /// <summary>
    /// Target tj. resurs koji se pamti i pretražuje: link/fajl/folder/dokument.
    /// </summary>
    public class Target
    {
        [Key]
        public int TargetId { get; set; }

        ///// <summary>Naslov dokumenta ili naslov/kratak opis linka/fajla/foldera.</summary>
        //public string Title { get; set; }

        ///// <summary>Tip targeta, tacnije contenta: link/fajl/folder/doc</summary>
        //public string Type { get; set; }

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
            => $"{Content}";

        /// <summary>Inicijalni target koji se automatski dodaje kao primer za svakog korisnika.</summary>
        public static Target InitTarget(User creator)
            => CreateTarget(
                "https://github.com/bvujovic/TaggedWorld"
                , "raf, tagged-world, project, c#, web-api"
                , new DateTime(2022, 06, 01)
                , creator);

        public static Target CreateTarget(string content, string strTags, DateTime created, User creator)
        {
            return new Target()
            {
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

        //-------------------

        public override bool Equals(object? obj)
        {
            if (obj is not Target that) return false;
            if (ReferenceEquals(this, that)) return true;
            //return this.Content.Equals(that.Content);
            return this.TargetId == that.TargetId;
        }

        public override int GetHashCode()
            => TargetId;

        public Target()
        {
        }

        public Target(string content, List<string> tags)
        {
            Content = content;
            Tags = tags;
        }

        public Target(params string[] tags)
        {
            //Title = title;
            Tags = new List<string>();
            foreach (var tag in tags)
                AddTag(tag);
            TagsCheck(Tags);
        }

        /// <summary>Provera ispravnosti prosledjenih tagova. Lista ne sme biti prazna; mora postojati 1 tip tag.</summary>
        public static void TagsCheck(List<string>? tags)
        {
            if (tags == null || tags.Count == 0)
                throw new ArgumentException("Tags cannot be empty.");
            // premestanje tip taga na prvo mesto
            var tt = GetTypeTag(tags);
            if (tt != null)
            {
                tags.Remove(tt);
                tags.Insert(0, tt);
            }
            else
                throw new ArgumentException($"Tags must contain one type tag: {string.Join(", ", Utils.Tags.TypeTags)}.");
        }

        public void AddTag(string tag)
        {
            if (string.IsNullOrEmpty(tag))
                throw new ArgumentNullException(nameof(tag), "Tag cannot be empty.");
            if (Utils.Tags.IsTypeTag(tag) && GetTypeTag() != null)
                throw new ArgumentException("Target already has type tag.", nameof(tag));

            if (Utils.Tags.IsTypeTag(tag))
                Tags.Insert(0, tag);
                //B Type = tag;
            else
                Tags.Add(tag);
        }

        /// <summary>Vraca tip tag ili null ako ga nema u listi.</summary>
        public static string? GetTypeTag(List<string> tags)
        {
            foreach (var tag in tags)
                if (Utils.Tags.IsTypeTag(tag))
                    return tag;
            return null;
        }

        /// <summary>Vraca tip tag ili null ako ga nema u listi Tags.</summary>
        public string? GetTypeTag()
            => GetTypeTag(Tags);

        /// <summary>Vraca broj poena tj. poklapanja sa prosledjenim tagovima.</summary>
        public float GetTagPoints(IEnumerable<string> tags)
        {
            var count = 0;
            foreach (var tag in Tags)
                if (tags.Contains(tag))
                    count++;
            return count;
        }

        /// <summary>Izracunati broj poena tj. poklapanja sa datim tagovima.</summary>
        /// <see cref="CalcTagPoints"/>
        [NotMapped]
        public float TagPoints { get; private set; }

        /// <summary>Izracunava broj poena tj. poklapanja sa datim tagovima i pamti u TagPoints.</summary>
        public void CalcTagPoints(IEnumerable<string> tags)
            => TagPoints = GetTagPoints(tags);
    }
}