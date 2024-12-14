using Xunit;

namespace Day10.UnitTests;

public class PuzzleTests
{
    [Fact]
    public void Part1()
    {
        Assert.Equal(36, Puzzle.Score(Input.Test));
        Assert.Equal(667, Puzzle.Score(Input.Real));
    }

}
