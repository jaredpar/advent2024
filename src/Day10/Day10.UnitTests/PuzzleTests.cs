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

    [Fact]
    public void Part2()
    {
        Assert.Equal(81, Puzzle.Score(Input.Test));
        Assert.Equal(1344, Puzzle.Score(Input.Real));
    }
}
