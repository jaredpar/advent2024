// See https://aka.ms/new-console-template for more information
using Day14;

Console.WriteLine(Puzzle.ScoreQuadrants(Input.Test, rows: 7, columns: 11));
Console.WriteLine(Puzzle.ScoreQuadrants(Input.Real, rows: 103, columns: 101));

void Test()
{
    var rows = 7;
    var columns = 11;
    Robot[] robots = Puzzle.Parse(Input.Test);
    Console.WriteLine(Puzzle.RenderAsString(robots, rows, columns));
    Puzzle.Execute(robots, rows, columns, times: 100);
    Console.WriteLine(Puzzle.RenderAsString(robots, rows, columns));
}