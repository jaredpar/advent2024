using System.Globalization;
using System.Reflection;
using System.Text;
using Advent.Util;

namespace Day11;

public static class Puzzle
{
    public static LinkedList<long> Parse(string input)
    {
        var span = input.AsSpan();
        var list = new LinkedList<long>();
        while (span.Length > 0)
        {
            var index = span.IndexOf(' ');
            long value;
            if (index > 0)
            {
                value = long.Parse(span.Slice(0, index));
                span = span[(index+1)..];
            }
            else
            {
                value = long.Parse(span);
                span = "";
            }

            list.AddLast(value);
        }

        return list;
    }

    public static int Blink(string input, int times)
    {
        var list = Parse(input);
        for (int i = 0; i < times; i++)
        {
            Run(list);
        }

        return list.Count;
    }

    public static string AsString(LinkedList<long> list)
    {
        var builder = new StringBuilder();
        foreach (var node in list)
        {
            if (builder.Length != 0)
            {
                builder.Append(' ');
            }

            builder.Append(node);
        }

        return builder.ToString();
    }

    public static void Run(LinkedList<long> list)
    {
        var node = list.First;
        while (node is not null)
        {
            ref var value = ref node.ValueRef;
            if (value == 0)
            {
                value = 1;
            }
            else if (
                StandardUtil.CountDigits(value) is { } digits &&
                digits % 2 == 0)
            {
                var mod = (long)Math.Pow(10, digits / 2);
                var rightValue = value % mod;
                var leftValue = (value - rightValue) / mod;
                list.AddBefore(node, leftValue);
                value = rightValue;
            }
            else
            {
                value *= 2024;
            }

            node = node.Next;
        }
    }
}
