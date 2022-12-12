using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day06
{
    public class Sequency
    {
        string signal;

        public Sequency(string path) 
        {
            signal = System.IO.File.ReadAllLines(path).ToString();

        }
        public int FindMarkerInSignal()
        {
            return FindMarker(signal);
        }
        public static int FindMarker(string signal)
        {
            int pointer = 0;
            for (int i = 0; i < signal.Length; i++) 
            { 
                
            }

            // TODO: juanma
            return 4;
        }

        public int GetSignalLenght()
        { 
            return signal.Length;
        }

        public static bool checkIfDifferents(string sequency)
        {
            for(int i = 0; i< sequency.Length; i++)
            {
                for(int j=i+1; j < sequency.Length; j++)
                {
                    if (sequency[i] == sequency[j])
                    {
                        return false;
                    }
                }
            }
            return true; 
        }
    }
}
