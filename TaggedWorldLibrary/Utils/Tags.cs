using System;

namespace TaggedWorldLibrary.Utils
{
    /// <summary>
    /// Tag/oznaka/labela: Reč ili fraza preko koje se tagovani objekat pronalazi.
    /// </summary>
    public static class Tags
    {
        public static IEnumerable<string> ParseTags(string str)
        {
            var tags = new List<string>();
            foreach (var tag in str.Split(',', StringSplitOptions.RemoveEmptyEntries))
            {
                var t = tag.Trim();
                if (t.Length > 0)
                    tags.Add(t);
            }
            return tags;
        }

        public static string JoinTags(IEnumerable<string> tags)
            => string.Join(", ", tags);

        public const string TypeLink = "link";
        public const string TypeFile = "file";
        public const string TypeFolder = "folder";
        //TODO dodati i "doc" ili sl. za interna dokumenta/uputstva/podsetnike
        //TODO mozda dodati i razlicite tipove ili podtipove za OneDrive/GoogleDrive folder tj. fajl

        /// <summary>Specijalni (tip) tagovi.</summary>
        public static string[] TypeTags
            => new string[] { TypeLink, TypeFile, TypeFolder };

        public static string TypeTagsStr
            => string.Join('/', TypeTags);

        /// <summary>Da li je prosledjeni tag specijalni (tip) tag.</summary>
        public static bool IsTypeTag(string tag)
            => TypeTags.Contains(tag);

        public static bool ContainsTypeTag(IEnumerable<string> tags)
            => tags.Any(it => IsTypeTag(it));

        public static string? GetTypeTag(IEnumerable<string> tags)
            => tags.FirstOrDefault(it => IsTypeTag(it));
    }
}
