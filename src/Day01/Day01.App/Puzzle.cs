using System.Diagnostics;
using Advent.Util;

namespace Day01;

public sealed class Puzzle
{
    public static (List<int>, List<int>) Parse(string input)
    {
        var left = new List<int>();
        var right = new List<int>();
        var e = input.SplitLines();
        Span<Range> rangeSpan = stackalloc Range[2];
        while (e.MoveNext())
        {
            var current = e.Current;
            var count = current.Split(rangeSpan, [' '], StringSplitOptions.RemoveEmptyEntries);
            if (count != 2)
            {
                throw new InvalidOperationException();
            }

            left.InsertSorted(int.Parse(current[rangeSpan[0]]));
            right.InsertSorted(int.Parse(current[rangeSpan[1]]));
        }
        return (left, right);
    }

    public static int GetDistance(string input)
    {
        var distance = 0;
        var (left, right) = Parse(input);
        for (int i = 0; i < left.Count; i++)
        {
            distance += Math.Abs(left[i] - right[i]);
        }
        return distance;
    }

    public static int GetSimilarity(string input)
    {
        var (left, right) = Parse(input);
        var total = 0;
        foreach (var value in left)
        {
            var count = GetRightCount(value);
            total += value * count;
        }

        return total;

        int GetRightCount(int value)
        {
            var index = right.BinarySearch(value);
            if (index < 0)
            {
                return 0;
            }

            // In the case of multiple values it can return any of the indexes
            // so we need to orient on one of them. Picking first:
            while (index - 1 >= 0 && right[index - 1] == value)
            {
                index--;
            }

            var count = 0;
            while (index < right.Count && right[index] == value)
            {
                count++;
                index++;
            }

            return count;
        }

    }
}