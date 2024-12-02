using Xunit;

namespace Day02.UnitTests;

public class PuzzleTests
{
    [Theory]
    [InlineData(new int[] { 1, 2, 3}, false, true)]
    [InlineData(new int[] { 3, 2, 3}, false, false)]
    [InlineData(new int[] { 1, 2, 10}, false, false)]
    [InlineData(new int[] { 3, 2, 1}, false, true)]
    [InlineData(new int[] { 1, 2, 3}, true, true)]
    [InlineData(new int[] { 3, 2, 3}, true, true)]
    [InlineData(new int[] { 1, 2, 10}, true, true)]
    [InlineData(new int[] { 1, 1, 2, 3}, true, true)]
    [InlineData(new int[] { 1, 1, 2, 10}, true, false)]
    [InlineData(new int[] { 1, 3, 6, 7, 9 }, false, true)]
    [InlineData(new int[] { 1, 2, 7, 8, 9 }, true, false)]
    public void AreReadingsSafe(int[] readings, bool dampner, bool expected)
    {
        Assert.Equal(expected, Puzzle.AreReadingsSafe(readings, dampner));
        if (!dampner)
        {
            Assert.Equal(expected, Puzzle.AreReadingsSafe(readings, dampner: false));
        }
    }

    [Theory]
    [InlineData("79 83 81 84 86", true, true)]
    [InlineData("10 16 13 15 16 19", true, true)]
    [InlineData("50 52 50 53 56", true, true)]
    [InlineData("48 46 47 49 51 54 56", true, true)]
    [InlineData("79 76 74 73 70 73", true, false)]
    public void AreReadingsSafe2(string input, bool dampner, bool expected)
    {
        var readings = Puzzle.ParseReadings(input);
        Assert.Equal(expected, Puzzle.AreReadingsSafe(readings, dampner));
        if (!dampner)
        {
            Assert.Equal(expected, Puzzle.AreReadingsSafe(readings, dampner: false));
        }
    }

    [Fact]
    public void Part1()
    {
        Assert.Equal(2, Puzzle.CountSafe(Input.Test));
        Assert.Equal(321, Puzzle.CountSafe(Input.Real));
    }

    [Fact]
    public void Part2()
    {
        Assert.Equal(4, Puzzle.CountSafe(Input.Test, dampner: true));
        Assert.Equal(321, Puzzle.CountSafe(Input.Real, dampner: true));
    }
}
