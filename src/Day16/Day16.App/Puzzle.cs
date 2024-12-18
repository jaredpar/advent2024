using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Advent.Util;
using static Advent.Util.StandardUtil;

namespace Day16;

public static class Puzzle
{
    public static (GridPosition Start, GridPosition End, Grid<char> Grid) Parse(string input)
    {
        var grid = Grid.Parse(input);
        GridPosition? start = null;
        GridPosition? end = null;

        var e = grid.GetEnumerator();
        while (e.MoveNext())
        {
            if (e.Current == 'S')
            {
                grid[e.Position] = '.';
                start = e.Position;
            }
            else if (e.Current == 'E')
            {
                grid[e.Position] = '.';
                end = e.Position;
            }
        }

        Require(start is not null && end is not null);
        return (start.Value, end.Value, grid);
    }

    public static int ShortestPath(string input)
    {
        var (start, end, grid) = Parse(input);
        PriorityQueue<(GridPosition Position, GridDirection Facing), int> toVisit = new();
        HashSet<(GridPosition, GridDirection)> visited = new();

        toVisit.Enqueue((start, GridDirection.Right), 0);
        while (toVisit.TryDequeue(out var tuple, out var weight))
        {
            var (position, dir) = tuple;
            if (!visited.Add(tuple))
            {
                continue;
            }

            if (position == end)
            {
                return weight;
            }

            Add(dir, 1);
            Add(RotateRight(dir), 1001);
            Add(RotateLeft(dir), 1001);
            Add(RotateTwice(dir), 2001);

            void Add(GridDirection dir, int score)
            {
                var next = position.Move(dir);
                if (grid[next] != '#')
                {
                    toVisit.Enqueue((next, dir), weight + score);
                }
            }
        }

        throw new InvalidOperationException();
    }

    private static GridDirection RotateLeft(GridDirection dir) => dir switch
    {
        GridDirection.Up => GridDirection.Left,
        GridDirection.Left => GridDirection.Down,
        GridDirection.Down => GridDirection.Right,
        GridDirection.Right => GridDirection.Up,
        _ => throw InvalidValue(dir)
    };

    private static GridDirection RotateRight(GridDirection dir) => dir switch
    {
        GridDirection.Up => GridDirection.Right,
        GridDirection.Right => GridDirection.Down,
        GridDirection.Down => GridDirection.Left,
        GridDirection.Left => GridDirection.Up,
        _ => throw InvalidValue(dir)
    };

    private static GridDirection RotateTwice(GridDirection dir) => RotateRight(RotateRight(dir));
}
