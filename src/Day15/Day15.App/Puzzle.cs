using System.Diagnostics;
using Advent.Util;

namespace Day15;

public static class Puzzle
{
    public static (Grid<char> Grid, GridPosition Robot, List<GridDirection> Moves) Parse(string input)
    {
        var rows = CountRows(input);
        var e = input.SplitLines();
        StandardUtil.Require(e.MoveNext());
        var grid = new Grid<char>(rows, e.Current.Length);
        GridPosition robot = default;
        var r = 0;
        do
        {
            var current = e.Current;
            for (int c = 0; c < current.Length; c++)
            {
                grid[r, c] = current[c];
                if (current[c] == '@')
                {
                    robot = new GridPosition(r, c);
                }
            }

            r++;
            StandardUtil.Require(e.MoveNext());
        } while (e.Current.Length > 0);

        var moves = new List<GridDirection>();
        while (e.MoveNext())
        {
            foreach (var c in e.Current)
            {
                var dir = c switch
                {
                    '^' => GridDirection.Up,
                    'v' => GridDirection.Down,
                    '<' => GridDirection.Left,
                    '>' => GridDirection.Right,
                    _ => throw new InvalidOperationException()
                };

                moves.Add(dir);
            }
        }

        return (grid, robot, moves);

        int CountRows(string input)
        {
            var count = 0;
            var e = input.SplitLines();
            while (e.MoveNext())
            {
                if (e.Current.Length == 0)
                {
                    break;
                }
                count++;
            }

            return count;
        }
    }

    public static int Score(string input)
    {
        var (grid, robot, moves) = Parse(input);
        Execute(grid, robot, moves);
        // Console.WriteLine(grid.RenderAsString());

        var score = 0;
        var e = grid.GetEnumerator();
        while (e.MoveNext())
        {
            if (e.Current == 'O')
            {
                var i = (100 * e.Row) + e.Column;
                score += i;
            }
        }

        return score;
    }

    public static void Execute(Grid<char> grid, GridPosition robot, List<GridDirection> moves)
    {
        Debug.Assert(grid[robot] == '@');
        foreach (var move in moves)
        {
            if (CanMove(move))
            {
                Move(move);
            }
            // Console.WriteLine(grid.RenderAsString());
        }

        void Move(GridDirection dir)
        {
            // Push all the boxes
            var newRobot = robot.Move(dir);
            if (grid[newRobot] is 'O')
            {
                var lastBox = newRobot;
                do
                {
                    var next = lastBox.Move(dir);
                    ref var value = ref grid[next];
                    if (value == '.')
                    {
                        value = 'O';
                        break;
                    }

                    lastBox = next;
                    next = next.Move(dir);
                } while (true);
            }

            grid[robot] = '.';
            grid[newRobot] = '@';
            robot = newRobot;
        }

        bool CanMove(GridDirection dir)
        {
            var current = robot;
            do
            {
                current = current.Move(dir);
                var c = grid[current];
                if (c == '.')
                {
                    return true;
                }

                if (c == '#')
                {
                    return false;
                }
            } while (true);
        }
    }
}
