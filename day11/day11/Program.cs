using day11;

List<string> files = new List<string>()
{
    "./data/test.txt",
    "./data/isa.txt",
    "./data/jm.txt"
};

foreach (var file in files)
{
    var monkeys= Monkey.Parse(file);
    Console.WriteLine($"File: {file} has {monkeys.Count} monkeys");
    if (monkeys.Count > 0)
    {
        for (int i = 0; i < 20; i++)
        {
            foreach (var monkey in monkeys)
            {
                monkey.RunTurn();
            }
        }
        for (int m = 0; m < monkeys.Count; m++)
        {
            Console.WriteLine($"Monkey {m} inspected items {monkeys[m].Counter} times.");
        }
        var monkeyBusiness = monkeys.Select(m => m.Counter).OrderByDescending(m => m).Take(2).Aggregate((a, b) => a * b);
        Console.WriteLine($"Monkey business for {file} is {monkeyBusiness}");
    }
}
//Console.WriteLine("Press return key to run the 10000 rounds.");
//Console.Read();
//foreach (var file in files)
//{
//    var monkeys = Monkey.Parse(file);
//    if (monkeys.Count > 0)
//    {
//        foreach (var monkey in monkeys)
//        {
//            monkey.WorryDivider = 1;
//        }
//        for (int i = 0; i < 20; i++)
//        {
//            foreach (var monkey in monkeys)
//            {
//                monkey.RunTurn();
//            }
//        }
//        for (int m = 0; m < monkeys.Count; m++)
//        {
//            Console.WriteLine($"Monkey {m} inspected items {monkeys[m].Counter} times.");
//        }
//        var bigMonkeys = monkeys.Select(m => m.Counter).OrderByDescending(m => m).Take(2).ToList();
//        long monkeyBusiness = (long)bigMonkeys[0] * (long)bigMonkeys[1];
//        Console.WriteLine($"Monkey business for {file} is {monkeyBusiness}");
//    }
//}
Console.Read();