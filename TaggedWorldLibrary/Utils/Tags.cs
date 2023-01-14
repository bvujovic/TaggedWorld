using System;

namespace TaggedWorldLibrary.Utils
{
    /// <summary>
    /// Tag/oznaka/labela: Reč ili fraza preko koje se tagovani objekat pronalazi.
    /// </summary>
    public static class Tags
    {
        public static IEnumerable<string> ParseText(string str)
        {
            var tags = new List<string>();
            foreach (var tag in str.Split(',', StringSplitOptions.RemoveEmptyEntries))
                if (tag.Trim().Length > 0)
                    tags.Add(tag);
            return tags;
        }

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
    }
}
