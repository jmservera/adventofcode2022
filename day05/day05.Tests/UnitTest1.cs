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

        [Fact]
        public void TestParseMoves()
        {
            var moves = CraneStacks.ParseMoves(path);
            Assert.Equal(4, moves.Count());
            Assert.Equal((1, 2, 1), moves[0]);
            Assert.Equal((3, 1, 3), moves[1]);
            Assert.Equal((2, 2, 1), moves[2]);
            Assert.Equal((1, 1, 2), moves[3]);
        }
    }
}