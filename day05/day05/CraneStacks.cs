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

        public void Move(int from, int to, int nrOfBlocks)
        {
            
        }

        public string RunAllMoves()
        {
            return string.Empty;
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
