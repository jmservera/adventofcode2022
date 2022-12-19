using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace day09
{
    public class RopeMovements
    {
        public Position H = new Position(0, 0);
        public Position T = new Position(0, 0);
        private List<(int, char)> movements = new();
        private List<Position> positionsVisitedByTheTail = new List<Position>();


        public RopeMovements(Position h, Position t)
        {
            H = h;
            T = t;
            positionsVisitedByTheTail.Add(new Position(T.X, T.Y));
        }

        public void ReadAndParseMovementFile(string path)
        {
            var lines = System.IO.File.ReadAllLines(path);
            foreach (var line in lines)
            {
                char character = line.Split(' ')[0][0];
                var number = int.Parse(line.Split(' ')[1]);
                movements.Add((number, character));
            }

        }

        public int RunMovements()
        { 
            foreach (var movement in movements) 
            {
                var direction = GetDirection(movement.Item2);
                for(int i = 0; i < movement.Item1; i++)
                {
                    MoveH(direction);

                    AddPositionVisited();

                    PrintMatrix();
                }
            }

            return positionsVisitedByTheTail.Count();
        
        }

        public void MoveH(Movs movement)
        {
            int previousHx=H.X;
            int previousHy=H.Y;

            switch (movement)
            {
                case Movs.Up:
                    H.X--;
                    break;

                case Movs.Down:
                    H.X++;
                    break;

                case Movs.Left:
                    H.Y--;
                    break;
                case Movs.Right:
                    H.Y++;
                    break;
            }

            if (!H.Touching(T))
            {
                MoveT(previousHx, previousHy);
            }

        }

        public void MoveT(int x, int y)
        {
            T.X = x;
            T.Y = y;
        }
        public Movs GetDirection(char dir)
        {
            if (dir == 'U') return Movs.Up;
            if (dir == 'D') return Movs.Down;
            if (dir == 'R') return Movs.Right;
            else return Movs.Left;
        }

        public void PrintMatrix()
        {
            for (int i = 0; i < 40; i++) 
            {
                string row = String.Empty;

                for (int j = 0; j < 40; j++)
                {
                    if (i == H.X && j == H.Y)
                    {
                        row += 'H';
                    }
                    else if (i == T.X && j == T.Y)
                    {
                        row += 'T';
                    }
                    else if (positionsVisitedByTheTail.Exists(x => x.X.Equals(i) && x.Y.Equals(j)))
                    {
                        row += '#';
                    }
                    else
                    {
                        row += '.';
                    }
                }
                Console.WriteLine(row);
            }
            Console.WriteLine(String.Format($"visited positions {positionsVisitedByTheTail.Count}"));
            Thread.Sleep(1000);
            Console.Clear();
        
        }

        private void AddPositionVisited()
        {
            var pos = positionsVisitedByTheTail.Where(x => x.X.Equals(T.X) && x.Y.Equals(T.Y)).FirstOrDefault();
            if (pos == null)
            {
                positionsVisitedByTheTail.Add(new Position(T.X, T.Y));
            }
        }


    }


    public enum Movs
    {
        Up, 
        Down, 
        Right, 
        Left
    }








}
