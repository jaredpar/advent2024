using Xunit;

namespace Day11.UnitTests;

public class PuzzleTests
{
    [Theory]
    [InlineData("0 1 10 99 999", 1, "1 2024 1 0 9 9 2021976")]
    [InlineData("125 17", 1, "253000 1 7")]
    [InlineData("125 17", 3, "512072 1 20 24 28676032")]
    [InlineData("125 17", 6, "2097446912 14168 4048 2 0 2 4 40 48 2024 40 48 80 96 2 8 6 7 6 0 3 2")]
    public void Simple(string input, int count, string expected)
    {
        var list = Puzzle.Parse(input);
        for (int i = 0; i < count; i++)
        {
            Puzzle.Run(list);
        }
        
        var actual = Puzzle.AsString(list);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("125 17", 6, 22)]
    [InlineData("125 17", 25, 55312)]
    [InlineData(Input.Real, 25, 193899)]
    public void Part1(string input, int count, int expected)
    {
        var actual = Puzzle.Blink(input, count);
        Assert.Equal(expected, actual);
    }
}
