using Xunit;

namespace Day09.UnitTests;

public class PuzzleTests
{
    [Theory]
    [InlineData("2333133121414131402", "0099811188827773336446555566")]
    [InlineData("231", "001")]
    public void Compat(string input, string expected)
    {
        var list = Puzzle.Parse(input);
        var compacted = Puzzle.Compact(list);
        var actual = Puzzle.AsString(compacted);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Part1()
    {
        Assert.Equal(1928, Puzzle.ChecksumCompacted(Input.Test));
        Assert.Equal(6370402949053, Puzzle.ChecksumCompacted(Input.Real));
    }
}
