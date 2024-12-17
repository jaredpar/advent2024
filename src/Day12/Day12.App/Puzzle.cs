using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using Advent.Util;

namespace Day12;

public static class Puzzle
{
    public static int GetRegions(string input, Func<Grid<char>, Span<GridPosition>, int> func)
    {
        var grid = Grid.Parse(input);
        var visited = new HashSet<GridPosition>();
        var e = grid.GetEnumerator();
        var total = 0;
        while (e.MoveNext())
        {
            var current = e.Position;
            if (!visited.Add(current))
            {
                continue;
            }

            var region = GetRegion(current);
            var result = func(grid, CollectionsMarshal.AsSpan(region));
            total += result;
        }

        return total;

        List<GridPosition> GetRegion(GridPosition position)
        {
            var c = grid[position];
            var region = new List<GridPosition>()
            {
                position
            };

            var toVisit = new Queue<GridPosition>();
            EnqueueNeighbors(position);
            while (toVisit.Count > 0)
            {
                var current = toVisit.Dequeue();
                if (!grid.IsValid(current) || grid[current] != c || !visited.Add(current))
                {
                    continue;
                }

                region.Add(current);
                EnqueueNeighbors(current);
            }

            return region;

            void EnqueueNeighbors(GridPosition pos)
            {
                foreach (var dir in Grid.StraightDirections)
                {
                    toVisit.Enqueue(pos.Move(dir));
                }
            }
        }
    }

    public static int GetPrice(string input)
    {
        return GetRegions(input, GetReginPrice);

        static int GetReginPrice(Grid<char> grid, Span<GridPosition> region)
        {
            var perimeter = GetPerimiter(grid, region);
            return perimeter * region.Length;
        }
    }

    public static int GetPerimiter(Grid<char> grid, Span<GridPosition> positions)
    {
        var perimiter = 0;
        foreach (var position in positions)
        {
            perimiter += GetPerimiter(grid, position);
        }

        return perimiter;
    }

    public static int GetPerimiter(Grid<char> grid, GridPosition position)
    {
        var c = grid[position];
        var count = 0;
        foreach (var dir in Grid.StraightDirections)
        {
            var current = position.Move(dir);
            if (!grid.IsValid(current) || grid[current] != c)
            {
                count++;
            }
        }

        return count;
    }
}
