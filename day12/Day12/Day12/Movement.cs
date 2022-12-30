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
        private Stack<Position> positions = new Stack<Position>();
        private Stack<char> positionValues = new Stack<char>();

        private Stack<(Position, int)> positionAndNumSteps= new Stack<(Position, int)>();

        private char[,] MovementMatrix; 


        public Movement(string path)
        {
            var lines = System.IO.File.ReadAllLines(path);
            InputMatrix = lines.Select(x => x.ToCharArray()).ToArray();
          
            w = InputMatrix.GetLength(0); // width
            h = InputMatrix[0].GetLength(0); // height

            MovementMatrix = new char[w, h];
            inicialPopulateMovementMatrix();

        }



        public int LookForTheMinPathIterative()
        {
            // Inizializate
 
            positions.Push(CoordinatesOf('E'));
            positionAndNumSteps.Push((CoordinatesOf('E'), 0));
            List<int> steps = new List<int>();

            do
            {
 
                var p = positionAndNumSteps.Pop();
                var currentPosition = p.Item1;
                var numSteps = p.Item2;

                bool validPath = false;

                List<Position> validMovements = new List<Position>();
                //check all "next valid movement" - save them in "validMovements" list
                foreach (var m in moves)
                {
                    Position nextPosition = GetNewPosition(currentPosition, m);
                    if (validMovement(currentPosition, m))
                    {
                        validMovements.Add(nextPosition);
                    }
                }


                //any of the list is S?
                Position? nextMovementArrivesToS = AnyNextPositionArrivesToS(validMovements);
                if (nextMovementArrivesToS != null)
                {
                    var last = currentPosition;
                    steps.Add(numSteps + 1);
                }
                //if not
                else
                {
                    foreach (var np in validMovements)
                    {                       
                        
                        if (steps.Count > 0 && numSteps + 1 > steps.Min())
                        {
                            validPath = false; // so much movements, forget this branch
                        }
                        else
                        {
                            positionAndNumSteps.Push((np, numSteps + 1));
                            positions.Push(np);
                            validPath = true;
                        }
                    }                        
                }
                
                //validPath is false when we don't find any next movement or we find S.
                if (!validPath)
                {
                    CleanPositionStack(numSteps);
                }
            }
            while (positionAndNumSteps.Count > 0);

            return steps.Min();
        }

        private Position? AnyNextPositionArrivesToS(List<Position> validMovements)
        {
            foreach (var p in validMovements)
            {
                if (InputMatrix[p.X][p.Y] == 'S')
                {
                    return p;
                }
            }

            return null;
        }

        private void CleanPositionStack(int numSteps)
        {
            if (positionAndNumSteps.Count > 0)
            {
                //peek positionAndNumSteps
                var positionBefore = positionAndNumSteps.Peek().Item1;
                bool cleanStack = false;
                // numSteps - positionAndNumSteps.numSteps = num positions to remove
                do
                {
                    if (positions.Peek() != positionBefore)
                    {
                        positions.Pop();
                    }
                    else
                    {
                        cleanStack = true;
                    }
                }
                while (!cleanStack);
            }

                
        }

        private bool validMovement(Position current, char move)
        {
            Position nextPosition = GetNewPosition(current, move);
            if (nextPosition.X >= 0 && nextPosition.Y >= 0 && nextPosition.X < w && nextPosition.Y < h)
            {
                var currentValue = GetValue(current);
                var nextValue = GetValue(nextPosition);
                return (currentValue - nextValue <= 1 && !positions.Contains(nextPosition));
            }

            return false;
               
        }

        public int LookForTheMinPathStartingFromE()
        {
            int numSteps = 0;
            var currentPosition = CoordinatesOf('E');
            positions.Push(currentPosition);
            positionValues.Push(GetValue(currentPosition));
            List<int> steps = new List<int>();

            foreach (var m in moves)
            {
                steps.Add(ExploreNextMovementR(currentPosition, m, numSteps));
            }


            return steps.Min();

        }

        public int LookForThePathMinSteps()
        {
            int numSteps = 0;
            var currentPosition = CoordinatesOf('S');
            positions.Push(currentPosition);
            positionValues.Push(GetValue(currentPosition));

            List<int> steps =  new List<int>();

            foreach (var m in moves)
            {
                steps.Add(ExploreNextMovement(currentPosition, m, numSteps));
            }

            return steps.Min();
        }

        private int ExploreNextMovementR(Position current, char move, int numSteps)
        {
            var nextPosition = GetNewPosition(current, move);

            // check if the movement is possible:
            // position is not less than 0 (Out of range)
            if (nextPosition.X >= 0 && nextPosition.Y >= 0 && nextPosition.X < w && nextPosition.Y < h)
            {
                var currentValue = GetValue(current);
                var nextValue = GetValue(nextPosition);

                // the value of the next cell - value of current cell <= 1
                if (currentValue - nextValue  <= 1)
                {

                    if (InputMatrix[nextPosition.X][nextPosition.Y] == 'S')
                    {
                        numSteps++;
                        AddMovement(move, current);
                        positions.Push(nextPosition);
                        positionValues.Push(nextValue);


                        // finish! print whatever!!!
                        if (numSteps < minNumSteps)
                        {
                            minNumSteps = numSteps;
                            PrintPossibleSolution(current, numSteps);
                        }
                    }
                    else if (!positions.Contains(nextPosition))
                    {

                        // not visited yet

                        // we can jump! 

                        numSteps++;
                        if (numSteps > minNumSteps)                        {
                            // forget this path, is very long
                            return int.MaxValue;
                        }
                        else
                        {
                            AddMovement(move, current);
                            positions.Push(nextPosition);
                            positionValues.Push(nextValue);
                            foreach (var m in moves)
                            {
                                ExploreNextMovementR(nextPosition, m, numSteps);
                            }
                            DeleteMovement(current);
                            positions.Pop();
                            positionValues.Pop();

                        }
                    }

                }

            }
            return minNumSteps;


        }

        private void PrintPossibleSolution(Position current, int numSteps)
        {
            Console.WriteLine($"Num Steps: {numSteps}");
            Console.WriteLine("Positions");
            foreach (Position p in positions.Reverse())
            {
                Console.Write("(" + p.X + " " + p.Y + ") ->");
            }

            Console.Write("\n");
            Console.WriteLine("Values");
            foreach (var v in positionValues.Reverse())
            {
                Console.Write($"{v} ->");
            }

            printMatrix();
            Console.WriteLine($"visitedCells: {visitedCells()}");

            DeleteMovement(current);
            positions.Pop();
            positionValues.Pop();

            Console.WriteLine("*******************************************");
        }

        private int ExploreNextMovement(Position current, char move, int numSteps)
        {
            var nextPosition = GetNewPosition(current, move);
            
            // check if the movement is possible:
            // position is not less than 0 (Out of range)
            if (nextPosition.X >= 0 && nextPosition.Y >=0 && nextPosition.X < w && nextPosition.Y <h )
            {
                var currentValue = GetValue(current);
                var nextValue = GetValue(nextPosition);
                
                // the value of the next cell - value of current cell <= 1
                if (nextValue - currentValue <= 1)
                {

                    if (InputMatrix[nextPosition.X][nextPosition.Y] == 'E')
                    {
                        numSteps++;
                        AddMovement(move, current);
                        positions.Push(nextPosition);
                        positionValues.Push(nextValue);


                        // finish! print whatever!!!
                        if (numSteps < minNumSteps)
                        {
                            minNumSteps = numSteps;
                            PrintPossibleSolution(current, numSteps);
                        }
                    }
                    else if (!positions.Contains(nextPosition))
                    {

                        // not visited yet

                        // we can jump! 
                        //listOfMovements.Add(move);

                        numSteps++;

                        if (numSteps > minNumSteps)
                        {
                            // forget this path, is very long
                            return int.MaxValue;
                        }
                        else
                        {
                            AddMovement(move, current);
                            positions.Push(nextPosition);
                            positionValues.Push(nextValue);
                            foreach (var m in moves)
                            {
                                ExploreNextMovement(nextPosition, m, numSteps);
                            }
                            DeleteMovement(current);
                            positions.Pop();
                            positionValues.Pop();

                        }
                    }                

                }

            }
            return minNumSteps;          


        }

        private int visitedCells()
        {
            int visited = 0;

            for (int x = 0; x < w; ++x)
            {
                for (int y = 0; y < h; ++y)
                {
                    if (MovementMatrix[x, y] != '.')
                    {
                        visited++;
                    }
                }
            
            }

            return visited;
        }

        private void printMatrix()
        {
            Console.Write("\n");

            for (int x = 0; x < w; ++x)
            {
                for (int y = 0; y < h; ++y)
                {
                    Console.Write(MovementMatrix[x, y]);
                }
                Console.Write("\n");
            }
        }

        private void DeleteMovement(Position position)
        {
            MovementMatrix[position.X, position.Y] = '.';
        }

        private void AddMovement(char move, Position position)
        {
            if (move == 't')
            {
                MovementMatrix[position.X, position.Y] = '^';
            }
            else if (move == 'b')
            {
                MovementMatrix[position.X, position.Y] = 'v';

            }
            else if (move == 'r')
            {
                MovementMatrix[position.X, position.Y] = '>';

            }
            else if (move == 'l')
            {
                MovementMatrix[position.X, position.Y] = '<';
            }
            else
            {
                throw new Exception($"WTF?? movement {move} not recognized!! ");
            }
           
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

        private void inicialPopulateMovementMatrix()
        {
            for (int x = 0; x < w; ++x)
            {
                for (int y = 0; y < h; ++y)
                {
                    MovementMatrix[x, y] = '.';
                }
            }

            var e = CoordinatesOf('E');
            MovementMatrix[e.X, e.Y] = 'E';

        }
    }
    
}
