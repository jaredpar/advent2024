// See https://aka.ms/new-console-template for more information
using Day13;

Console.WriteLine(Puzzle.GetTotal(Input.Test));
Console.WriteLine(Puzzle.GetTotal(Input.Real));


/*
void Go(string input)
{
    var machines = Puzzle.ParseMachines(input);
    foreach (var machine in machines)
    {
        var result = machine.Solve();
        Console.WriteLine($"X: {machine.Goal.X} Y: {machine.Goal.Y} => {result}"); 
    }
}
*/
