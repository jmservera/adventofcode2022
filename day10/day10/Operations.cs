using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day10
{
    public class Operations
    {
        // list of commands or operations, parsed (input file)
        public List<(string, int)> Commands = new List<(string, int)>();
        // key = num cycle, value = value of register x
        public Dictionary<int, int> valueInCycles = new Dictionary<int, int>();

        public Operations(string path)
        {
            var file = System.IO.File.ReadAllLines(path);
            parseFile(file);
        }

        public Operations(string[] file)
        {
            parseFile(file);         
        }

        private void parseFile(string[] file)
        {
            //parse
            foreach (var line in file)
            {
                var op = line.Split(' ');
                if (op.Length == 1) //noop
                {
                    Commands.Add((op[0], 0));
                }
                else
                {
                    Commands.Add((op[0], int.Parse(op[1])));
                }
            }
        } 

        public void RunOperations()
        {
            int numCycle = 0;
            int regX = 1;

            foreach (var command in Commands)
            {
                int oldReg = regX;

                if (command.Item1 == "noop")
                {
                    numCycle++;
                    valueInCycles.Add(numCycle, regX);
                }
                else
                {
                    valueInCycles.Add(numCycle+1, regX);
                    regX += command.Item2;
                    numCycle += 2;
                    valueInCycles.Add(numCycle, regX);
                }
            }

        }

        public long GetSignalStrength()
        {
            return (valueInCycles[20 - 1] * 20 +
                    valueInCycles[60 - 1] * 60 +
                    valueInCycles[100 - 1] * 100 +
                    valueInCycles[140 - 1] * 140 +
                    valueInCycles[180 - 1] * 180 +
                    valueInCycles[220 - 1] * 220);

        }

        public void GetImageCRT() 
        {
            string result = String.Empty;
            for (int i = 0; i< valueInCycles.Count; i++) 
            {
                int position = i;
                int cycle = i + 1;
                if (cycle == 1) 
                {
                    if (valueInCycles[1] == position || valueInCycles[1] == position + 1)
                        result += "#";
                    else
                        result += ".";

                }
                else if (valueInCycles[cycle-1] == position || valueInCycles[cycle] == position+1)
                {
                    result += "#";
                }
                else
                {
                    result += ".";
                }
            }
        }
    
    }
    
}
