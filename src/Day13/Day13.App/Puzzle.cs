using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Advent.Util;

using Movement = (int X, int Y);

namespace Day13;

public class Machine(Movement buttonA, Movement buttonB, Movement goal)
{
    public Movement ButtonA { get; } = buttonA;
    public Movement ButtonB { get; } = buttonB;
    public Movement Goal { get; } = goal;

    public int? Solve()
    {
        var aCount = 0;

        while (true)
        {
            if (CanBSolve())
            {
                var bCount = (Goal.X - GetX()) / ButtonB.X;
                return (aCount * 3) + bCount;
            }
            else
            {
                aCount++;
                var x = GetX();
                var y = GetY();
                if (x == Goal.X && y == Goal.Y)
                {
                    return aCount * 3;
                }

                if (x > Goal.X || y > Goal.Y)
                {
                    return null;
                }
            }
        }

        int GetX() => aCount * ButtonA.X;
        int GetY() => aCount * ButtonA.Y;
        bool CanBSolve()
        {
            var x = GetX();
            var xDelta = Goal.X - x;
            if (xDelta % ButtonB.X == 0)
            {
                var count = xDelta / ButtonB.X;
                var y = GetY();
                return y + (count * ButtonB.Y) == Goal.Y;
            }
            return false;
        }
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

    public static int GetTotal(string input)
    {
        var machines = ParseMachines(input);
        var total = 0;
        foreach (var machine in machines)
        {
            var result = machine.Solve();
            if (result is { } r)
            {
                total += r;
            }
        }

        return total;
    }
}
