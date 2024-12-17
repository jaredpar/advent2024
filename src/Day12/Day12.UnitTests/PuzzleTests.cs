using Xunit;

namespace Day12.UnitTests;

public class PuzzleTests
{
    [Fact]
    public void Part1()
    {
        Assert.Equal(140, Puzzle.GetPrice(Input.Test));
        Assert.Equal(1930, Puzzle.GetPrice(Input.Test2));
        Assert.Equal(1533644, Puzzle.GetPrice(Input.Real));
    }
}
