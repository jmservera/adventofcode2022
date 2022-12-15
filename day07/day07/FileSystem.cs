using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day07
{
    public class FileSystem
    {
        public string[] commands;
        public Stack<string> currentDirectory;
        Dictionary<string, long> directorySizes;

        public FileSystem(string path) 
        {
            commands = System.IO.File.ReadAllLines(path);
            currentDirectory = new Stack<string>();
            directorySizes = new Dictionary<string, long>();
        }



        public void RunCommands()
        {
            long size = 0;
            for (int i = 0; i < commands.Count(); i++)
            {
                var command = commands[i];
                if (command[0] == '$')
                {
                    // It's a command

                    var parts = command.Split(' ');
                    if (parts.Count() == 3)
                    {
                        //it's a cd
                        var directoryNav = parts[2];
                        if (directoryNav == "..")
                        {
                            var dir = currentDirectory.Pop();
                        }
                        else
                        {
                            currentDirectory.Push(directoryNav);
                        }
                    }
                    else if (parts.Count() == 2)
                    {
                        // it's an ls
                        //next thing is an output
                        size += GetSizeOutput( i);
                        AddSizeToTheDirectoriesInTheStack(size);
                        size = 0;
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
                    //ignore it because we processed it in "GetSizeOutput" method
                }
            }
        }

        private void AddSizeToTheDirectoriesInTheStack(long size)
        {
            String path = String.Empty;

            foreach (var dir in currentDirectory.Reverse())
            {
                if (path.Length > 1)
                {
                    path += "/";
                }
                path += dir;                            


                if (directorySizes.ContainsKey(path))
                {
                    //add size
                    directorySizes[path] += size;
                }
                else
                {
                    //add item
                    directorySizes[path] = size;
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
                if (i < commands.Count())
                {
                    var result = commands[i];

                    if (result[0] != '$')
                    {
                        //sigue siendo result
                        var parts = result.Split(' ');
                        if (parts[0] == "dir")
                        { }
                        else
                        {
                            var size = long.Parse(parts[0]);
                            sizeSum += size;
                        }
                        i++;
                    }
                    else
                    {
                        isResult = false;
                    }
                }
                else
                { 
                    isResult = false; 
                }

            } while (isResult);
            return sizeSum;
        }


        public long FolderSize(string folder)
        {
            return directorySizes[folder];
        }

        public long SumAtMost100000()
        {
            long totalSum = 0;
            foreach (var dir in directorySizes)
            {
                if (dir.Value <= 100000)
                {
                    totalSum += dir.Value;
                }                
            }

            var test = directorySizes.Where(dir => dir.Value <= 100000).Sum(dir => dir.Value);
            return totalSum;
        }

        public long MinSizeMoreThan30000000()
        {
            var spaceAvailable = 70000000 - directorySizes.FirstOrDefault(dir => dir.Key.Equals("/")).Value;
            var totalSpaceNeeded = 30000000;
            var spaceNeedToBeFreeUp = totalSpaceNeeded - spaceAvailable;

            var size = directorySizes.Where(dir => dir.Value >= spaceNeedToBeFreeUp);
            var min = size.Min( dir => dir.Value);
            return min;
        }
    }
}
