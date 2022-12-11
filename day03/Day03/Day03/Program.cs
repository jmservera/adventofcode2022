// See https://aka.ms/new-console-template for more information
using Day03;

Console.WriteLine($"The result for Test is {new Rucksack("./data/test.txt").GetSumPriorities()}");
Console.WriteLine($"The result for Juanma is {new Rucksack("./data/juanma.txt").GetSumPriorities()}");
Console.WriteLine($"The result for Isa is {new Rucksack("./data/isa.txt").GetSumPriorities()}");

Console.WriteLine($"The result02 for Test is {new Rucksack("./data/test.txt").GetSumGroupPriorities()}");
Console.WriteLine($"The result02 for Juanma is {new Rucksack("./data/juanma.txt").GetSumGroupPriorities()}");
Console.WriteLine($"The result02 for Isa is {new Rucksack("./data/isa.txt").GetSumGroupPriorities()}");


Console.Read();