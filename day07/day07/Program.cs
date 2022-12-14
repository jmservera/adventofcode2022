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
/*    cs = new CraneStacks(file);
    var result2 = cs.RunAllMoves9001();
    Console.WriteLine($"The moves CrateMover 9001 for ${file} are ${result2}.");*/
}
Console.Read();
