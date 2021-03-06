using System;
using System.Collections.Generic;
using System.Linq;

namespace TaggedWorld.Selectors
{
    /// <summary>
    /// Filtriranje i sortiranje podataka o target-ima
    /// na osnovu zadatih tagova i drugih parametara.
    /// </summary>
    public class TargetSelector
    {
        private readonly Data data;

        public TargetSelector(Data data)
        {
            this.data = data;
        }

        /// <summary>Na osnovu datih tagova, dobija se uredjena lista target-a.</summary>
        public void SetTags(IEnumerable<Tag> tags)
        {
            if (tags == null)
                return;
            if (!tags.Any())
            {
                TagsChanged?.Invoke(this, data.AllTargets);
                return;
            }
            foreach (var target in data.AllTargets)
                target.CalcTagPoints(tags);

            //// ako ima targeta sa vise od 0 poena - prikazi samo takve targete
            //var foundTargets = data.AllTargets.Any(it => it.TagPoints > 0);
            //var res = !foundTargets ? data.AllTargets.OrderBy(it => it.TagPoints) :
            //    data.AllTargets.Where(it => it.TagPoints > 0).OrderBy(it => it.TagPoints);

            var maxPoints = data.AllTargets.Max(it => it.TagPoints);
            var res = data.AllTargets.Where(it => it.TagPoints == maxPoints).OrderBy(it => it.TagPoints);

            TagsChanged?.Invoke(this, res);
        }

        /// <summary>Lista target-a je uredjena po nekim kriterijumima i moze se prikazati.</summary>
        public event EventHandler<IEnumerable<Target>> TagsChanged = default!;
    }
}
