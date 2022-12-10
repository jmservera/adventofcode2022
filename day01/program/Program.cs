// See https://aka.ms/new-console-template for more information

var elvesFile = "./data/elvesIsa.txt";
var elvesFileIsa = "./data/elves.txt";
Console.WriteLine($"The result for Juanma is {new CaloriesCounter(elvesFile).FindMax()}");
Console.WriteLine($"The result for Isa is {new CaloriesCounter(elvesFileIsa).FindMax()}");
