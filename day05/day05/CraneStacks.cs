using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day05
{
    public class CraneStacks
    {
        List<Stack<char>> stacks;
        List<(int, int, int)> moves;
        
        public CraneStacks(string path)
        {
            stacks = ParseStacks(path);
            moves = ParseMoves(path);
        }

        public void Move(int from, int to, int nrOfBlocks)
        {
            
        }

        public string RunAllMoves()
        {
            return string.Empty;
        }

        public static List<Stack<char>> ParseStacks(string path)
        {
            var stacks = new List<Stack<char>>();

            var file = System.IO.File.ReadAllLines(path);
            bool lineIsAStack = true;

            Stack<string> stackFile = new Stack<string>();
            int counter = 0;
            while (lineIsAStack && counter <= file.Length)
            {
                if (lineIsPartOfStack(file[counter]))
                {
                    stackFile.Push(file[counter]);
                    counter++;
                }
                else
                {
                    lineIsAStack = false;
                }
            }
            // I have all the stacks in "stack"

            // How many stacks do I have?
            string lastLine = stackFile.Pop();

            int numStacks = GetNumStacks(lastLine);

            for (int i = 0; i < numStacks; i++)
            {
                stacks.Add(new Stack<char>());
            }

            while (stackFile.Count > 0)
            { 
                var line = stackFile.Pop();
                for (int i = 0; i < numStacks; i++)
                {
                    var block = line[1 + 4 * i];
                    if(block != ' ') 
                    {
                        stacks[i].Push(block);
                    }
                                        
                }
            }




            return stacks;
        }

        public static List<(int, int, int)> ParseMoves(string path)
        {
            var file = System.IO.File.ReadAllLines(path);

            return null;
        }

        private static int GetNumStacks(string lastLine)
        {
            return int.Parse(lastLine.Split("   ").Last());
        }

        private static bool lineIsPartOfStack(string line)
        {
            if (String.IsNullOrEmpty(line))
            {
                return false;
            }
            else
            {
                return true;

            }
        }


    }
}
