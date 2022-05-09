using System;
using System.Collections.Generic;
using System.Linq;
using TaggedWorld;
using Xunit;

namespace TaggedWorldTests
{
    public class DataTest
    {
        [Fact]
        public void LoadTestTargets_FileNotFoundException()
        {
            var data = new Data();
            Assert.Throws<System.IO.FileNotFoundException>(() => data.LoadTestTargets("xyz"));
        }

        [Fact]
        public void LoadTestTargets_Load2Targets()
        {
            var data = new Data();
            data.LoadTestTargets("TestData/targets.txt");
            Assert.Equal(2, data.AllTargets.Count());
            Assert.Equal(10, data.AllTags.Count());
        }
    }
}
