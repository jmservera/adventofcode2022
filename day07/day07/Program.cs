// See https://aka.ms/new-console-template for more information
using day07;

List<string> files = new List<string>()
{
    "./data/jm.txt",
    "./data/isa.txt"
};

foreach (var file in files)
{
    var fs = new FileSystem(file);
    fs.RunCommands();
    var result = fs.SumAtMost100000();
    Console.WriteLine($"The result for {file} are {result}.");
    var result2 = fs.MinSizeMoreThan30000000();
    Console.WriteLine($"The 2nd result for ${file} is ${result2}.");
}
Console.Read();
