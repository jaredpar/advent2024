using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Advent.Util;
using Microsoft.VisualBasic;

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

    public static long RunNew(string input, int count)
    {
        var list = Parse(input);
        var map = CreateMap(list);
        var newMap = new Dictionary<long, long>();
        for (int i = 0; i < count; i++)
        {
            newMap.Clear();
            foreach (var kvp in map)
            {
                var stone = kvp.Key;
                if (stone == 0)
                {
                    IncrementMap(newMap, 1, kvp.Value);
                }
                else if (
                    StandardUtil.CountDigits(stone) is { } digits &&
                    digits % 2 == 0)
                {
                    var mod = (long)Math.Pow(10, digits / 2);
                    var rightValue = stone % mod;
                    var leftValue = (stone - rightValue) / mod;
                    IncrementMap(newMap, leftValue, kvp.Value);
                    IncrementMap(newMap, rightValue, kvp.Value);
                }
                else
                {
                    IncrementMap(newMap, stone * 2024, kvp.Value);
                }
            }

            var temp = map;
            map = newMap;
            newMap = temp;
            newMap.Clear();
        }

        return map.Sum(x => x.Value);

        static Dictionary<long, long> CreateMap(LinkedList<long> list)
        {
            var map = new Dictionary<long, long>();
            foreach (var value in list)
            {
                IncrementMap(map, value, 1);
            }

            return map;
        }

        static void IncrementMap(Dictionary<long, long> map, long key, long increment)
        {
            ref var value = ref CollectionsMarshal.GetValueRefOrAddDefault(map, key, out _);
            value += increment;
        }
    }
}
