using Advent.Util;
using Day02;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Console.WriteLine($"Part1 Test: {Puzzle.CountSafe(Input.Test)}");
Console.WriteLine($"Part1 Real: {Puzzle.CountSafe(Input.Real)}");
Console.WriteLine($"Part2 Test: {Puzzle.CountSafe(Input.Test, dampner: true)}");
Console.WriteLine($"Part2 Real: {Puzzle.CountSafe(Input.Real, dampner: true)}");


var e = Input.Real.SplitLines();
while (e.MoveNext())
{
    var current = e.Current;
    var readings = Puzzle.ParseReadings(current);
    if (!Puzzle.AreReadingsSafe(readings, dampner: false) &&
        Puzzle.AreReadingsSafe(readings, dampner: true) &&
        !Puzzle.AreReadingsSafe(readings[1..], dampner: false))
    {
        Console.WriteLine(current.ToString());
    }
}