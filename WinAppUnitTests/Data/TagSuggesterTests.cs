using System;
using TaggedWorldLibrary.Model;
using WinAppTaggedWorld.Classes;

namespace WinAppUnitTests.Data
{
    public class TagSuggesterTests
    {
        [Theory]
        [InlineData(0, "folder,jedan,dva,tri", "x")]
        [InlineData(0, "folder,jedan,dva,tri", "JEDAN")]
        [InlineData(1, "jedan,dva,tri", "folder")]
        [InlineData(1, "folder,dva,tri", "jedan")]
        [InlineData(4, "dva,tri", "jedan", "folder")]
        [InlineData(4, "folder,dva", "jedan", "tri")]
        /// <summary></summary>
        public void SuggestForTarget(int expHits, string strSuggested, params string[] tags)
        {
            var expSuggested = strSuggested.Split(',');
            var t = new Target("t", "folder", "jedan", "dva", "tri");
            var actual = WinAppTaggedWorld.Data.TagSuggester.SuggestForTarget(t, tags);
            Assert.Equal(expHits, actual.Item1);
            Assert.Equal(expSuggested, actual.Item2);
        }
    }
}
