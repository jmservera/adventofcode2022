using Day12;

string path = "./data/test.txt";
var mov = new Movement(path);

var mov2 = mov.LookForTheMinPathIterative();
Console.WriteLine("Min Movements: "+  mov2 );

Console.Read();
