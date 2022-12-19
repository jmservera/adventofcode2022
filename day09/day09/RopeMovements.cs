using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day09
{
    public class RopeMovements
    {
        public Position H = new Position(0, 0);
        public Position T = new Position(0, 0);

        public RopeMovements(Position h, Position t) 
        {
            H = h;
            T = t;
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
        public bool Diagonal()
        {

            return true;
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
