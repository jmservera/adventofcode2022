using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day11.test
{
    public class MonkeyTest
    {
        List<Monkey> monkeys = Monkey.Parse("./data/test.txt");
        
        [Theory]
        [InlineData(0, 79, 1501)]
        [InlineData(1, 54, 60)]
        [InlineData(2, 79, 6241)]
        [InlineData(3, 74, 77)]
        public void TestOperate(int monkeyIndex, int worryLevel, int expected)
        {
            var monkey = monkeys[monkeyIndex];
            var actual = monkey.Operate(worryLevel);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestRunTurn()
        {
            var monkey = monkeys[0];
            monkey.RunTurn();
            Assert.Equal(2, monkey.Counter);
            Assert.Empty(monkey.Items);
            Assert.Equal(3, monkeys[3].Items.Count);
            Assert.Equal(620, monkeys[3].Items.ToArray()[2]);
            Assert.Equal(500, monkeys[3].Items.ToArray()[1]);            
        }

        [Fact]
        public void TestRunTurnWorried()
        {
            var monkey = monkeys[0];
            monkey.WorryDivider = 1;
            monkey.RunTurn();
            Assert.Equal(2, monkey.Counter);
            Assert.Empty(monkey.Items);
            Assert.Equal(3, monkeys[3].Items.Count);
            Assert.Equal(1862, monkeys[3].Items.ToArray()[2]);
            Assert.Equal(1501, monkeys[3].Items.ToArray()[1]);
        }

        [Fact]
        public void TestRun20Cycle()
        {
            MonkeyRunner.RunCycles(monkeys, 20);
            Assert.Equal(101, monkeys[0].Counter);
            Assert.Equal(95, monkeys[1].Counter);
            Assert.Equal(7, monkeys[2].Counter);
            Assert.Equal(105, monkeys[3].Counter);
        }

        [Theory]
        [InlineData(20,99,97,8,103)]
        [InlineData(1000,5204,4792,199,5192)]
        [InlineData(5000, 26075, 23921, 974, 26000)]        
        public void TestRunCycleWorried(int cycles, int a, int b, int c, int d)
        {
            MonkeyRunner.RunCycles(monkeys, cycles, true);
            Assert.Equal(a, monkeys[0].Counter);
            Assert.Equal(b, monkeys[1].Counter);
            Assert.Equal(c, monkeys[2].Counter);
            Assert.Equal(d, monkeys[3].Counter);
        }
    }
}
