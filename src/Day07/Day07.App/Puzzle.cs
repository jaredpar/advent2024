using System.Buffers;
using System.Runtime.InteropServices;
using Advent.Util;

using Equation = (long Test, System.Collections.Generic.List<long> Values);

namespace Day07;

public sealed class Puzzle
{
    private static readonly SearchValues<char> s_separators = SearchValues.Create([' ', ':']);

    public static List<Equation> Parse(string input)
    {
        var e = input.SplitLines();
        var equations = new List<Equation>();
        while (e.MoveNext())
        {
            var current = e.Current;
            var items =  current.SplitAny(s_separators);
            if (!items.MoveNext())
            {
                throw new InvalidOperationException();
            }

            var test = long.Parse(current[items.Current]);
            var list = new List<long>();
            while (items.MoveNext())
            {
                var span = current[items.Current];
                if (span.Length == 0)
                {
                    continue;
                }

                list.Add(long.Parse(span));
            }

            equations.Add((test, list));
        }

        return equations;
    }

    public static long SumGoodEquations(string input)
    {
        var equations = Parse(input);
        return equations
            .Where(CheckEquation)
            .Sum(x => x.Test);
    }

    public static bool CheckEquation(Equation equation)
    {
        return CheckCore(
            equation.Test,
            equation.Values[0],
            CollectionsMarshal.AsSpan(equation.Values)[1..]);

        bool CheckCore(long test, long total, Span<long> values)
        {
            if (values.Length == 0)
            {
                return test == total;
            }

            if (total > test)
            {
                return false;
            }

            var value = values[0];
            values = values[1..];
            return 
                CheckCore(test, total + value, values) ||
                CheckCore(test, total * value, values);
        }
    }
}
