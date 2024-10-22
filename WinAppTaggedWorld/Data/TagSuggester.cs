using System;
using System.Collections.Generic;
using System.Linq;
using TaggedWorldLibrary.Model;

namespace WinAppTaggedWorld.Data
{
    /// <summary>
    /// Predlaganje tagova korisniku.
    /// </summary>
    public class TagSuggester
    {
        public TagSuggester(LocalData data)
        {
            this.data = data;
        }

        private readonly LocalData data;

        /// <summary>Predlaganje novih tagova na osnovu targeta i njihovih tagova i prethodno unetih tagova.</summary>
        public IDictionary<int, IEnumerable<string>> Suggest(IEnumerable<string> enteredTags)
        {
            var suggested = new Dictionary<int, IEnumerable<string>>();
            if (!data.Targets.Any() || !enteredTags.Any())
                suggested.Add(1, TaggedWorldLibrary.Utils.Tags.TypeTags);
            else
            {
                // recnik svih tagova sa parovima: tag->broj pogodaka u razlicitim targetima
                var allTags = new Dictionary<string, int>();
                foreach (var target in data.Targets)
                {
                    var x = SuggestForTarget(target, enteredTags);
                    foreach (var suggestedTag in x.Item2)
                        if (!allTags.ContainsKey(suggestedTag))
                            allTags.Add(suggestedTag, x.Item1);
                        else
                            allTags[suggestedTag] += x.Item1;
                }

                if (!allTags.Any() || allTags.Max(x => x.Value) == 0)
                    suggested.Add(1, TaggedWorldLibrary.Utils.Tags.TypeTags);
                else
                {
                    var tagCount =
                    from t in allTags
                    group t.Key by t.Value into g
                    orderby g.Key descending
                    select g;
                    foreach (var g in tagCount)
                        suggested.Add(g.Key, g);
                }
            }
            return suggested;
        }

        /// <summary>
        /// Metod vraca kvadrirani broj tagova koji su pronadjeni u datom targetu uz
        /// preostale tagove - one koji nisu pogodjeni/pronadjeni (oni su predlozeni tagovi).
        /// </summary>
        /// <param name="target">Target u okviru kojeg se tagovi pretrazuju.</param>
        /// <param name="enteredTags">Tagovi koji su dati tj. traze u tagovima targeta.</param>
        public static Tuple<int, IEnumerable<string>> SuggestForTarget(Target target, IEnumerable<string> enteredTags)
        {
            var suggested = target.Tags.Where(it => !enteredTags.Contains(it));
            var cntHits = target.Tags.Where(it => enteredTags.Contains(it)).Count();
            cntHits *= cntHits;
            return new Tuple<int, IEnumerable<string>>(cntHits, suggested);
        }
    }
}
