using Xunit;

namespace Day07.UnitTests;

public class PuzzleTests
{
    [Theory]
    [InlineData(1, 2, 12)]
    [InlineData(1, 24, 124)]
    public void Concat(long left, long right, long expected)
    {
        Assert.Equal(expected, Puzzle.Concat(left, right));
    }

    [Fact]
    public void Part1()
    {
        Assert.Equal(3749, Puzzle.SumGoodEquations(Input.Test));
        Assert.Equal(1153997401072, Puzzle.SumGoodEquations(Input.Real));
    }

    [Fact]
    public void Part2()
    {
        Assert.Equal(11387, Puzzle.SumGoodEquations(Input.Test, useConcat: true));
        Assert.Equal(97902809384118, Puzzle.SumGoodEquations(Input.Real, useConcat: true));
    }
}
