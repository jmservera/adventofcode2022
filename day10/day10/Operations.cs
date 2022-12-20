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

            int commandIndex = 0;
            bool operationLoop = false;
            
            do
            {

                var position = (numCycle) % 40;
                if (position == 0)
                {
                    Console.WriteLine();
                }
                if (regX - 1 <= position && position <= regX + 1)
                {
                    Console.Write("#");
                }
                else
                {
                    Console.Write(".");
                }

                numCycle++;


                if (Commands[commandIndex].Item1 == "noop")
                {
                    commandIndex++;
                }
                else
                {
                    if (operationLoop)
                    {
                        regX += Commands[commandIndex].Item2;
                        commandIndex++;
                    }
                    operationLoop = !operationLoop;
                }
                valueInCycles.Add(numCycle, regX);

            } while (commandIndex < Commands.Count);
            Console.WriteLine();
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
            Console.WriteLine(result);
        }
    
    }
    
}
