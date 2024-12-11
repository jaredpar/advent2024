using Xunit;

namespace Day04.UnitTests;

public class PuzzleTests
{
    [Fact]
    public void Part1()
    {
        Assert.Equal(4, Puzzle.CountXmas(Input.Simple));
        Assert.Equal(18, Puzzle.CountXmas(Input.Test));
        Assert.Equal(2545, Puzzle.CountXmas(Input.Test));
    }

    [Fact]
    public void Part2()
    {
        Assert.Equal(9, Puzzle.CountXShapeMas(Input.Test));
    }
}
