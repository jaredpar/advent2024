using Xunit;

namespace Day03.UnitTests;

public class PuzzleTests
{
    [Fact]
    public void Part1()
    {
        Assert.Equal(161, Puzzle.RunProgram(Input.Test));
        Assert.Equal(174336360, Puzzle.RunProgram(Input.Real));
    }
}
