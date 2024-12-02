using Xunit;

namespace Day02.UnitTests;

public class PuzzleTests
{
    [Theory]
    [InlineData(new int[] { 1, 2, 3}, true)]
    [InlineData(new int[] { 3, 2, 3}, false)]
    [InlineData(new int[] { 1, 2, 10}, false)]
    [InlineData(new int[] { 3, 2, 1}, true)]
    public void IsLevelSafe(int[] level, bool expected)
    {
        var actual = Puzzle.IsLevelSafe(level);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Part1()
    {
        Assert.Equal(2, Puzzle.CountSafe(Input.Test));
        Assert.Equal(321, Puzzle.CountSafe(Input.Real));
    }
}
