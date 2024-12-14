// See https://aka.ms/new-console-template for more information
using Day09;

Console.WriteLine("Hello, World!");
Console.WriteLine(Puzzle.ChecksumCompacted(Input.Test));
Console.WriteLine(Puzzle.ChecksumCompacted(Input.Real));
Go(Input.Test);

void Go(string input)
{
    var list = Puzzle.Parse(input);
    Console.WriteLine(Puzzle.AsString(list));
    var compacted = Puzzle.Compact(list);
    Console.WriteLine(Puzzle.AsString(compacted));
}