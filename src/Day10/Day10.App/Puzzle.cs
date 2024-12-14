using System.Diagnostics;
using Advent.Util;

namespace Day10;

public sealed class Puzzle
{
    public static int Score(string input)
    {
        var map = Grid.ParseInts(input);
        var set = new HashSet<GridPosition>();
        var sum = 0;
        var e = map.GetEnumerator();
        while (e.MoveNext())
        {
            if (e.Current != 0)
            {
                continue;
            }

            set.Clear();
            Trace(0, e.Position, set);
            sum += set.Count;
        }

        return sum;

        void Trace(int expected, GridPosition position, HashSet<GridPosition> set)
        {
            if (!map.IsValid(position) || map[position] != expected)
            {
                return;
            }

            if (expected == 9)
            {
                _ = set.Add(position);
                return;
            }

            var next = expected + 1;
            foreach (var dir in Grid.StraightDirections)
            {
                Trace(next, position.Move(dir), set);
            }
        }
    }
}
