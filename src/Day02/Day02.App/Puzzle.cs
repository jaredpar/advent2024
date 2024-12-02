using System.ComponentModel.DataAnnotations.Schema;
using Advent.Util;

namespace Day02;

public sealed class Puzzle
{
    public static int[] ParseLevel(ReadOnlySpan<char> input)
    {
        var count = input.CountChars(' ') + 1;
        var level = new int[count];
        Span<Range> rangeSpan = stackalloc Range[count];
        var rangeCount = input.Split(rangeSpan, [' '], StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < count; i++)
        {
            var current = input[rangeSpan[i]];
            level[i] = int.Parse(current);
        }
        return level;
    }

    public static int CountSafe(string input)
    {
        var e = input.SplitLines();
        var count = 0;
        while (e.MoveNext())
        {
            var level = ParseLevel(e.Current);
            if (IsLevelSafe(level))
            {
                count++;
            }
        }
        return count;
    }

    public static bool IsLevelSafe(ReadOnlySpan<int> level)
    {
        var first = level[0];
        var second = level[1];
        if (first == second)
        {
            return false;
        }

        var increasing = first < second;
        for (int i = 1; i < level.Length; i++)
        {
            var prev = level[i - 1];
            var current = level[i];
            var diff = current - prev;
            if (Math.Abs(diff) is < 1 or > 3)
            {
                return false;
            }

            var c = (increasing, prev < current) switch 
            {
                (true, true) => true,
                (false, false) => true,
                _ => false
            };

            if (!c)
            {
                return false;
            }
        }

        return true;
    }
}
