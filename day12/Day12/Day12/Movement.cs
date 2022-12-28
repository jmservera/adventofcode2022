using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day12
{
    public class Movement
    {
        public char[][] InputMatrix = new char[][] { };

        private static int h = 0;
        private static int w = 0;


        private static int minNumSteps = int.MaxValue;

        private List<char> moves = new List<char>() { 't', 'b', 'l', 'r' };

       // private List<char> listOfMovements  = new List<char>();


        public Movement(char[][] inputMatrix)
        {
            InputMatrix = inputMatrix;
        }

        public Movement(string path)
        {
            var lines = System.IO.File.ReadAllLines(path);
            InputMatrix = lines.Select(x => x.ToCharArray()).ToArray();
          
            w = InputMatrix.GetLength(0); // width
            h = InputMatrix[0].GetLength(0); // height
        }

        public void LookForThePath()
        {
            int numSteps = 0;
            var currentPosition = CoordinatesOf('S');

            foreach (var m in moves)
            {
                ExploreNextMovement(currentPosition, m, numSteps);
            }
        }

        private void ExploreNextMovement(Position current, char move, int numSteps)
        {
            var nextPosition = GetNewPosition(current, move);
            
            // check if the movement is possible:
            // position is not less than 0 (Out of range)
            if (nextPosition.X >= 0 && nextPosition.Y >=0 && nextPosition.X < w && nextPosition.Y <h )
            {
                var currentValue = GetValue(current);
                var nextValue = GetValue(nextPosition);

                if (InputMatrix[nextPosition.X][nextPosition.Y] == 'E')
                {

                    // finish! print whatever!!!
                    if (numSteps < minNumSteps) 
                    {
                        minNumSteps = numSteps;
                    }

                    Console.WriteLine($"Num Steps: {numSteps}");
                }
                // the value of the next cell - value of current cell <= 1
                else if (nextValue - currentValue <= 1)
                {
                    // not visited yet
                    // if (!positions.Contains(nextPosition))
                    //{

                        // we can jump! 
                        //listOfMovements.Add(move);
                        numSteps++;

                        if (numSteps > minNumSteps)
                        {
                            // forget this path, is very long
                            return;
                        }
                        else
                        {
                            foreach (var m in moves)
                            {
                                ExploreNextMovement(nextPosition, m, numSteps);
                            }

                        }
                    //}                

                }

            }
            
            return;          


        }

        private char GetValue(Position position)
        {

            var value = InputMatrix[position.X][position.Y];
            if (value == 'S')
            {
                return 'a';
            }
            if (value == 'E')
            {
                return 'z';
            }

            return value; 
        }

        private Position GetNewPosition(Position current, char move)
        {
            if (move == 't')
            {
                return new Position(current.X - 1, current.Y);
            }
            else if (move == 'b')
            {
                return new Position(current.X + 1, current.Y);

            }
            else if (move == 'r')
            {
                return new Position(current.X, current.Y+1);

            }
            else if (move == 'l')
            {
                return new Position(current.X, current.Y-1);
            }
            else 
            {
                throw new Exception($"WTF?? movement {move} not recognized!! ");
            }
        }

        private Position CoordinatesOf(char value)
        {
            for (int x = 0; x < w; ++x)
            {
                for (int y = 0; y < h; ++y)
                {
                    if (InputMatrix[x][y].Equals(value))
                        return new Position(x, y);
                }
            }
            return new Position(-1, -1);
        }
    }
    
}
