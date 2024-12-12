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
                if (IsOrdered(map, left, num) != true)
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

    private static bool? IsOrdered(RulesMap map, int left, int right)
    {
        if (!map.TryGetValue(left, out var list))
        {
            return false;
        }

        return list.BinarySearch(right) >= 0;
    }

    private static bool IsAfter(RulesMap map, int num, int afterTest)
    {
        if (!map.TryGetValue(num, out var list))
        {
            return false;
        }

        return list.BinarySearch(afterTest) >= 0;
    }
}
