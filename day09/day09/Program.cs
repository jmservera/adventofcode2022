
using day09;

List<string> files = new List<string>()
{    
    "./data/testlong.txt",
    "./data/jm.txt",
    "./data/isa.txt"
};

foreach (var file in files)
{
    var mov = new RopeMovements(new Position(5,10), new Position(5, 10),10);
    mov.ReadAndParseMovementFile(file);
    var result = mov.RunMovements();
    Console.WriteLine($"The result for {file} is {result}.");

    Console.Read();
}
Console.Read();