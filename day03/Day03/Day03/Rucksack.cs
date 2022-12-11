using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Day03
{
    public class Rucksack
    {
        string[] data;

        public Rucksack(string path)
        {
            data = System.IO.File.ReadAllLines(path); 
        }

        public int GetSumPriorities()
        {
            int sumPriorities = 0;
            foreach (var line in data)
            {
                var item = FindRepeatedItem(line);
                if (item != '\0')
                    sumPriorities += GetPriority(item);
                else
                    Console.WriteLine($"La secuencia {line} no contiene elementos repetidos");
            }

            return sumPriorities;
        }

        public static int GetPriority(char item)
        {
            if (item >= 'a' && item <= 'z')
                return (int)item - (int)'a'+1;

            return (int)item - (int)'A' + 27;
        }

        public static char FindRepeatedItem(string allTheRucksack)
        {
            if (allTheRucksack.Length % 2 != 0)
            {
                throw new ArgumentException();
            }

            return FindRepeatedItem(allTheRucksack.Substring(0, (allTheRucksack.Length / 2)),
                            allTheRucksack.Substring((allTheRucksack.Length / 2)));            

        }

        public static char FindRepeatedItem(string compartment1, string compartment2)
        {
            var common = compartment1.Intersect(compartment2);
           
            return common.FirstOrDefault();
        }
    }
}
