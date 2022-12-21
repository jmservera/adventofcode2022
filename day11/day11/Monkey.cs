using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day11
{
    public class Monkey
    {
        readonly List<int> startingItems = new();

        public List<int> StartingItems { get => startingItems; }

        public Tuple<string,string,string>? Operation { get; set; }

        public int TestValue { get; private set; }

        public int IfTrue { get; private set; }
        public int IfFalse { get; private set; }


        public Monkey()
        {
            
        }

        public int Operate()
        {
            return 0;
        }

        public int Test()
        {
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
                    var monkey = new Monkey();
                    monkeys.Add(monkey);
                }
                else
                {
                    var monkey = monkeys.Last();
                    if (input[inputIndex].StartsWith("  Starting items"))
                    {
                        string[] items = input[inputIndex].Split(':');
                        string[] itemValues = items[1].Split(',');
                        monkey.StartingItems.AddRange(itemValues.Select(item=> int.Parse(item)));
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
