using Xunit;

namespace Day15.UnitTests;

public class PuzzleTests
{
    [Fact]
    public void Part1()
    {
        Assert.Equal(1563092, Puzzle.Score(Input.Real));
    }
}
