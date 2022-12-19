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
        public List<Position> rope=new List<Position>();
        public Position H { get { return rope[0]; } }
        public Position T { get { return rope[rope.Count - 1]; } }
        
        private List<(int, char)> movements = new();
        private List<Position> positionsVisitedByTheTail = new List<Position>();

        public RopeMovements(Position h, Position t, int len=2)
        {
            rope.Add(h);
            for (int i = 0; i < len-1; i++)
            {
                rope.Add(new Position(t.X, t.Y));
            }
            positionsVisitedByTheTail.Add(new Position(t.X, t.Y));
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

        public int RunMovements(bool debug=false)
        { 
            foreach (var movement in movements) 
            {
                for(int i = 0; i < movement.Item1; i++)
                {
                    MoveH(movement.Item2);

                    AddPositionVisited();
                    if (debug)
                    {
                        PrintMatrix();
                    }
                }
            }

            return positionsVisitedByTheTail.Count();
        
        }

        public void MoveH(char movement)
        {
            switch (movement)
            {
                case 'U':
                    H.X--;
                    break;
                case 'D':
                    H.X++;
                    break;
                case 'L':
                    H.Y--;
                    break;
                case 'R':
                    H.Y++;
                    break;
            }

            for (int i = 1; i < rope.Count; i++)
            {
                if (!rope[i - 1].Touching(rope[i]))
                {
                    rope[i].Approach(rope[i - 1]);
                }
            }

        }

        public void PrintMatrix()
        {
            for (int i = 0; i < 40; i++) 
            {
                string row = String.Empty;

                for (int j = 0; j < 40; j++)
                {
                    bool found = false;
                    for (int pos= 0;pos < rope.Count;pos++)
                    {
                        if (rope[pos].X == i && rope[pos].Y == j)
                        {
                            if (pos == 0)
                                row += "H";
                            else
                                row += (char)('0' + pos);                            
                            found = true;
                            break;
                        }                        
                    }
                    if (!found)
                    {
                        if (positionsVisitedByTheTail.Contains(new Position(i, j)))
                        {
                            row += '#';
                        }
                        else
                        {
                            row += '.';
                        }
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
            
            //var pos = positionsVisitedByTheTail.Where(x => x.X.Equals(T.X) && x.Y.Equals(T.Y)).FirstOrDefault();
            if (!positionsVisitedByTheTail.Contains(new Position(T.X, T.Y)))
            {
                positionsVisitedByTheTail.Add(new Position(T.X, T.Y));
            }
        }
    }
}
