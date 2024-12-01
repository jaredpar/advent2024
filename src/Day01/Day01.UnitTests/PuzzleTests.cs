using Xunit;

namespace Day01.UnitTests;

public sealed class PuzzleTests
{
    [Fact]
    public void Part1TestInput()
    {
        Assert.Equal(11, Puzzle.GetDistance(Input.Test));
    }

    [Fact]
    public void Part1RealInput()
    {
        Assert.Equal(2000468, Puzzle.GetDistance(Input.Real));
    }

    [Fact]
    public void Part2TestInput()
    {
        Assert.Equal(31, Puzzle.GetSimilarity(Input.Test));
    }
}
