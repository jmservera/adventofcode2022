using Day12;

string path = "./data/isa.txt";
var mov = new Movement(path);

var mov2 = mov.LookForTheMinPathStartingFromE();
Console.WriteLine("Min Movements: "+  mov2 );

Console.Read();
