using day11;

List<string> files = new List<string>()
{
    "./data/isa.txt"
};

foreach (var file in files)
{
    var monkeys= Monkey.Parse(file);
    Console.WriteLine($"File: {file} has {monkeys.Count} monkeys");
    if (monkeys.Count > 0)
    {
        MonkeyRunner.RunCycles(monkeys, 20);
        
        for (int m = 0; m < monkeys.Count; m++)
        {
            Console.WriteLine($"Monkey {m} inspected items {monkeys[m].Counter} times.");
        }
        var bigMonkeys = monkeys.Select(m => m.Counter).OrderByDescending(m => m).Take(2).ToList();
        var monkeyBusiness = bigMonkeys[0] * bigMonkeys[1];
        Console.WriteLine($"Monkey business for {file} is {monkeyBusiness}");
    }
}
Console.WriteLine("Press return key to run the 10000 rounds.");
Console.Read();
foreach (var file in files)
{
    var monkeys = Monkey.Parse(file);
    if (monkeys.Count > 0)
    {
        MonkeyRunner.RunCycles(monkeys, 10000, true);
        for (int m = 0; m < monkeys.Count; m++)
        {
            Console.WriteLine($"Monkey {m} inspected items {monkeys[m].Counter} times.");
        }
        var bigMonkeys = monkeys.Select(m => m.Counter).OrderByDescending(m => m).Take(2).ToList();
        var monkeyBusiness = bigMonkeys[0] * bigMonkeys[1];
        Console.WriteLine($"Monkey business for {file} is {monkeyBusiness}");
    }
}
Console.Read();