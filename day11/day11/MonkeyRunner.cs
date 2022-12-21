using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day11
{
    public static class MonkeyRunner
    {
        public static void RunCycles(List<Monkey> monkeys, int turns, bool worried=false)
        {
            if (worried)
            {
                foreach (var monkey in monkeys)
                {
                    monkey.WorryDivider = 1;
                }
            }
            
            for (int i = 0; i < turns; i++)
            {
                if (i % 1000 == 0)
                    Console.WriteLine($"Starting round {i}. {DateTime.Now}");
                foreach (var monkey in monkeys)
                {
                    monkey.RunTurn();
                }
            }
        }
    }
}
