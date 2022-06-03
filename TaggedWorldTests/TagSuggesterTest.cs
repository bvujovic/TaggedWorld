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
            Assert.Equal(Tag.TypeTags, suggested[1]);
        }

        [Fact]
        public void Suggest_NoTargetsTags_TypeTags()
        {
            var data = new Data();
            var ts = new TagSuggester(data);
            var suggested = ts.Suggest(new string[] { "abc", "test" });
            Assert.Equal(Tag.TypeTags, suggested[1]);
        }

        [Fact]
        public void Suggest_1TargetNoTags_TypeTags()
        {
            var data = new Data();
            data.AddTarget(new Target("www.sososvetisava.edu.rs"
                , "link", "skola", "umka"));
            var ts = new TagSuggester(data);
            var suggested = ts.Suggest(Array.Empty<string>());
            Assert.Equal(Tag.TypeTags, suggested[1]);
        }

        [Fact]
        public void Suggest_1Target1Tag_TypeTags()
        {
            var data = new Data();
            data.AddTarget(new Target("www.sososvetisava.edu.rs"
                , "link", "skola", "umka"));
            var ts = new TagSuggester(data);
            var suggested = ts.Suggest(new string[] { "bzvz" });
            Assert.Equal(Tag.TypeTags, suggested[1]);
        }

        [Fact]
        public void Suggest_1Target1Tag_Tags()
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
        public void Suggest_2Targets1Tag_Tags1Level()
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
        public void Suggest_2Targets1Tag_Tags2Levels()
        {
            var data = new Data();
            data.AddTarget(new Target("www.sososvetisava.edu.rs", "link", "skola", "cloud"));
            data.AddTarget(new Target("https://portal.azure.com/#home", "link", "azure", "cloud"));
            var ts = new TagSuggester(data);
            var suggested = ts.Suggest(new string[] { "link" });
            Assert.Equal(new int[] { 2, 1 }, suggested.Keys);
            Assert.Equal(new string[] { "cloud" }, suggested[2]);
            Assert.Equal(new string[] { "skola", "azure" }, suggested[1]);
        }

        [Fact]
        public void Suggest_2Targets1Tag_Tags2Levels15()
        {
            var data = new Data();
            data.AddTarget(new Target("www.sososvetisava.edu.rs", "link", "skola", "cloud"));
            data.AddTarget(new Target("https://portal.azure.com/#home", "link", "azure", "cloud"));
            var ts = new TagSuggester(data);
            var suggested = ts.Suggest(new string[] { "link", "skola" });
            Assert.Equal(new int[] { 5, 1 }, suggested.Keys);
            Assert.Equal(new string[] { "cloud" }, suggested[5]);
            Assert.Equal(new string[] { "azure" }, suggested[1]);
        }

        [Theory]
        [MemberData(nameof(SuggestForTargetTestData))]
        public void SuggestForTargetTests(string[] enteredTags, int cntHits, string[] suggestedTags)
        {
            var target = new Target("https://portal.azure.com/#home", "link", "azure", "cloud");
            var suggested = TagSuggester.SuggestForTarget(target, enteredTags);
            Assert.Equal(cntHits, suggested.Item1);
            if (cntHits > 0)
                Assert.Equal(suggestedTags, suggested.Item2);
        }

        public static List<object[]> SuggestForTargetTestData { get; set; } = new List<object[]>()
        {
            new object[] { new[] { "link", "azure" }, 4, new[] { "cloud" } },
            new object[] { new[] { "link" }, 1, new[] { "azure", "cloud" } },
            new object[] { new[] { "abc" }, 0, Array.Empty<string>() },
            new object[] { new[] { "abc", "link" }, 1, new string[] { "azure", "cloud" } },
        };
    }
}
