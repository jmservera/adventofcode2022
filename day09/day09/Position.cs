using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day09
{
    public class Position
    {
        public int X;
        public int Y;

        public Position(int x, int y)
        { 
            X= x;
            Y= y;
        }
        public bool Touching(Position x)
        {
            return Touching(x.X, x.Y); 
        }

        public bool Touching(int x, int y)
        {
            var distance = Math.Sqrt(Math.Pow(x - X, 2) + Math.Pow(y - this.Y, 2));
            if (distance < 2) return true;
            else return false;
        }
    
        public bool Diagonal(Position x)
        {
            return Diagonal(x.X, x.Y);
        }

        public bool Diagonal (int x, int y) 
        {
            var distance = Math.Sqrt(Math.Pow(x - X, 2) + Math.Pow(y - this.Y, 2));
            if (distance < 2 && distance > 1) return true;
            else return false;
        }
    }

}
