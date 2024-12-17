using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Runtime.InteropServices;
using Advent.Util;

namespace Day06;

public sealed class Puzzle
{
    public static int CountDistinctSteps(string input)
    {
        var grid = Grid.Parse(input);

        var direction = GridDirection.Up;
        var guardPosition = FindGuard(grid);
        var count = 1;
        do
        {
            var next = guardPosition.Move(direction);
            if (!grid.IsValid(next))
            {
                return count;
            }

            ref var value = ref grid[next];
            if (value == '.' || value == 'X')
            {
                if (value == '.')
                    count++;
                value = '^';
                grid[guardPosition] = 'X';
                guardPosition = next;
            }
            else if (value == '#')
            {
                direction = Rotate(direction);
            }
        } while (true);

    }

    public static int CountLoops(string input)
    {
        var grid = Grid.Parse(input);
        var guardPosition = FindGuard(grid);
        var e = grid.GetEnumerator();
        var map = new Dictionary<GridPosition, int>();
        var count = 0;
        while (e.MoveNext())
        {
            ref var value = ref grid[e.Position];
            if (value == '^' || value == '#')
            {
                continue;
            }

            Debug.Assert(value == '.');
            value = '#';
            if (IsLoop(grid, guardPosition))
            {
                count++;
            }
            value = '.';
        }

        return count;

        bool IsLoop(Grid<char> grid, GridPosition guardPosition)
        {
            var direction = GridDirection.Up;
            var dirFlag = GetFlag(direction);

            map.Clear();
            map[guardPosition] = dirFlag;
            var current = guardPosition;
            do
            {
                var next = current.Move(direction);
                if (!grid.IsValid(next))
                {
                    return false;
                }

                if (grid[next] == '#')
                {
                    direction = Rotate(direction);
                    dirFlag = GetFlag(direction);
                    continue;
                }

                ref var flag = ref CollectionsMarshal.GetValueRefOrAddDefault(map, next, out _);
                if (dirFlag == (flag & dirFlag))
                {
                    return true;
                }

                flag |= dirFlag;
                current = next;
            } while (true);

            int GetFlag(GridDirection dir) => dir switch
            {
                GridDirection.Up => 0b0001,
                GridDirection.Right => 0b0010,
                GridDirection.Down => 0b0100,
                GridDirection.Left => 0b1000,
                _ => throw new InvalidOperationException()
            };
        }
    }

    private static GridDirection Rotate(GridDirection dir) => dir switch
    {
        GridDirection.Up => GridDirection.Right,
        GridDirection.Right => GridDirection.Down,
        GridDirection.Down => GridDirection.Left,
        GridDirection.Left => GridDirection.Up,
        _ => throw new InvalidOperationException()
    };

private static GridPosition FindGuard(Grid<char> grid)
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
