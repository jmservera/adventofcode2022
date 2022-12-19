using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day09
{
    public record Position
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
            if (Distance(x, y) < 2) return true;
            else return false;
        }

        public double Distance(int x, int y){
            return Math.Sqrt(Math.Pow(x - X, 2) + Math.Pow(y - this.Y, 2));
        }

        public bool Diagonal(Position x)
        {
            return Diagonal(x.X, x.Y);
        }

        public bool Diagonal (int x, int y) 
        {
            var distance = Distance(x,y);
            if (distance < 2 && distance > 1) return true;
            else return false;
        }

        public void Approach(Position position)
        {
            int x = position.X - X;
            int y = position.Y - Y;
            if(x!=0)
                X += x/Math.Abs(x);
            if(y!=0)
                Y += y/Math.Abs(y);
        }
    }

}
