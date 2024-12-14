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
        Puzzle.Compact(list);
        var actual = Puzzle.AsString(list);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("222", "00..11", "0011..")]
    [InlineData("22202", "00..1122", "002211..")]
    [InlineData("22203", "00..11222", "0011..222")]
    [InlineData("25223", "00.....11..222", "0022211.......")]
    public void CompactWhole(string input, string check, string expected)
    {
        Assert.Equal(check.Length, expected.Length);
        var list = Puzzle.Parse(input);
        var actualInput = Puzzle.AsString(list);
        Assert.Equal(check, actualInput);
        Puzzle.CompactWhole(list);
        var actual = Puzzle.AsString(list);
        Assert.Equal(expected,actual);
    }

    [Fact]
    public void Part1()
    {
        Assert.Equal(1928, Puzzle.ChecksumCompacted(Input.Test));
        Assert.Equal(6370402949053, Puzzle.ChecksumCompacted(Input.Real));
    }

    [Fact]
    public void DataConsistency()
    {
        var list1 = Puzzle.Parse(Input.Real);
        var list2 = Puzzle.Parse(Input.Real);
        Puzzle.CompactWholeSlow(list2);
        foreach (var item in list1.Where(x => x.Id != Puzzle.FreeId))
        {
            Assert.Contains(item, list2);
        }
    }

    [Fact]
    public void Part2()
    {
        Assert.Equal(2858, Puzzle.ChecksumCompactedWhole(Input.Test));
        Assert.Equal(6398096697992, Puzzle.ChecksumCompactedWhole(Input.Real));
    }
}
