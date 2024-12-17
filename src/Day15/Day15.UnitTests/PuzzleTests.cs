using Xunit;

namespace Day15.UnitTests;

public class PuzzleTests
{
    [Fact]
    public void Part1()
    {
        Assert.Equal(1563092, Puzzle.Score(Input.Real));
    }

    [Fact]
    public void Part2()
    {
        Assert.Equal(1582688, Puzzle.ScoreBig(Input.Real));
    }
}
