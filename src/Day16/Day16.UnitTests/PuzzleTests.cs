using Xunit;

namespace Day16.UnitTests;

public class Class1
{
    [Fact]
    public void Part2()
    {
        Assert.Equal(631, Puzzle.CountShortestPathTiles(Input.Real));
    }
}
