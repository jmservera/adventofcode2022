// See https://aka.ms/new-console-template for more information
using day05;

List<string> files = new List<string>()
{
    "./data/jm.txt",
    "./data/isa.txt"
};

foreach (var file in files)
{
    var cs = new CraneStacks(file);
    var result = cs.RunAllMoves();
    Console.WriteLine($"The moves CrateMover 9000 for ${file} are ${result}.");
    cs = new CraneStacks(file);
    var result2 = cs.RunAllMoves9001();
    Console.WriteLine($"The moves CrateMover 9001 for ${file} are ${result2}.");
}
Console.Read();
