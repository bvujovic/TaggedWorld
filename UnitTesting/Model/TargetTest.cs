using TaggedWorldLibrary.Model;
using TaggedWorldLibrary.Utils;

namespace UnitTestingLibrary.Model
{
    public class TargetTest
    {
        [Theory]
        [InlineData(1, Tags.TypeFile, Tags.TypeFile)]
        [InlineData(2, Tags.TypeFile, Tags.TypeFile, "b")]
        [InlineData(2, Tags.TypeFile, "b", Tags.TypeFile)]
        [InlineData(3, Tags.TypeFolder, Tags.TypeFolder, "a", "b")]
        [InlineData(3, Tags.TypeLink, "a", Tags.TypeLink, "b")]
        /// <summary>Tip tag uvek mora da bude na prvom mestu.</summary>
        public void SetTags_TypeTagFirst(int cntTags, string firstTag, params string[] tags)
        {
            // testiranje konstruktora sa tagovima definisanim kao params string[]
            var t = new Target("content", tags);
            Assert.Equal(cntTags, t.Tags.Count);
            Assert.Equal(firstTag, t.Tags[0]);

            // testiranje konstruktora sa tagovima definisanim kao List<string>
            var tagList = new List<string>(tags);
            var t2 = new Target("content", tagList);
            Assert.Equal(firstTag, t2.Tags[0]);
        }

        [Theory]
        [InlineData("a")]
        [InlineData("a", "b")]
        /// <summary>Konstruktor izbacuje izuzetak ako medju tagovima nema tip-taga.</summary>
        public void SetTags_ExceptionWhenNoTypeTags(params string[] tags)
        {
            Assert.Throws<ArgumentException>(() => new Target("content", tags));
            var tagList = new List<string>(tags);
            Assert.Throws<ArgumentException>(() => new Target("content", tagList));
        }

        [Fact]
        /// <summary>Konstruktor sa parametrima mora sadrzati tagove.</summary>
        public void SetTags_ExceptionWhenNoTags()
        {
            Assert.Throws<ArgumentException>(() => new Target("content"));
        }

        [Fact]
        /// <summary>Equals metod mora da vrati true ako se radi o istoj referenci (objektu).</summary>
        public void Equals_SameReference()
        {
            var t = new Target();
            Assert.True(t.Equals(t));
        }

        [Fact]
        /// <summary>Equals vraca false ako je parametar objekat druge klase.</summary>
        public void Equals_DifferentType()
        {
            var t = new Target();
            var g = new Group();
            Assert.False(t.Equals(g));
        }

        [Fact]
        /// <summary>Equals metod mora da vrati true ako oba Target objekta imaju isti TargetId.</summary>
        public void Equals_SameId()
        {
            var t1 = new Target { TargetId = 1 };
            var t2 = new Target { TargetId = 1 };
            Assert.True(t1.Equals(t2));
        }

        [Fact]
        /// <summary>Equals metod mora da vrati false ako oba Target objekta imaju razlicit TargetId.</summary>
        public void Equals_DifferentIDs()
        {
            var t1 = new Target { TargetId = 1, Content = "c" };
            var t2 = new Target { TargetId = 2, Content = "c" };
            Assert.False(t1.Equals(t2));
        }

        [Theory]
        [InlineData(0, Tags.TypeFile)]
        [InlineData(0, Tags.TypeFile, "A")]
        [InlineData(1, Tags.TypeLink)]
        [InlineData(1, Tags.TypeFile, "a")]
        [InlineData(3, Tags.TypeLink, "b", "a")]
        [InlineData(3, Tags.TypeLink, "a", "b", "c")]
        /// <summary>
        /// GetTagPoints mora da vrati date poene za date tagove
        /// u odnosu na Target sa tagovima "link", "a", "b"
        /// </summary>
        public void GetTagPoints_(int expected, params string[] tags)
        {
            var t = new Target("c", Tags.TypeLink, "a", "b");
            var points = t.GetTagPoints(tags);
            Assert.Equal(expected, points);
        }
    }
}
