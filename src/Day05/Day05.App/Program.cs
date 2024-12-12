// See https://aka.ms/new-console-template for more information
using Day05;

var (map, updates) = Puzzle.Parse(Input.Test);

Console.WriteLine(Puzzle.SumUnorderedPageMiddles(Input.Test));
Console.WriteLine(Puzzle.SumUnorderedPageMiddles(Input.Real));

