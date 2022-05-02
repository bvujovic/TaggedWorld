namespace TaggedWorld
{
    /// <summary>
    /// Tag/oznaka/labela. Reč ili fraza preko koje se tagovani objekat pronalazi.
    /// </summary>
    public class Tag
    {
        public Tag(string name)
        {
            Name = name;
        }

        public static IEnumerable<Tag> ParseText(string str)
        {
            var tags = new List<Tag>();
            foreach (var strTag in str.Split(',', StringSplitOptions.RemoveEmptyEntries))
                if (strTag.Trim().Length > 0)
                    tags.Add(new Tag(strTag));
            return tags;
        }

        /// <summary>Naziv taga - string.</summary>
        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException(nameof(value));
                name = value.Trim().Replace(' ', '-');
            }
        }
        private string name = string.Empty;

        public const string TypeLink = "link";
        public const string TypeFile = "fajl";
        public const string TypeFolder = "folder";

        //TODO dodati i "doc" ili sl. za interna dokumenta/uputstva/podsetnike

        /// <summary>Specijalni (tip) tagovi.</summary>
        public static string[] TypeTags
            => new string[] { TypeLink, TypeFile, TypeFolder };

        /// <summary>Da li je prosledjeni tag specijalni (tip) tag.</summary>
        public static bool IsTypeTag(string tag)
            => TypeTags.Contains(tag);

        public override string ToString()
            => Name;

        public override bool Equals(object? obj)
        {
            if (obj is not Tag that) return false;
            if(ReferenceEquals(this, that)) return true;
            return this.Name == that.Name;
        }

        public override int GetHashCode()
            => Name.GetHashCode();
    }
}