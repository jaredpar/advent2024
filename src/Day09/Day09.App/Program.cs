// See https://aka.ms/new-console-template for more information
using Day09;

Console.WriteLine(Puzzle.ChecksumCompacted(Input.Test));
Console.WriteLine(Puzzle.ChecksumCompacted(Input.Real));
Console.WriteLine(Puzzle.ChecksumCompactedWhole(Input.Test));
Console.WriteLine(Puzzle.ChecksumCompactedWhole(Input.Real));



/*
void Go(string input)
{
    var list = Puzzle.Parse(input);
    Puzzle.CompatWhole(list);
    Console.WriteLine(Puzzle.AsString(list));
    Console.WriteLine(Puzzle.Checksum(list));
}
*/