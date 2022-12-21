using day11;

List<string> files = new List<string>()
{
    "./data/test.txt",
    "./data/isa.txt",
    "./data/jm.txt"
};

foreach (var file in files)
{
    var monkeys= Monkey.Parse(file);
    Console.WriteLine($"File: {file} has {monkeys.Count} monkeys");
}
Console.Read();