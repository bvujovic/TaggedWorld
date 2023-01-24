using System;
using System.Collections.Generic;
using System.Linq;
using TaggedWorldLibrary.Model;

namespace WinAppTaggedWorld.Data.Selectors
{
    /// <summary>
    /// Filtriranje i sortiranje podataka o target-ima
    /// na osnovu zadatih tagova i drugih parametara.
    /// </summary>
    public class TargetSelector
    {
        private readonly LocalData data;

        public TargetSelector(LocalData data)
        {
            this.data = data;
        }

        /// <summary>Na osnovu datih tagova, dobija se uredjena lista target-a.</summary>
        public void SetTags(IEnumerable<string> tags)
        {
            Targets = data.Targets;
            if (tags == null)
                return;
            if (!tags.Any() || !Targets.Any())
            {
                Targets = data.Targets;
                TagsChanged?.Invoke(this, EventArgs.Empty);
                return;
            }
            foreach (var target in data.Targets)
                target.CalcTagPoints(tags);

            //// ako ima targeta sa vise od 0 poena - prikazi samo takve targete
            //var foundTargets = data.AllTargets.Any(it => it.TagPoints > 0);
            //var res = !foundTargets ? data.AllTargets.OrderBy(it => it.TagPoints) :
            //    data.AllTargets.Where(it => it.TagPoints > 0).OrderBy(it => it.TagPoints);

            var maxPoints = data.Targets.Max(it => it.TagPoints);
            Targets = data.Targets.Where(it => it.TagPoints == maxPoints).OrderBy(it => it.TagPoints);

            TagsChanged?.Invoke(this, EventArgs.Empty);
        }

        public IEnumerable<Target> Targets { get; set; } = Enumerable.Empty<Target>();

        /// <summary>Lista target-a je uredjena po nekim kriterijumima i moze se prikazati.</summary>
        public event EventHandler TagsChanged = default!;
    }
}
