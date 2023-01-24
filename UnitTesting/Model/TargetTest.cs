using TaggedWorldLibrary.Model;
using TaggedWorldLibrary.Utils;

namespace UnitTesting.Model
{
    public class TargetTest
    {
        [Theory]
        [InlineData(1, Tags.TypeFile, Tags.TypeFile)]
        [InlineData(2, Tags.TypeFile, Tags.TypeFile, "b")]
        [InlineData(2, Tags.TypeFile, "b", Tags.TypeFile)]
        [InlineData(3, Tags.TypeFolder, Tags.TypeFolder, "a", "b")]
        [InlineData(3, Tags.TypeLink, "a", Tags.TypeLink, "b")]
        /// <summary>Tip tag bi trebalo da je uvek na prvom mestu.</summary>
        public void SetTags_TypeTagFirst(int cntTags, string firstTag, params string[] tags)
        {
            var t = new Target("aaa", tags);
            Assert.Equal(cntTags, t.Tags.Count);
            Assert.Equal(firstTag, t.Tags[0]);
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
