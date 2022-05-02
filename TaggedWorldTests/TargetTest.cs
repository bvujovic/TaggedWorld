using System;
using System.Collections.Generic;
using System.Linq;
using TaggedWorld;
using Xunit;

namespace TaggedWorldTests
{
    public class TargetTest
    {
        [Theory]
        [InlineData(2, "a", "a", "b")]
        [InlineData(3, Tag.TypeFolder, Tag.TypeFolder, "a", "b")]
        [InlineData(3, Tag.TypeLink, "a", Tag.TypeLink, "b")]
        /// <summary>Tip tag bi trebalo da je uvek na prvom mestu.</summary>
        public void SetTags_TypeTagFirst(int cntTags, string firstTag, params string[] tags)
        {
            var t = new Target("aaa", tags);
            Assert.Equal(cntTags, t.Tags.Count);
            Assert.Equal(firstTag, t.Tags[0].Name);
        }

        //TODO ispitati izbacivanje Exception-a pri dodavanju tagova
    }
}
