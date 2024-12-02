using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using Advent.Util;

namespace Day02;

public sealed class Puzzle
{
    public static int[] ParseReadings(ReadOnlySpan<char> input)
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

    public static int CountSafe(string input, bool dampner = false)
    {
        var e = input.SplitLines();
        var count = 0;
        while (e.MoveNext())
        {
            var readings = ParseReadings(e.Current);
            if (AreReadingsSafe(readings, dampner))
            {
                count++;
            }
        }
        return count;
    }

    public static bool AreReadingsSafe(ReadOnlySpan<int> readings, bool dampner)
    {
        if (Core(readings, dampner))
        {
            return true;
        }

        if (dampner && 
            readings.Length > 2 &&
            Core(readings[1..], dampner: false))
        {
            return true;
        }

        return false;

        static bool Core(ReadOnlySpan<int> readings, bool dampner)
        {
            var first = readings[0];
            var second = readings[1];
            if (first == second)
            {
                return false;
            }

            var increasing = first < second;
            var prev = first;
            var removedReading = false;
            for (int i = 1; i < readings.Length; i++)
            {
                var current = readings[i];
                var diffSafe  = Math.Abs(current - prev) is > 0 and < 4;
                var incSafe = (increasing, prev < current) switch 
                {
                    (true, true) => true,
                    (false, false) => true,
                    _ => false
                };

                if (!diffSafe || !incSafe)
                {
                    if (!dampner || removedReading)
                    {
                        return false;
                    }

                    removedReading = true;
                }
                else
                {
                    prev = current;
                }

            }

            return true;
        }
    }
}
