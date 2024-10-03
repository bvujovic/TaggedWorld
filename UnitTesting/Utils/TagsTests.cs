using TaggedWorldLibrary.Utils;

namespace UnitTestingLibrary.Utils
{
    public class TagsTests
    {
        [Theory]
        [InlineData($"{Tags.TypeFile}", Tags.TypeFile)]
        [InlineData($"{Tags.TypeFile}, a", Tags.TypeFile, "a")]
        [InlineData("link, a, b", "link", "a", "b")]
        [InlineData("link,a,b", "link", "a", "b")]
        [InlineData(" link,   a,  b", "link", "a", "b")]
        [InlineData(" link,   , ", "link")]
        /// <summary>ParseTags treba da vrati zadati niz tagova na osnovu zadatog stringa.</summary>
        public void ParseTags(string strTags, params string[] expTags)
        {
            var actTags = Tags.ParseTags(strTags);
            Assert.Equal(expTags, actTags);
        }
    }
}
