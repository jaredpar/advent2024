// See https://aka.ms/new-console-template for more information

using Day08;

Console.WriteLine(Puzzle.CountUniqueAntiNodes(Input.Test));
Console.WriteLine(Puzzle.CountUniqueAntiNodes(Input.Real));
Console.WriteLine(Puzzle.CountUniqueAntiNodes(Input.Test, countAll: true));
Console.WriteLine(Puzzle.CountUniqueAntiNodes(Input.Real, countAll: true));
