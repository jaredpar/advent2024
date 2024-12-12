// See https://aka.ms/new-console-template for more information

using Day07;

Console.WriteLine(Puzzle.SumGoodEquations(Input.Test));
Console.WriteLine(Puzzle.SumGoodEquations(Input.Real));
Console.WriteLine(Puzzle.SumGoodEquations(Input.Test, useConcat: true));
Console.WriteLine(Puzzle.SumGoodEquations(Input.Real, useConcat: true));
