using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Advent.Util;
using static Advent.Util.StandardUtil;

namespace Day16;

public static class Puzzle
{
    public sealed class GridPath(GridPosition position, GridDirection direction, int cost, GridPath? before)
    {
        public GridPosition GridPosition { get; } = position;
        public GridDirection GridDirection { get; } = direction;
        public int Cost { get; } = cost;
        public GridPath? Before { get; } = before;
    }

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

    public static void PrintShortestPaths(string input)
    {
        var (start, end, grid) = Parse(input);
        var list = AllShortestPaths(grid, start, end);
        foreach (var gridPath in list)
        {
            var current = gridPath;
            while (current is not null)
            {
                grid[current.GridPosition] = 'O';
                current = current.Before;
            }
        }

        Console.WriteLine(grid.RenderAsString());
    }

    public static int CountShortestPathTiles(string input)
    {
        var (start, end, grid) = Parse(input);
        var list = AllShortestPaths(grid, start, end);
        var set = new HashSet<GridPosition>();
        foreach (var gridPath in list)
        {
            var current = gridPath;
            while (current is not null)
            {
                _ = set.Add(current.GridPosition);
                current = current.Before;
            }
        }
        return set.Count;
    }

    public static List<GridPath> AllShortestPaths(Grid<char> grid, GridPosition start, GridPosition end)
    {
        PriorityQueue<GridPath, int> toVisit = new();
        Dictionary<(GridPosition, GridDirection), int> visited = new();
        var list = new List<GridPath>();

        toVisit.Enqueue(new (start, GridDirection.Right, 0, null), 0);
        while (toVisit.TryDequeue(out var gridPath, out var weight))
        {
            if (visited.TryGetValue((gridPath.GridPosition, gridPath.GridDirection), out var existing))
            {
                if (existing < weight)
                    continue;
            }
            else
            {
                visited[(gridPath.GridPosition, gridPath.GridDirection)] = weight;
            }

            var position = gridPath.GridPosition;
            if (position == end)
            {
                switch (list.Count)
                {
                    case 0:
                        list.Add(gridPath);
                        break;
                    case > 0 when weight < list[0].Cost:
                        list.Clear();
                        list.Add(gridPath);
                        break;
                    case > 0 when weight == list[0].Cost:
                        list.Add(gridPath);
                        break;
                }
                continue;
            }

            var dir = gridPath.GridDirection;
            Add(dir, 1);
            Add(RotateRight(dir), 1001);
            Add(RotateLeft(dir), 1001);
            Add(RotateTwice(dir), 2001);

            void Add(GridDirection dir, int score)
            {
                var next = position.Move(dir);
                if (grid[next] != '#')
                {
                    var cost = weight + score;
                    toVisit.Enqueue(new (next, dir, cost, gridPath), cost);
                }
            }
        }

        return list;
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
