using System;
using System.Collections.Generic;
using System.Linq;

namespace TaggedWorld
{
    /// <summary>
    /// Predlaganje tagova korisniku.
    /// </summary>
    public class TagSuggester
    {
        public TagSuggester(Data data)
        {
            this.data = data;
        }

        private readonly Data data;

        //B
        ///// <summary>Kolekcija svih tagova na osnovu kojih se vrsi predlaganje.</summary>
        //public IEnumerable<Tag> AllTags { get; set; }

        public IDictionary<int, IEnumerable<string>> Suggest(IEnumerable<string> enteredTags)
        {
            var suggested = new Dictionary<int, IEnumerable<string>>();
            if (!data.AllTargets.Any() || !enteredTags.Any())
                suggested.Add(1, Tag.TypeTags);
            else
            {
                var enteredTag = new Tag(enteredTags.First()); //TODO razraditi za sve enteredTags
                // recnik svih tagova sa parovima: tag->broj pogodaka u razlicitim targetima
                var allTags = new Dictionary<string, int>();
                foreach (var target in data.AllTargets)
                {
                    if (target.Tags.Contains(enteredTag))
                        foreach (var tag in target.Tags.Where(it => !it.Equals(enteredTag)).Select(it => it.Name))
                            if (!allTags.ContainsKey(tag))
                                allTags.Add(tag, 1);
                            else
                                allTags[tag]++;
                }
                if (!allTags.Any())
                    suggested.Add(1, Tag.TypeTags);
                else
                {
                    // skola, 1
                    // link, 2
                    // raf, 1
                    var tagCount =
                    from t in allTags
                    group t.Key by t.Value into g
                    select g;
                    foreach (var g in tagCount)
                        suggested.Add(g.Key, g);
                }
            }
            return suggested;
        }
    }
}
