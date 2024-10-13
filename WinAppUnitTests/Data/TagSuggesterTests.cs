using System;
using TaggedWorldLibrary.Model;
using TaggedWorldLibrary.Utils;
using WinAppTaggedWorld.Data;

[assembly: CollectionBehavior(DisableTestParallelization = true)]

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

        //public class CalculatorTestData : TheoryData<int, int, int>
        //{
        //    public CalculatorTestData()
        //    {
        //        Add(1, 2, 3);
        //        Add(-4, -6, -10);
        //        Add(-2, 2, 0);
        //        Add(int.MinValue, -1, int.MaxValue);
        //    }
        //}

        //[Theory]
        //[ClassData(typeof(CalculatorTestData))]
        //public void CanAdd(int value1, int value2, int expected)
        //{
        //    var calculator = new Calculator();
        //    var result = calculator.Add(value1, value2);
        //    Assert.Equal(expected, result);
        //}

        [Fact]
        /// <summary>Suggest metoda treba da vrati samo tip-tagove (link/file/folder) za novi (nepostojeci) tag.</summary>
        public void Suggest_NoTargets()
        {
            var data = LocalData.GetInstance();
            var tagSuggester = new TagSuggester(data);
            var suggested = tagSuggester.Suggest(new string[] { "x" });
            Assert.Single(suggested);
            Assert.Equal(Tags.TypeTags, suggested.First().Value);
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
        }
    }
}
