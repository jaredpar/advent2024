using Xunit;

namespace Day13.UnitTests;

public class PuzzleTests
{
    [Fact]
    public void Part1()
    {
        Assert.Equal(480, Puzzle.GetTotal(Input.Test));
        Assert.Equal(29023, Puzzle.GetTotal(Input.Real));
    }

    [Fact]
    public void Part2()
    {
        Assert.Equal(96787395375634, Puzzle.GetTotal(Input.Real, hard: true));  
    }
}
