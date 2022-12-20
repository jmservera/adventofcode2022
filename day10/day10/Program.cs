using day10;

List<string> files = new List<string>()
{
    "./data/test.txt",
    "./data/isa.txt",
    "./data/jm.txt"
};

foreach (var file in files)
{
    var fs = new Operations(file);
    fs.RunOperations();
    var result = fs.GetSignalStrength();
    Console.WriteLine($"The result for {file} are {result}.");
    /*    var result2 = fs.MinSizeMoreThan30000000();
        Console.WriteLine($"The 2nd result for ${file} is ${result2}.");*/
}
Console.Read();