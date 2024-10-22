using System;
using TaggedWorldLibrary.Model;
using TaggedWorldLibrary.Utils;
using WinAppTaggedWorld.Data;

//[assembly: CollectionBehavior(DisableTestParallelization = true)]

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
        /// <summary>SuggestForTarget treba da vrati expHits i strSuggested za date tagove (tags).</summary>
        public void SuggestForTarget(int expHits, string strSuggested, params string[] tags)
        {
            var expSuggested = strSuggested.Split(',');
            var t = new Target("t", "folder", "jedan", "dva", "tri");
            var actual = TagSuggester.SuggestForTarget(t, tags);
            Assert.Equal(expHits, actual.Item1);
            Assert.Equal(expSuggested, actual.Item2);
        }

        [Theory]
        [MemberData(nameof(SuggestForTargetData))]
        public void SuggestForTarget2(string[] tags, int expHitsPoints, string[] expSuggested)
        {
            var t = new Target("t", "folder", "jedan", "dva", "tri");
            var actual = TagSuggester.SuggestForTarget(t, tags);
            Assert.Equal(expHitsPoints, actual.Item1);
            Assert.Equal(expSuggested, actual.Item2);
        }

        public static IEnumerable<object[]> SuggestForTargetData =>
            new List<object[]>
            {
                new object[] { new string[] { "x" }, 0, new string[] { "folder", "jedan", "dva", "tri" } },
                new object[] { new string[] { "JEDAN" }, 0, new string[] { "folder","jedan","dva","tri" } },
                new object[] { new string[] { "folder" }, 1, new string[] { "jedan","dva","tri" } },
                new object[] { new string[] { "jedan" }, 1, new string[] { "folder","dva","tri" } },
                new object[] { new string[] { "jedan", "folder" }, 4, new string[] { "dva", "tri" } },
                new object[] { new string[] { "jedan", "tri" }, 4, new string[] { "folder", "dva" } },
                new object[] { new string[] { "folder" }, 1, new string[] { "jedan", "dva", "tri" } },
                new object[] { new string[] { "jedan" }, 1, new string[] { "folder", "dva", "tri" } },
                new object[] { new string[] { "jedan", "folder" }, 4, new string[] { "dva","tri" } },
            };

        [Fact]
        /// <summary>Suggest metoda treba da vrati samo tip-tagove (link/file/folder) za novi (nepostojeci) tag.</summary>
        public void Suggest_NoTargets()
        {
            var data = LocalData.GetInstance();
            var tagSuggester = new TagSuggester(data);
            var suggested = tagSuggester.Suggest(new string[] { "x" });
            Assert.Single(suggested);
            Assert.Equal(Tags.TypeTags, suggested.First().Value);
            data.Clear();
        }

        [Fact]
        /// <summary>Suggest metoda treba da vrati samo tip-tagove (link/file/folder) ... </summary>
        public void Suggest_NoEnteredTags()
        {
            var data = LocalData.GetInstance();
            using (var sr = new StreamReader("_Data/Data/TagSuggesterTests/targets.txt"))
            {
                while (!sr.EndOfStream)
                {
                    var str = sr.ReadLine();
                    var t = Target.FromString(str);
                    data.AddTarget(t);
                }
            }
            var tagSuggester = new TagSuggester(data);
            var suggested = tagSuggester.Suggest(Array.Empty<string>());
            Assert.Single(suggested);
            Assert.Equal(Tags.TypeTags, suggested.First().Value);
            data.Clear();
        }

        public class SuggestTestData : TheoryData<string[], int, string[]>
        {
            public SuggestTestData()
            {
                // 1 tag, nema pogodaka
                Add(new string[] { "x" }, 1, Tags.TypeTags);
                // 1 target sadrzi ovaj tag
                Add(new string[] { "projekat" }, 1, new string[] { "link", "tagged world", "visual studio" });
                // 2 targeta sadrze ovaj tag
                Add(new string[] { "link" }, 1, new string[] { "tagged world", "projekat", "visual studio", "sajt", "ordinacija", "Medica Tim" });
                // 2 taga, 0 pogodaka
                Add(new string[] { "x", "y" }, 1, Tags.TypeTags );
                // 2 taga, 1 target ima 2 pogotka, drugi ima 1 pogodak
                Add(new string[] { "link", "ordinacija" }, 4, new string[] { "sajt", "Medica Tim" });
                // 2 taga, 1 target ima 2 pogotka, drugi nema pogodaka
                Add(new string[] { "tagged world", "visual studio" }, 4, new string[] { "link", "projekat" });
            }
        }

        [Theory]
        [ClassData(typeof(SuggestTestData))]
        public void Suggest_Tests(string[] enteredTags, int expHitsPoints, string[] expSuggested)
        {
            var data = LocalData.GetInstance();
            data.AddTarget(Target.FromString("https://github.com/bvujovic/TaggedWorld/, link, tagged world, projekat, visual studio"));
            data.AddTarget(Target.FromString("https://www.medicatim.rs/, link, sajt, ordinacija, Medica Tim"));
            var tagSuggester = new TagSuggester(data);
            var suggested = tagSuggester.Suggest(enteredTags);
            Assert.True(suggested.Any());
            var firstLevelTags = suggested.FirstOrDefault();
            Assert.Equal(expHitsPoints, firstLevelTags.Key);
            Assert.Equal(expSuggested, firstLevelTags.Value);
            data.Clear();
        }
    }
}
