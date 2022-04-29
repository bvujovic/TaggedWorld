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

        //public Target(Tag typeTag)
        //{
        //    Tags = new List<Tag>() { typeTag };
        //}

        public Target(string address, List<Tag> tags)
        {
            Address = address;
            Tags = tags;
        }

        public Tag? GetTypeTag()
        {
            foreach (var tag in Tags)
                if(Tag.IsTypeTag(tag.Name))
                    return tag;
            return null;
        }
    }
}
