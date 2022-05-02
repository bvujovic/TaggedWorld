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

        //HACK https://stackoverflow.com/questions/60701187/avoid-cs8618-warning-when-initializing-mutable-non-nullable-property-with-argume
        private List<Tag> tags = default!;
        public List<Tag> Tags
        {
            get => tags;
            set
            {
                // premestanje tip taga na prvo mesto
                if (value != null && value.Count > 1)
                {
                    var tt = GetTypeTag();
                    if (tt != null)
                    {
                        tags.Remove(tt);
                        tags.Insert(0, tt);
                    }
                }
                if (value != null)
                    tags = value;
            }
        }

        public string Address { get; set; } = string.Empty;

        //TODO datumi: kreiranja, koriscenja (poslednje ili sva koriscenja?)

        public Target(string address, List<Tag> tags)
        {
            Address = address;
            Tags = tags;
        }

        public Target(string address, params string[] tagNames)
        {
            Address = address;
            Tags = new List<Tag>();
            foreach (var tagName in tagNames)
                //B Tags.Add(new Tag(tag));
                AddTag(tagName);
        }

        public void AddTag(Tag tag)
            => AddTag(tag.Name);

        public void AddTag(string tagName)
        {
            if (string.IsNullOrEmpty(tagName))
                throw new ArgumentNullException(nameof(tagName), "Tag cannot be empty.");
            if (Tag.IsTypeTag(tagName) && GetTypeTag() != null)
                throw new ArgumentException("Target already has type tag.", nameof(tagName));

            var tag = new Tag(tagName);
            if (Tag.IsTypeTag(tagName))
                Tags.Insert(0, tag);
            else
                Tags.Add(tag);
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
                if (tags.Contains(tag))
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
            if (obj is not Target that) return false;
            if (ReferenceEquals(this, that)) return true;
            return this.Address.Equals(that.Address);
        }

        public override int GetHashCode()
            => Address.GetHashCode();
    }
}
