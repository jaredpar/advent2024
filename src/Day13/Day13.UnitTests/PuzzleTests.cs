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
}
