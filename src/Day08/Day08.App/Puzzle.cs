using Advent.Util;

namespace Day08;

public sealed class Puzzle
{
    public static int CountUniqueAntiNodes(string input, bool countAll = false)
    {
        var grid = Grid.Parse(input);
        var e1 = grid.GetEnumerator();
        var set = new HashSet<GridPosition>();
        while (e1.MoveNext())
        {
            if (!char.IsLetterOrDigit(e1.Current))
            {
                continue;
            }

            _ = set.Add(e1.Position);
            var e2 = grid.GetEnumerator();
            while (e2.MoveNext())
            {
                if (e2.Position == e1.Position || e1.Current != e2.Current)
                {
                    continue;
                }

                var diff = e1.Position - e2.Position;
                var current = e1.Position;
                do
                {
                    current += diff;
                    Mark(current);
                } while (countAll && grid.IsValid(current));
            }
        }

        return set.Count;

        void Mark(GridPosition position)
        {
            if (grid.IsValid(position))
            {
                var value  = grid[position];
                if (value != '#')
                {
                    _ = set.Add(position);
                }
            }
        }
    }
}
