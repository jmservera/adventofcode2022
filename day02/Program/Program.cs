// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var pathIsa = "./data/isa.txt"; 
var pathJm = "./data/juanma.txt";

var gameI = new RockPaperScissors(pathIsa).Score();
var gameJ = new RockPaperScissors(pathJm).Score();

Console.WriteLine($"The result for Juanma is {gameJ}");
Console.WriteLine($"The result for Isa is {gameI}");


Console.WriteLine($"The result 2 for Juanma is {new RockPaperScissors(pathJm).ScoreStrategy()}");
Console.WriteLine($"The result 2 for Isa is { new RockPaperScissors(pathIsa).ScoreStrategy()}");


Console.Read();

// A for Rock, B for Paper, and C for Scissors.
// Y for Paper, X for Rock, Z for Scissors
// Rock = 1
// Paper = 2
// Scissors = 3