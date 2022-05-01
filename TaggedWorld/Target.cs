using System;
using System.Collections.Generic;
using System.Linq;

namespace TaggedWorld
{
    /// <summary>
    /// Element, Object - objekat koji se taguje i pretražuje.
    /// </summary>
    public class Target
    {
        //TODO tip: veb link, fajl, folder - enum ili kao [obavezni] tag?
        // verovatno bi trebalo ostaviti spec/tip tag kao zasebnu vrednost van Tags

        public List<Tag> Tags { get; set; }

        public string Address { get; set; } = string.Empty;

        //TODO datumi: kreiranja, koriscenja (poslednje ili sva koriscenja?)

        public Target(string address, List<Tag> tags)
        {
            Address = address;
            Tags = tags;
        }

        public Target(string address, params string[] tags)
        {
            Address = address;
            Tags = new List<Tag>();
            foreach (var tag in tags)
                Tags.Add(new Tag(tag));
        }

        public Tag? GetTypeTag()
        {
            foreach (var tag in Tags)
                if (Tag.IsTypeTag(tag.Name))
                    return tag;
            return null;
        }

        /// <summary>Broj poena tj. poklapanja sa prosledjenim tagovima.</summary>
        public float GetTagPoints(IEnumerable<Tag> tags)
        {
            var count = 0;
            foreach (var tag in Tags)
                if(tags.Contains(tag))
                    count++;
            return count;
        }

        public float TagPoints { get; private set; }

        public void CalcTagPoints(IEnumerable<Tag> tags)
            => TagPoints = GetTagPoints(tags);

        public override string ToString()
            => Address;

        public override bool Equals(object? obj)
        {
            var that = obj as Target;
            if (that == null) return false;
            if (ReferenceEquals(this, that)) return true;
            return this.Address.Equals(that.Address);
        }

        public override int GetHashCode()
            => Address.GetHashCode();
    }
}
