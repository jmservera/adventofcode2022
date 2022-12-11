namespace day05.Tests
{
    public class UnitTest1
    {
        static string path = "./data/test.txt";
        [Fact]
        public void TestParseStacks()
        {
            //CraneStacks cs = new CraneStacks(path);
            var stacks = CraneStacks.ParseStacks(path);
            Assert.Equal(3, stacks.Count);
            Assert.Equal(2, stacks[0].Count);
            Assert.Equal(3, stacks[1].Count);
            Assert.Equal(1, stacks[2].Count);
        }
    }
}