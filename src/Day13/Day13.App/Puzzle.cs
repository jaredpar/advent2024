using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Advent.Util;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Complex;
using Movement = (long X, long Y);

namespace Day13;

public sealed class Machine(Movement buttonA, Movement buttonB, Movement goal)
{
    public Movement ButtonA { get; } = buttonA;
    public Movement ButtonB { get; } = buttonB;
    public Movement Goal { get; } = goal;

    public long? Solve() => Solve(ButtonA, ButtonB, Goal);
    public long? SolveHard() => Solve(ButtonA, ButtonB, (Goal.X + 10000000000000, Goal.Y + 10000000000000));

    private static long? Solve(Movement buttonA, Movement buttonB, Movement goal)
    {
        var det = (buttonA.X * buttonB.Y) - (buttonA.Y * buttonB.X);
        var aCount = ((goal.X * buttonB.Y) - (goal.Y * buttonB.X)) / det;
        var bCount = ((buttonA.X * goal.Y) - (buttonA.Y * goal.X)) / det;

        if ((aCount * buttonA.X) + (bCount * buttonB.X) == goal.X &&
            (aCount * buttonA.Y) + (bCount * buttonB.Y) == goal.Y)
        {
            return (aCount * 3) + bCount;
        }

        return null;
    }
}

public static class Puzzle
{
    public static List<Machine> ParseMachines(string input)
    {
        var e = input.SplitLines();
        var list = new List<Machine>();
        while (e.MoveNext())
        {
            var buttonA = ParseButton(e.Current);
            Require(e.MoveNext());
            var buttonB = ParseButton(e.Current);
            Require(e.MoveNext());
            var goal = ParseGoal(e.Current);
            list.Add(new (buttonA, buttonB, goal));

            if (!e.MoveNext())
            {
                break;
            }
            else
            {
                Require(e.Current.IsEmpty);
            }
        }

        return list;

        static Movement ParseButton(ReadOnlySpan<char> line)
        {
            var x = ParseCore(ref line, '+', ',');
            var y = ParseCore(ref line, '+', null);
            return (x, y);
        }

        static Movement ParseGoal(ReadOnlySpan<char> line)
        {
            var x = ParseCore(ref line, '=', ',');
            var y = ParseCore(ref line, '=', null);
            return (x, y);
        }

        static int ParseCore(ref ReadOnlySpan<char> line, char start, char? end)
        {
            var index = line.IndexOf(start);
            Require(index > 0);
            line = line[(index + 1)..];

            int value;
            if (end is { } c)
            {
                index = line.IndexOf(c);
                Require(index > 0);
                value = int.Parse(line[..index]);
                line = line[(index + 1)..];
            }
            else
            {
                value = int.Parse(line);
                line = ReadOnlySpan<char>.Empty;
            }

            return value;
        }

        static void Require(bool b)
        {
            if (!b)
            {
                throw new InvalidOperationException();
            }
        }
    }

    public static long GetTotal(string input, bool hard = false)
    {
        var machines = ParseMachines(input);
        var total = 0L;
        foreach (var machine in machines)
        {
            var result = hard ? machine.SolveHard() : machine.Solve();
            if (result is { } r)
            {
                total += r;
            }
        }

        return total;
    }
}
