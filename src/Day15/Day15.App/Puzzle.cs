using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Schema;
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

        var moves = ParseMoves(ref e);
        return (grid, robot, moves);
    }

    private static int CountRows(string input)
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

    private static List<GridDirection> ParseMoves(ref LineSplitEnumerator e)
    {
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

        return moves;
    }

    public static (Grid<char> Grid, GridPosition Robot, List<GridDirection> Moves) ParseBig(string input)
    {
        var rows = CountRows(input);
        var e = input.SplitLines();
        StandardUtil.Require(e.MoveNext());
        var grid = new Grid<char>(rows, e.Current.Length * 2);
        GridPosition robot = default;
        var r = 0;
        do
        {
            var current = e.Current;
            for (int i = 0; i < current.Length; i++)
            {
                var c = i * 2;
                var value = current[i];
                switch (value)
                {
                    case '#':
                        grid[r, c] = '#';
                        grid[r, c + 1] = '#';
                        break;
                    case '.':
                        grid[r, c] = '.';
                        grid[r, c + 1] = '.';
                        break;
                    case 'O':
                        grid[r, c] = '[';
                        grid[r, c + 1] = ']';
                        break;
                    case '@':
                        grid[r, c] = '@';
                        grid[r, c + 1] = '.';
                        robot = new GridPosition(r, c);
                        break;
                }
            }

            r++;
            StandardUtil.Require(e.MoveNext());
        } while (e.Current.Length > 0);

        var moves = ParseMoves(ref e);
        return (grid, robot, moves);
    }

    public static int Score(string input)
    {
        var (grid, robot, moves) = Parse(input);
        Execute(grid, robot, moves);

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

    public static int ScoreBig(string input)
    {
        var (grid, robot, moves) = ParseBig(input);
        ExecuteBig(grid, robot, moves);
        // Console.WriteLine(grid.RenderAsString());

        var score = 0;
        var e = grid.GetEnumerator();
        while (e.MoveNext())
        {
            if (e.Current == '[')
            {
                var i = (100 * e.Row) + e.Column;
                score += i;
            }
        }

        return score;
    }

    public static void ExecuteBig(Grid<char> grid, GridPosition robot, List<GridDirection> moves)
    {
        Debug.Assert(grid[robot] == '@');
        foreach (var move in moves)
        {
            // Console.WriteLine(grid.RenderAsString());
            if (CanMove(robot, move))
            {
                Move(move);
            }
        }

        void Move(GridDirection dir)
        {
            var newPosition = robot.Move(dir);
            MaybeMoveBox(newPosition);
            grid[robot] = '.';
            grid[newPosition] = '@';
            robot = newPosition;

            void MoveBox(GridPosition position)
            {
                Debug.Assert(grid[position] == '[');
                GridPosition p1;
                GridPosition p2;
                switch (dir)
                {
                    case GridDirection.Up:
                        p1 = position.Move(GridDirection.Up);
                        p2 = position.Move(GridDirection.Right, GridDirection.Up);
                        MaybeMoveBox(p1);
                        MaybeMoveBox(p2);
                        break;
                    case GridDirection.Down:
                        p1 = position.Move(GridDirection.Down);
                        p2 = position.Move(GridDirection.Right, GridDirection.Down);
                        MaybeMoveBox(p1);
                        MaybeMoveBox(p2);
                        break;
                    case GridDirection.Left:
                        p2 = position;
                        p1 = position.Move(GridDirection.Left);
                        MaybeMoveBox(p1);
                        break;
                    case GridDirection.Right:
                        p1 = position.Move(GridDirection.Right);
                        p2 = p1.Move(GridDirection.Right);
                        MaybeMoveBox(p2);
                        break;
                    default:
                        throw StandardUtil.InvalidValue();
                }
                grid[position] = '.';
                grid[position.Move(GridDirection.Right)] = '.';
                grid[p1] = '[';
                grid[p2] = ']';
            }

            void MaybeMoveBox(GridPosition position)
            {
                var value = grid[position];
                if (value is '[' or ']')
                {
                    MoveBox(NormalizeBoxPosition(position));
                }
            }
        }

        GridPosition NormalizeBoxPosition(GridPosition position)
        {
            Debug.Assert(grid[position] is '[' or ']');
            return grid[position] == '[' ? position : position.Move(GridDirection.Left);
        }

        bool CanMove(GridPosition robot, GridDirection dir)
        {
            return IsMoveTarget(robot.Move(dir));

            bool CanBoxMove(GridPosition position, GridDirection dir)
            {
                Debug.Assert(grid[position] == '[');

                return dir switch
                {
                    GridDirection.Up => IsMoveTarget(position.Move(GridDirection.Up)) && IsMoveTarget(position.Move(GridDirection.Right, GridDirection.Up)),
                    GridDirection.Down => IsMoveTarget(position.Move(GridDirection.Down)) && IsMoveTarget(position.Move(GridDirection.Right, GridDirection.Down)),
                    GridDirection.Left => IsMoveTarget(position.Move(GridDirection.Left)),
                    GridDirection.Right => IsMoveTarget(position.Move(GridDirection.Right, GridDirection.Right)),
                    _ => throw StandardUtil.InvalidValue(),
                };

            }

            bool IsMoveTarget(GridPosition position) => grid[position] switch
            {
                '.' => true,
                '#' => false,
                '[' or ']' => CanBoxMove(NormalizeBoxPosition(position), dir),
                _ => throw StandardUtil.InvalidValue(),
            };
        }
    }
}
