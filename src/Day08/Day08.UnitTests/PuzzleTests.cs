using Xunit;

namespace Day08.UnitTests;

public class PuzzleTests
{
    [Fact]
    public void Part1()
    {
        Assert.Equal(14, Puzzle.CountUniqueAntiNodes(Input.Test));
        Assert.Equal(244, Puzzle.CountUniqueAntiNodes(Input.Real));
    }

}
