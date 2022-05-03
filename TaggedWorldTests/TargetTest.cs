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
        [InlineData(1, "x", "x")]
        [InlineData(2, Tag.TypeFile, Tag.TypeFile, "b")]
        [InlineData(3, Tag.TypeFolder, Tag.TypeFolder, "a", "b")]
        [InlineData(3, Tag.TypeLink, "a", Tag.TypeLink, "b")]
        /// <summary>Tip tag bi trebalo da je uvek na prvom mestu.</summary>
        public void SetTags_TypeTagFirst(int cntTags, string firstTag, params string[] tags)
        {
            var t = new Target("aaa", tags);
            Assert.Equal(cntTags, t.Tags.Count);
            Assert.Equal(firstTag, t.Tags[0].Name);
        }

        [Fact]
        public void SetTags_ExceptionWhenNull()
        {
            List<Tag> tags = null;
            Assert.Throws<ArgumentException>(() => new Target("test target", tags));
        }

        [Fact]
        public void SetTags_ExceptionWhenEmpty()
        {
            var tags = new List<Tag>();
            Assert.Throws<ArgumentException>(() => new Target("test target", tags));
        }

        [Theory]
        [InlineData("a")]
        [InlineData("a", "b")]
        public void SetTags_ExceptionWhenNoTypeTags(params string[] tags)
        {
            Assert.Throws<ArgumentException>(() => new Target("test target", tags));
        }
    }
}
