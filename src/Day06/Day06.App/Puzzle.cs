using System.Globalization;
using System.Net;
using Advent.Util;

namespace Day06;

public sealed class Puzzle
{
    public static int CountDistinctSteps(string input)
    {
        var grid = Grid.Parse(input);

        var direction = GridDirection.Up;
        var guardPosition = FindGuard();
        var count = 1;
        do
        {
            var next = guardPosition.Move(direction);
            if (!grid.IsValid(next))
            {
                return count;
            }

            ref var value = ref grid.GetValue(next);
            if (value == '.' || value == 'X')
            {
                if (value == '.')
                    count++;
                value = '^';
                grid.GetValue(guardPosition) = 'X';
                guardPosition = next;
            }
            else if (value == '#')
            {
                direction = Rotate(direction);
            }
        } while (true);

        GridDirection Rotate(GridDirection dir) => dir switch
        {
            GridDirection.Up => GridDirection.Right,
            GridDirection.Right => GridDirection.Down,
            GridDirection.Down => GridDirection.Left,
            GridDirection.Left => GridDirection.Up,
            _ => throw new InvalidOperationException()
        };

        GridPosition FindGuard()
        {
            var e = grid.GetEnumerator();
            while (e.MoveNext())
            {
                if (e.Current == '^')
                {
                    return e.Position;
                }
            }

            throw new InvalidOperationException();
        }
    }

}
