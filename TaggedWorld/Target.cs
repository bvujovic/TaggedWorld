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
        //HACK https://stackoverflow.com/questions/60701187/avoid-cs8618-warning-when-initializing-mutable-non-nullable-property-with-argume
        private List<Tag> tags = default!;
        public List<Tag> Tags
        {
            get => tags;
            set
            {
                TagsCheck(value);
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
            tags = new List<Tag>();
            foreach (var tagName in tagNames)
                AddTag(tagName);
            TagsCheck(Tags);
        }

        /// <summary>Provera ispravnosti prosledjenih tagova. Lista ne sme biti prazna; mora postojati 1 tip tag.</summary>
        public static void TagsCheck(List<Tag>? tags)
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
                throw new ArgumentException($"Tags must contain one type tag: {string.Join(", ", Tag.TypeTags)}.");
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

        /// <summary>Vraca tip tag ili null ako ga nema u listi.</summary>
        public static Tag? GetTypeTag(List<Tag> tags)
        {
            foreach (var tag in tags)
                if (Tag.IsTypeTag(tag.Name))
                    return tag;
            return null;
        }

        /// <summary>Vraca tip tag ili null ako ga nema u listi Tags.</summary>
        public Tag? GetTypeTag()
            => GetTypeTag(Tags);

        /// <summary>Vraca broj poena tj. poklapanja sa prosledjenim tagovima.</summary>
        public float GetTagPoints(IEnumerable<Tag> tags)
        {
            var count = 0;
            foreach (var tag in Tags)
                if (tags.Contains(tag))
                    count++;
            return count;
        }

        /// <summary>Izracunati broj poena tj. poklapanja sa datim tagovima.</summary>
        /// <see cref="CalcTagPoints"/>
        public float TagPoints { get; private set; }

        /// <summary>Izracunava broj poena tj. poklapanja sa datim tagovima i pamti u TagPoints.</summary>
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
