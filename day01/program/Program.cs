// See https://aka.ms/new-console-template for more information

var elvesFile = "./data/elves.txt";
var elvesFileIsa = "./data/elvesIsa.txt";
Console.WriteLine($"The result for Juanma is {new CaloriesCounter(elvesFile).SumTopThreeMax()}");
Console.WriteLine($"The result for Isa is {new CaloriesCounter(elvesFileIsa).SumTopThreeMax()}");
Console.Read();