using System;
using WinAppTaggedWorld.Classes;

namespace WinAppUnitTests.Classes
{
    public class UtilsTests
    {
        [Theory]
        [InlineData("asdf", "s")]
        [InlineData("asdf", "S")]
        [InlineData("asdf", "as")]
        [InlineData("asdf", "DF")]
        /// <summary>StrContains vraca true - drugi parametar (string) se sadrzi u prvom.</summary>
        public void StrContains_True(string haystack, string needle)
        {
            var res = Utils.StrContains(haystack, needle);
            Assert.True(res);
        }

        [Theory]
        [InlineData("asdf", "g")]
        [InlineData("s", "asdf")]
        [InlineData("asdf", "sf")]
        /// <summary>StrContains vraca true - drugi parametar (string) se ne sadrzi u prvom.</summary>
        public void StrContains_False(string haystack, string needle)
        {
            var res = Utils.StrContains(haystack, needle);
            Assert.False(res);
        }

        [Theory]
        [InlineData("asdf", "s", "r")]
        [InlineData("asdf", "r", "s")]
        [InlineData("asdf", "sd", "s")]
        [InlineData("asdf", "ad", "S")]
        [InlineData("asdf", "q", "DF", "w")]
        /// <summary>StrContains(haystack,needles) vraca true</summary>
        public void StrContainsNeedles_True(string haystack, params string[] needles)
        {
            var res = Utils.StrContains(haystack, needles);
            Assert.True(res);
        }

        [Theory]
        [InlineData("asdf", "r", "sa")]
        [InlineData("as df", "sd", "H")]
        [InlineData("as df", "q", "db", "w")]
        /// <summary>StrContains(haystack,needles) vraca false</summary>
        public void StrContainsNeedles_False(string haystack, params string[] needles)
        {
            var res = Utils.StrContains(haystack, needles);
            Assert.False(res);
        }

        [Theory]
        [InlineData("file,zvuk,shum,buka,voda,priroda,ChatGPT,spisak,YouTube", "file", true)]
        [InlineData("file,zvuk,shum,buka,voda,priroda,ChatGPT,spisak,YouTube", "chatgpt", true)]
        [InlineData("file,zvuk,shum,buka,voda,priroda,ChatGPT,spisak,YouTube", "YT", false)]
        [InlineData("file,zvuk,shum,buka,voda,priroda,ChatGPT,spisak,YouTube", "as,dada,eee", false)]
        [InlineData("link,github,MD,file format,sintaksa", "Sintaksa", true)]
        [InlineData("link,github,MD,file format,sintaksa", "md,file", true)]
        [InlineData("link,github,MD,file format,sintaksa", "file,md,format", true)]
        [InlineData("link,github,MD,file format,sintaksa", "file,gh,format", false)]
        [InlineData("link,charge battery,baterije,battery charging,elektronika,Li-Ion,arduino,TP4056,otpornik", "baterije", true)]
        [InlineData("link,charge battery,baterije,battery charging,elektronika,Li-Ion,arduino,TP4056,otpornik", "li-ion", true)]
        [InlineData("link,charge battery,baterije,battery charging,elektronika,Li-Ion,arduino,TP4056,otpornik", "tp40", false)]
        [InlineData("link,charge battery,baterije,battery charging,elektronika,Li-Ion,arduino,TP4056,otpornik", "baterija", false)]
        /// <summary>StrFind(haystacks,needles) vraca true</summary>
        public void StrFind(string strHaystacks, string strNeedles, bool expected)
        {
            var haystacks = strHaystacks.Split(',');
            var needles = strNeedles.Split(',');
            var actual = Utils.StrFind(haystacks, needles);
            Assert.Equal(expected, actual);
        }
    }
}
