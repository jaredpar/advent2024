global using Robot = (Advent.Util.GridPosition Position, Advent.Util.GridPosition Velocity);
using Advent.Util;

namespace Day14;

public static class Puzzle
{
    public static Robot[] Parse(string input)
    {
        var array = new Robot[input.CountLines()];
        var index = 0;
        var e = input.SplitLines();
        while (e.MoveNext())
        {
            array[index] = ParseRobot(e.Current);
            index++;
        }
        return array;
    }

    public static int ScoreQuadrants(string input, int rows, int columns)
    {
        var robots = Parse(input);
        Execute(robots, rows, columns, times: 100);

        var midRow = rows / 2;
        var midColumn = columns / 2;
        Span<int> quadrants = stackalloc int[4];

        foreach (var robot in robots)
        {
            if (robot.Position.Row == midRow || robot.Position.Column == midColumn)
            {
                continue;
            }

            GetQuadrant(quadrants, robot.Position)++;
        }

        var total = quadrants[0];
        for (int i = 1; i < quadrants.Length; i++)
        {
            total *= quadrants[i];
        }

        return total;

        ref int GetQuadrant(Span<int> quadrants, GridPosition position)
        {
            var index = (position.Row < midRow, position.Column < midColumn) switch
            {
                (true, true) => 0,
                (true, false) => 1,
                (false, true) => 2,
                (false, false) => 3,
            };

            return ref quadrants[index];
        }
    }

    public static int SecondsTillEasterEgg(string input, int rows, int columns)
    {
        var robots = Parse(input);
        var seconds = 0;
        var set = new HashSet<GridPosition>();
        while (true)
        {
            Execute(robots, rows, columns);
            seconds++;

            var overlap = false;
            set.Clear();
            foreach (var robot in robots)
            {
                if (!set.Add(robot.Position))
                {
                    overlap = true;
                    break;
                }
            }

            if (!overlap)
            {
                // Second time there was a Christmas tree
                Console.WriteLine(RenderAsString(robots, rows, columns));
            }
        }
    }

    public static string RenderAsString(Robot[] robots, int rows, int columns)
    {
        var grid = new Grid<int>(rows, columns);
        foreach (var robot in robots)
        {
            grid[robot.Position]++;
        }

        return grid.RenderAsString((b, i) =>
        {
            if (i > 0)
            {
                b.Append(i);
            }
            else
            {
                b.Append('.');
            }
        });
    }

    public static void Execute(Robot[] robots, int rows, int columns, int times = 1)
    {
        for (int i = 0; i < robots.Length; i++)
        {
            ref var robot = ref robots[i];
            for (int t = 0; t < times; t++)
            {
                Move(ref robot, rows, columns);
            }
        }
    }

    public static void Move(ref Robot robot, int rows, int columns)
    {
        var r = robot.Position.Row + robot.Velocity.Row;
        var c = robot.Position.Column + robot.Velocity.Column;
        if (r >= rows)
        {
            r = r - rows;
        }

        if (r < 0)
        {
            r = rows + r;
        }

        if (c >= columns)
        {
            c = c - columns;
        }

        if (c < 0)
        {
            c = columns + c;
        }

        robot.Position = new(r, c);
    }

    public static Robot ParseRobot(ReadOnlySpan<char> line)
    {
        var pCol = StandardUtil.ParseInt(ref line, start: '=', end: ',');
        var pRow = StandardUtil.ParseInt(ref line, end: ' ');
        var vCol = StandardUtil.ParseInt(ref line, start: '=', end: ',');
        var vRow = int.Parse(line);

        return (new GridPosition(pRow, pCol), new GridPosition(vRow, vCol));
    }
}
