using Xunit;

namespace Day06.UnitTests;

public class PuzzleTests
{
    [Fact]
    public void Part1()
    {
        Assert.Equal(41, Puzzle.CountDistinctSteps(Input.Test));
        Assert.Equal(4656, Puzzle.CountDistinctSteps(Input.Real));
    }

    [Fact]
    public void Part2()
    {
        Assert.Equal(6, Puzzle.CountLoops(Input.Test));
        Assert.Equal(1575, Puzzle.CountLoops(Input.Real));
    }
}
