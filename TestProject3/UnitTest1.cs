namespace TestProject3
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var res = WinAppTaggedWorld.Classes.Utils.StrContains("asdf", "s");
            Assert.True(res);
        }
    }
}