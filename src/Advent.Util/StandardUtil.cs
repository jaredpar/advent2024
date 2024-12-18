
using System.Diagnostics.CodeAnalysis;

namespace Advent.Util;

public static class StandardUtil
{
    public static void Require([DoesNotReturnIf(false)] bool condition)
    {
        if (!condition)
        {
            throw new InvalidOperationException();
        }
    }

    public static Exception InvalidValue()
    {
        return new InvalidOperationException($"Invalid value");
    }

    public static Exception InvalidValue<T>(T value)
    {
        return new InvalidOperationException($"Invalid value: {value}");
    }

    public static long CountDigits(long number)
    {
        if (number == 0) return 1;
        return (int)Math.Floor(Math.Log10(Math.Abs(number)) + 1);
    }

    public static long CountDigits(int number)
    {
        if (number == 0) return 1;
        return (int)Math.Floor(Math.Log10(Math.Abs(number)) + 1);
    }

    public static int ParseInt(ref ReadOnlySpan<char> line, char end)
    {
        var index = line.IndexOf(end);
        Require(index > 0);
        var value = int.Parse(line[..index]);
        line = line[(index + 1)..];
        return value;
    }

    public static int ParseInt(ref ReadOnlySpan<char> line, char start, char? end)
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
}