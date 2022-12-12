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

        public Stack<char> GetStackCopy(int i)
        {
            var stack = new Stack<char>(stacks[i].Reverse());
            return stack;
        }

        public void Move(int nrOfBlocks, int from, int to)
        {
            for(int i = 0; i< nrOfBlocks; i++)
            {
                var block = stacks[from-1].Pop();
                stacks[to-1].Push(block);
            }
        }

        public string GetHead()
        {
            var sb = new StringBuilder();
            foreach (var stack in stacks)
            {
                if (stack.Count > 0)
                {
                    sb.Append(stack.Peek());
                }
                else
                {
                    sb.Append('_');
                }
            }
            return sb.ToString();
        }

        public string RunAllMoves()
        {
            foreach(var move in moves) 
            {
                Move(move.Item1, move.Item2, move.Item3);
            }
            return GetHead();
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
            int counter = 0;
            while (lineIsPartOfStack(file[counter]))
            {
                counter++;
            }

            List<(int, int, int)> moveList = new List<(int, int, int)>();

            for (int i = ++counter; i < file.Length; i++)
            {
                var line = file[i].Split(' ');
                //move 1 from 7 to 4
                moveList.Add(new (int.Parse(line[1]), int.Parse(line[3]), int.Parse(line[5])));
            }

            return moveList;
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

        public object RunAllMoves9001()
        {
            foreach (var move in moves)
            {
                Move9001(move.Item1, move.Item2, move.Item3);
            }
            return GetHead();
        }


        public void Move9001(int nrOfBlocks, int from, int to)
        {
            List<char> temp = new List<char>();

            for (int i = 0; i < nrOfBlocks; i++)
            {
                temp.Add(stacks[from - 1].Pop());                
            }
            temp.Reverse();
            for (int i = 0; i < temp.Count; i++)
            {
                stacks[to - 1].Push(temp[i]);
            }
        }
    }
}
