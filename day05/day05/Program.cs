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
    Console.WriteLine($"The moves for ${file} are ${result}.");
}
