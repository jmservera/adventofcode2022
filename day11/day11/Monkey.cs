using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day11
{
    public class Monkey
    {
        
        readonly Queue<IntXLib.IntX> items = new();
        
        public Queue<IntXLib.IntX> Items { get => items; }

        public Tuple<string,string,string>? Operation { get; set; }

        public int TestValue { get; private set; }

        public int IfTrue { get; private set; }
        public int IfFalse { get; private set; }

        IntXLib.IntX counter=0;
        public IntXLib.IntX Counter { get=>counter; }
        public int WorryDivider { get; set; } = 3;

        private List<Monkey> pack;

        public Monkey(List<Monkey> pack)
        {
            this.pack = pack;
        }

        public void RunTurn()
        {
            while(items.Count>0)
            {
                var worryLevel = items.Dequeue();
                worryLevel = Operate(worryLevel);
                if (WorryDivider > 1)
                    worryLevel = worryLevel / WorryDivider;
                if (worryLevel % TestValue == 0)
                {
                    pack[IfTrue].Items.Enqueue(worryLevel);
                }
                else {
                    pack[IfFalse].Items.Enqueue(worryLevel);
                }
                counter++;
            }
        }

        public IntXLib.IntX Operate(IntXLib.IntX worryLevel)
        {
            if (Operation != null)
            {
                var nr = worryLevel;
                if (Operation.Item3 != "old")
                {
                    nr = int.Parse(Operation.Item3);
                }
                switch (Operation.Item2)
                {
                    case "+":
                        return worryLevel + nr;
                    case "*":
                        return worryLevel * nr;
                }
            }
            return 0;
        }

        public static List<Monkey> Parse(string path)
        {
            return Parse(System.IO.File.ReadAllLines(path));
        }

        public static List<Monkey> Parse(string[] input)
        {
            List<Monkey> monkeys = new();

            int inputIndex = 0;
            if (input == null || input.Length == 0)
                return monkeys;
            
            do            
            {
                if (input[inputIndex].StartsWith("Monkey"))
                {
                    var monkey = new Monkey(monkeys);
                    monkeys.Add(monkey);
                }
                else
                {
                    var monkey = monkeys.Last();
                    if (input[inputIndex].StartsWith("  Starting items"))
                    {
                        string[] items = input[inputIndex].Split(':');
                        string[] itemValues = items[1].Split(',');
                        foreach (var item in itemValues)
                        {
                            monkey.items.Enqueue(int.Parse(item));
                        }
                    }
                    else if (input[inputIndex].StartsWith("  Operation"))
                    {
                        string[] items = input[inputIndex].Split(':');
                        string[] itemValues = items[1].Split('=')[1].Trim().Split(' '); ;
                        monkey.Operation = new Tuple<string, string, string>(itemValues[0], itemValues[1], itemValues[2]);
                    }
                    else if (input[inputIndex].StartsWith("  Test"))
                    {
                        var item = input[inputIndex].Split(':')[1].Trim().Split(' ').Last();
                        monkey.TestValue = int.Parse(item);
                    }
                    else if (input[inputIndex].StartsWith("    If true"))
                    {
                        var item = input[inputIndex].Split(':')[1].Trim().Split(' ').Last();
                        monkey.IfTrue = int.Parse(item);
                    }
                    else if (input[inputIndex].StartsWith("    If false"))
                    {
                        var item = input[inputIndex].Split(':')[1].Trim().Split(' ').Last();
                        monkey.IfFalse = int.Parse(item);
                    }
                }

                inputIndex++;
            } while (inputIndex < input.Length);

            return monkeys;
        }
    }
}
