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

        [Fact]
        public void TestMove()
        {
            var cs = new CraneStacks(path);

            cs.Move(1, 2, 1);
            
            Assert.Equal(3, cs.GetStackCopy(0).Count);
            Assert.Equal(2, cs.GetStackCopy(1).Count);
            Assert.Equal(1, cs.GetStackCopy(2).Count);

            Assert.Equal("DCP", cs.GetHead());

        }

        [Fact]
        public void TestAllMoves()
        {
            var cs = new CraneStacks(path);
            var actualResult = cs.RunAllMoves();
            
            Assert.Equal("CMZ", actualResult);

        }

        [Fact]
        public void TestAllMoves9001()
        {
            var cs = new CraneStacks(path);
            var actualResult = cs.RunAllMoves9001();

            Assert.Equal("MCD", actualResult);

        }



        [Fact]
        public void TestCopyStack()
        {
            var s = new Stack<char>();
            s.Push('a');
            s.Push('b');


            var s2 = new Stack<char>(s.Reverse());
            Assert.Equal('b', s.Peek());
            s.Pop();
            Assert.Equal('a', s.Pop());

            Assert.Equal('b', s2.Peek());
            s2.Pop();
            Assert.Equal('a', s2.Pop());
        }
    }
}