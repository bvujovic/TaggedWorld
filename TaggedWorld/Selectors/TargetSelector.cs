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
            TagsChanged?.Invoke(this, data.AllTargets.OrderBy(it => it.TagPoints));
        }

        /// <summary>Lista target-a je uredjena po nekim kriterijumima i moze se prikazati.</summary>
        public event EventHandler<IEnumerable<Target>> TagsChanged;
    }
}
