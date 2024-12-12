// See https://aka.ms/new-console-template for more information
using Day05;

Console.WriteLine(Puzzle.SumOrderedPageMiddles(Input.Test));
Console.WriteLine(Puzzle.SumOrderedPageMiddles(Input.Real));
/*
var (map, updates) = Puzzle.Parse(Input.Test);

foreach (var update in updates)
{
    var prefix = Puzzle.IsOrdered(map, update) ? "Ordered: " : "Not ordered: ";
    Console.WriteLine($"{prefix}{string.Join(", ", update)}");
}
*/

