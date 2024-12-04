using Xunit;

namespace Day03.UnitTests;

public class PuzzleTests
{
    [Fact]
    public void Part1()
    {
        Assert.Equal(161, Puzzle.RunProgram(Input.Test, allowControls: false));
        Assert.Equal(174336360, Puzzle.RunProgram(Input.Real, allowControls: false));
    }

    [Fact]
    public void Part2()
    {
        Assert.Equal(48, Puzzle.RunProgram(Input.Test2, allowControls: true));
        Assert.Equal(88802350, Puzzle.RunProgram(Input.Real, allowControls: true));
    }
}
