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

        /// <summary>Naziv taga - string.</summary>
        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException(nameof(value));
                name = value.Trim();
            }
        }
        private string name = string.Empty;

        public const string TypeLink = "link";
        public const string TypeFile = "file";
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
            var that = obj as Tag;
            if (that == null) return false;
            return this.Name == that.Name;
        }

        public override int GetHashCode()
            => Name.GetHashCode();
    }
}