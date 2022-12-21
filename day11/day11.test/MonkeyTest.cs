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
    }
}
