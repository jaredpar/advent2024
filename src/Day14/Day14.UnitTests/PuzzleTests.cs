using Xunit;

namespace Day14.UnitTests;

public class PuzzleTests
{
    [Fact]
    public void Part1()
    {
        Assert.Equal(12, Puzzle.ScoreQuadrants(Input.Test, rows: 7, columns: 11));
        Assert.Equal(209409792, Puzzle.ScoreQuadrants(Input.Real, rows: 103, columns: 101));
    }

}
