using Advent.Util;

namespace Day08;

public sealed class Puzzle
{
    public static int CountUniqueAntiNodes(string input)
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

            var e2 = grid.GetEnumerator();
            while (e2.MoveNext())
            {
                if (e2.Position == e1.Position || e1.Current != e2.Current)
                {
                    continue;
                }

                var diff = e1.Position - e2.Position;
                Mark(e1.Position + diff);
            }
        }

        return set.Count;

        void Mark(GridPosition position)
        {
            if (grid.IsValid(position))
            {
                var value  = grid.GetValue(position);
                if (value != '#')
                {
                    _ = set.Add(position);
                }
            }
        }

    }

}
