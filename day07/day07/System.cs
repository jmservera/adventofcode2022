using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day07
{
    public class System
    {
        public string[] commands;
        public Stack<string> currentDirectory;
        public System(string path)
        {
            var commands = System.IO.File.ReadAllLines(path);
            currentDirectory = new Stack<string>();
        }

        public void RunCommands()
        {
            long size = 0;
            string path = string.Empty;

            for (int i=0; i<commands.Count(); i++)
            {
                var command = commands[i];
                if (command[0] == '$')
                {
                    // It's a command

                    var parts = command.Split(' ');
                    if (parts.Count() == 3)
                    {
                        //it's a cd
                        var directoryNav = parts[3];
                        if (directoryNav == '..')
                        {
                            var dir = currentDirectory.Pop();
                        }
                        else
                        {
                            path += directoryNav;
                            currentDirectory.Push(path)
                        }

                    }
                    else if (parts.Count == 2)
                    {
                        // it's an ls

                        //next thing is an output
                        size += GetSizeOutput(ref i);
                    }
                    else 
                    {
                        throw new Exception($"What is this {command}?");
                    }
                    

                    //it could be a cd 'directory'


                    // or cd ..
                }
                else
                { 
                    // It's a result
                }
            }
        }

        private long GetSizeOutput(int i)
        {
            bool isResult = true;
            i++;
            long sizeSum = 0;
            do
            {
                var result = commands[i];

                if (result[0] != "$")
                {
                    //sigue siendo result
                    var parts = result.Split(' ');
                    var size = long.Parse(parts[0]);
                    sizeSum += size;
                    i++;
                }
                else
                {
                    isResult = false;
                }

                
            } while (isResult);

            return sizeSum;
        }
    }
}
