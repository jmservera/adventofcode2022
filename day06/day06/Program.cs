using day06;

var inputFiles = new string[] { "./data/isa.txt", "./data/juanma.txt" };

foreach (var file in inputFiles)
{
    var r = new Sequency(file);

    Console.WriteLine($"{file} the Marker finishes in {r.FindMarkerInSignal()} ");
}

Console.ReadLine();