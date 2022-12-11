// See https://aka.ms/new-console-template for more information
using day04;

var inputFiles = new string[] { "./data/isa.txt", "./data/jm.txt" };

foreach(var file in inputFiles)
{
    var r = new RangeCheck(file);
        
    Console.WriteLine($"{file} has {r.CountFullyContainedRanges()} fully contained ranges");

    Console.WriteLine($"{file} has {r.CountOverlappedRanges()} overlapped ranges");
}

Console.ReadLine();