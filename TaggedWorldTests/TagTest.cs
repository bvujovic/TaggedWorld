using System;
using System.Collections.Generic;
using System.Linq;
using TaggedWorld;
using Xunit;

namespace TaggedWorldTests
{
    public class TagTest
    {
        [Theory]
        [InlineData("asd", "asd")]
        [InlineData("   asd ", "asd")]
        [InlineData("  asd abc", "asd-abc")]
        public void ParseText_SingleTag(string s, string tagName)
        {
            var tags = Tag.ParseText(s);
            Assert.Equal(tags.First().Name, tagName);
        }

        [Theory]
        [InlineData("ab,cd", "ab", "cd")]
        [InlineData("ab, cd  ", "ab", "cd")]
        [InlineData(" ab, cd xy", "ab", "cd-xy")]
        [InlineData("ab, cd,", "ab", "cd")]
        [InlineData("ab, cd,  ", "ab", "cd")]
        public void ParseText_MultiTag(string s, params string[] tagNames)
        {
            var tags = Tag.ParseText(s);
            var n = tags.Count();
            Assert.Equal(tagNames.Length, n);
            var i = 0;
            foreach (var tag in tags)
                Assert.Equal(tagNames[i++], tag.Name);
        }

        [Theory]
        [InlineData("x", "x", true)]
        [InlineData("x", "x ", true)]
        [InlineData("x", "y", false)]
        [InlineData("x", "X", false)]
        public void Equals_Tags(string strTag1, string strTag2, bool result)
        {
            var tag1 = new Tag(strTag1);
            var tag2 = new Tag(strTag2);
            Assert.Equal(result, tag1.Equals(tag2));
        }

        [Fact]
        public void Equals_NotATag()
        {
            var tag = new Tag("s");
            var result = tag.Equals(new object());
            Assert.False(result);
        }
    }
}
