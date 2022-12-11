using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace day04
{
    public class RangeCheck
    {

        string[] ranges;

        public RangeCheck( string path) 
        {
            ranges = System.IO.File.ReadAllLines(path);
        }

        public int CountFullyContainedRanges()
        {
            var count = 0;
            foreach (var range in ranges)
            {
                var (a1, b1, a2, b2) = ParseRange(range);
                if (ContainRange(a1, b1, a2, b2))
                {
                    count++;
                }
            }
            return count;
        }
        public int CountOverlappedRanges()
        {
            return 0;
        }

        //two ranges are a1-b1, a2-b2
        public static bool ContainRange(int a1, int b1, int a2, int b2)
        {
            if(a1>=a2)
            {
                if (b1 <= b2)
                    return true;
            }

            if (a2 >= a1)
            {
                if (b2 <= b1)
                    return true;
            }

            return false;
        }


        public static bool OverlapRange(int a1, int b1, int a2, int b2)
        {
            if (a1 >= a2 && a1 <= b2)
            {
                return true;
            }
            if (a2 >= a1 && a2 <= b1)
            {
                return true;
            }
            return false;
        }
        public static (int, int, int, int) ParseRange(string line)
        {
            var query = from s in line.Split(',')
                        let range = s.Split('-')
                        from r in range
                        select int.Parse(r);
            var l = query.ToList();
            return (l[0], l[1], l[2], l[3]);
        }


    }
}
