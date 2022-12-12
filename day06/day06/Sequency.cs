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
            signal = System.IO.File.ReadAllText(path);
        }
        
        public int FindMarkerInSignal()
        {
            return FindMarker(signal);
        }
        public static int FindMarker(string signal)
        {
            for (int i = 0; i < signal.Length-4; i++) 
            {
                if (checkIfDifferents(signal.Substring(i, 4)))
                    return i+4;
            }

            return -1;
        }

        public static int FindMarker14(string signal)
        {
            for (int i = 0; i < signal.Length - 14; i++)
            {
                if (checkIfDifferents(signal.Substring(i, 14)))
                    return i + 14;
            }

            return -1;
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
