using System.Runtime.InteropServices;
using Advent.Util;
using RulesMap = System.Collections.Generic.SortedDictionary<int, System.Collections.Generic.List<int>>;

namespace Day05;

public sealed class Puzzle
{
    public static (RulesMap Rules, List<List<int>> Updates) Parse(string input)
    {
        var e = input.SplitLines();
        var map = ParseDeps(ref e);
        var updates = ParseUpdates(ref e);
        return (map, updates);

        static RulesMap ParseDeps(ref LineSplitEnumerator e)
        {
            var map = new RulesMap();
            while (e.MoveNext())
            {
                if (e.Current.Length == 0)
                {
                    foreach (var v in map.Values)
                    {
                        v.Sort();
                    }

                    return map;
                }

                var index = e.Current.IndexOf('|');
                var num = int.Parse(e.Current.Slice(0, index));
                var dep = int.Parse(e.Current.Slice(index + 1));
                if (!map.TryGetValue(num, out var list))
                {
                    list = new();
                    map[num] = list;
                }

                list.Add(dep);
            }

            throw new Exception("Invalid input");
        }

        static List<List<int>> ParseUpdates(ref LineSplitEnumerator e)
        {
            var all = new List<List<int>>();
            while (e.MoveNext())
            {
                var current = e.Current;
                var list = new List<int>();
                while (true)
                {
                    var index = current.IndexOf(',');
                    if (index < 0)
                    {
                        list.Add(int.Parse(current));
                        break;
                    }
                    else
                    {
                        list.Add(int.Parse(current[0..index]));
                        current = current[(index+1)..];
                    }
                }
                all.Add(list);
            }

            return all;
        }
    }

    public static bool IsOrdered(RulesMap map, List<int> updates)
    {
        for (int i = 0; i + 1 < updates.Count; i++)
        {
            var left = updates[i];
            for (int k = i + 1; k < updates.Count; k++)
            {
                var num = updates[k];
                if (IsLeftBeforeRight(map, left, num) != true)
                {
                    return false;
                }
            }
        }

        return true;
    }

    public static int SumOrderedPageMiddles(string input)
    {
        var (map, updates) = Parse(input);
        var sum = 0;
        foreach (var update in updates)
        {
            if (IsOrdered(map, update))
            {
                var middle = update.Count / 2;
                sum += update[middle];
            }
        }

        return sum;
    }

    public static int SumUnorderedPageMiddles(string input)
    {
        var (map, updates) = Parse(input);
        var sum = 0;
        foreach (var update in updates)
        {
            if (!IsOrdered(map, update))
            {
                SortUpdate(map, update);
                var middle = update.Count / 2;
                sum += update[middle];
            }
        }

        return sum;
    }

    public static void SortUpdate(RulesMap map, List<int> update)
    {
        Span<int> span = CollectionsMarshal.AsSpan(update);
        while (span.Length > 1)
        {
            var smallestIndex = 0;
            var currentIndex = 1;
            while (currentIndex != smallestIndex)
            {
                if (!IsLeftBeforeRight(map, span[smallestIndex], span[currentIndex]))
                {
                    smallestIndex = currentIndex;
                }

                nextIndex(ref currentIndex, span.Length);
            }

            Swap(span, 0, smallestIndex);
            span = span[1..];
        }

        void nextIndex(ref int index, int length)
        {
            index++;
            if (index == length)
            {
                index = 0;
            }
        }

        static void Swap(Span<int> span, int x, int y)
        {
            var value = span[x];
            span[x] = span[y];
            span[y] = value;
        }
    } 

    private static bool IsLeftBeforeRight(RulesMap map, int left, int right)
    {
        if (!map.TryGetValue(left, out var list))
        {
            return false;
        }

        return list.BinarySearch(right) >= 0;
    }
}
