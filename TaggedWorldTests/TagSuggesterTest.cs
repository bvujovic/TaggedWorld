using System;
using System.Collections.Generic;
using System.Linq;
using TaggedWorld;
using Xunit;

namespace TaggedWorldTests
{
    public class TagSuggesterTest
    {
        [Fact]
        public void Suggest_NoTargets_NoTags()
        {
            var data = new Data();
            var ts = new TagSuggester(data);
            var suggested = ts.Suggest(Array.Empty<string>());
            AssertSuggestedTypeTags(suggested);
        }

        private static void AssertSuggestedTypeTags(IDictionary<int, IEnumerable<string>> suggested)
        {
            Assert.Equal(new int[] { 1 }, suggested.Keys);
            Assert.Equal(Tag.TypeTags, suggested[1]);
        }

        [Fact]
        public void Suggest_NoTargetsTags_TypeTags()
        {
            var data = new Data();
            var ts = new TagSuggester(data);
            var suggested = ts.Suggest(new string[] { "abc", "test" });
            AssertSuggestedTypeTags(suggested);
        }

        [Fact]
        public void Suggest_1TargetNoTags_TypeTags()
        {
            var data = new Data();
            data.AddTarget(new Target("www.sososvetisava.edu.rs"
                , "link", "skola", "umka"));
            var ts = new TagSuggester(data);
            var suggested = ts.Suggest(Array.Empty<string>());
            AssertSuggestedTypeTags(suggested);
        }

        [Fact]
        public void C()
        {
            var data = new Data();
            data.AddTarget(new Target("www.sososvetisava.edu.rs"
                , "link", "skola", "umka"));
            var ts = new TagSuggester(data);
            var suggested = ts.Suggest(new string[] { "bzvz" });
            AssertSuggestedTypeTags(suggested);
        }

        [Fact]
        public void D()
        {
            var data = new Data();
            data.AddTarget(new Target("www.sososvetisava.edu.rs"
                , "link", "skola", "umka"));
            var ts = new TagSuggester(data);
            var suggested = ts.Suggest(new string[] { "skola" });
            Assert.Equal(new int[] { 1 }, suggested.Keys);
            Assert.Equal(new string[] { "link", "umka" }, suggested[1]);
        }

        [Fact]
        public void E()
        {
            var data = new Data();
            data.AddTarget(new Target("www.sososvetisava.edu.rs"
                , "link", "skola", "umka"));
            data.AddTarget(new Target("https://portal.azure.com/#home"
                , "link", "programiranje", "azure", "cloud"));
            var ts = new TagSuggester(data);
            var suggested = ts.Suggest(new string[] { "link" });
            Assert.Equal(new int[] { 1 }, suggested.Keys);
            Assert.Equal(new string[] { "skola", "umka", "programiranje", "azure", "cloud" }, suggested[1]);
        }

        [Fact]
        public void F()
        {
            var data = new Data();
            data.AddTarget(new Target("www.sososvetisava.edu.rs"
                , "link", "skola", "cloud"));
            data.AddTarget(new Target("https://portal.azure.com/#home"
                , "link", "azure", "cloud"));
            var ts = new TagSuggester(data);
            var suggested = ts.Suggest(new string[] { "link" });
            Assert.Equal(new int[] { 1, 2 }, suggested.Keys);
            Assert.Equal(new string[] { "cloud" }, suggested[2]);
            Assert.Equal(new string[] { "skola", "azure" }, suggested[1]);
        }
    }
}
