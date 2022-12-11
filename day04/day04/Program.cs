// See https://aka.ms/new-console-template for more information
using day04;

var inputFiles = new string[] { "./data/isa.txt", "./data/jm.txt" };

foreach(var file in inputFiles)
{
    var r = new RangeCheck(file).CountFullyContainedRanges();
    Console.WriteLine($"{file} has {r} fully contained ranges");

    var r = new RangeCheck(file).over();
    Console.WriteLine($"{file} has {r} fully contained ranges");
}

Console.ReadLine();