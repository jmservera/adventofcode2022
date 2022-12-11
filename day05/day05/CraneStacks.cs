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

        public CraneStacks(string input)
        {
            stacks = ParseStacks(input);
            moves = ParseMoves(input);
        }

        public Stack<char> GetStackCopy(int i)
        {
            var stack = new Stack<char>(stacks[i].Reverse());
            return stack;
        }

        public void Move(int nrOfBlocks, int from, int to)
        {
            
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
            return GetHead();
        }

        public static List<Stack<char>> ParseStacks(string input)
        {
            return null;
        }

        public static List<(int, int, int)> ParseMoves(string input)
        {
            return null;
        }


    }
}
