using day08;

List<string> files = new List<string>()
{
    "./data/jm.txt",
    "./data/isa.txt"
};

foreach (var file in files)
{
    var forest = new Forest(file);
    Console.WriteLine($"The result for {file} is {forest.CountVisibleTrees()}.");
}
Console.Read();