namespace day11.test
{
    public class UnitTest1
    {
        [Fact]
        public void TestParse()
        {
            var monkeys=Monkey.Parse("./data/test.txt");
            Assert.Equal(4, monkeys.Count);

            Assert.Equal(2, monkeys[0].StartingItems.Count);        
            Assert.Equal(79, monkeys[0].StartingItems[0]);
            Assert.Equal(98, monkeys[0].StartingItems[1]);
            Assert.Equal(new Tuple<string, string, string>("old", "*", "19"), monkeys[0].Operation);
            Assert.Equal(23, monkeys[0].TestValue);
            Assert.Equal(2, monkeys[0].IfTrue);
            Assert.Equal(3, monkeys[0].IfFalse);

            Assert.Equal(74, monkeys[3].StartingItems[0]);
            Assert.Equal(new Tuple<string, string, string>("old", "+", "3"), monkeys[3].Operation);
            Assert.Equal(17, monkeys[3].TestValue);
            Assert.Equal(0, monkeys[3].IfTrue);
            Assert.Equal(1, monkeys[3].IfFalse);

        }
    }
}