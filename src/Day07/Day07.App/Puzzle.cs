using System.Buffers;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
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

    public static long SumGoodEquations(string input, bool useConcat = false)
    {
        var equations = Parse(input);
        return equations
            .Where(x => CheckEquation(x, useConcat))
            .Sum(x => x.Test);
    }

    public static bool CheckEquation(Equation equation, bool useConcat)
    {
        var values = CollectionsMarshal.AsSpan(equation.Values);
        return 
            values.Length > 0 &&
            CheckCore(values[0], values[1..]);

        bool CheckCore(long total, Span<long> values)
        {
            if (values.Length == 0)
            {
                return total == equation.Test;
            }

            var next = values[0];
            values = values[1..];
            return
                CheckCore(total + next, values) ||
                CheckCore(total * next, values) ||
                (useConcat && CheckCore(Concat(total, next), values));
        }
    }

    public static long Concat(long left, long right)
    {
        var shift = (long)Math.Pow(10, CountDigits(right));
        return (left * shift) + right;

        static long CountDigits(long number)
        {
            if (number == 0) return 1;
            return (int)Math.Floor(Math.Log10(Math.Abs(number)) + 1);
        }
    }
}
