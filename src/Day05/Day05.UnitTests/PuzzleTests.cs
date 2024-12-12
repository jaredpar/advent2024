using Xunit;

namespace Day05.UnitTests;

public class Class1
{
    [Fact]
    public void Part1()
    {
        Assert.Equal(143, Puzzle.SumOrderedPageMiddles(Input.Test));
        Assert.Equal(4959, Puzzle.SumOrderedPageMiddles(Input.Real));
    }

    [Fact]
    public void Part2()
    {
        Assert.Equal(123, Puzzle.SumUnorderedPageMiddles(Input.Test));
        Assert.Equal(4655, Puzzle.SumUnorderedPageMiddles(Input.Real));
    }
}
