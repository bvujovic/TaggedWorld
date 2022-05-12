using System;
using System.Collections.Generic;
using System.Linq;

namespace TaggedWorld
{
    public class Data
    {
        public IEnumerable<Target> AllTargets { get; private set; } = default!;

        public IEnumerable<Tag>? AllTags { get; private set; } = null;

        public Data()
        {
            AllTargets = new HashSet<Target>();
        }

        public void AddTarget(Target target)
        {
            if (AllTargets is HashSet<Target> hs)
                hs.Add(target);
        }

        public void RemoveTarget(Target target)
        {
            if (AllTargets is HashSet<Target> hs && hs.Contains(target))
                hs.Remove(target);
        }

        /// <summary>Ucitavanje targeta iz tekst fajla cija je putanja prosledjena.</summary>
        public void LoadTestTargets(string path)
        {
            (AllTargets as HashSet<Target>)?.Clear();
            using var sr = new StreamReader(path);
            while (!sr.EndOfStream)
            {
                var address = sr.ReadLine();
                // prazni redovi se samo preskacu - mogu biti zgodni za odvajanje sekcija u text fajlu sa mnogo targeta
                if (string.IsNullOrEmpty(address))
                    continue;
                var strTags = sr.ReadLine();
                if (strTags == null)
                    break;
                var tags = strTags.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                var t = new Target(address, tags);
                AddTarget(t);
            }
            sr.Close();
            ExtractAllTags();
        }

        /// <summary>Cuvanje targeta u tekst fajl cija je putanja prosledjena.</summary>
        public void SaveTestTargets(string path)
        {
            if (AllTargets == null)
                return;
            using var sw = new StreamWriter(path);
            foreach (var target in AllTargets)
            {
                sw.WriteLine(target.Address);
                sw.WriteLine(string.Join(", ", target.Tags));
            }
        }

        /// <summary>Pronalazenje svih tagova koji se nalaze u kolekciji AllTargets.</summary>
        private void ExtractAllTags()
        {
            if (AllTargets == null)
                return;
            var tags = new HashSet<Tag>();
            foreach (var target in AllTargets)
                foreach (var tag in target.Tags)
                    tags.Add(tag);
            AllTags = tags;
        }
    }
}
