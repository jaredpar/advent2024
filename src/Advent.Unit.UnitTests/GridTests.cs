using Xunit;
namespace Advent.Util.UnitTests;

public sealed class GridTests
{
    [Fact]
    public void ParseDelimetedTest()
    {
        var input = """
            1 2 3
            4 5 6
            7 8 9
            """;
        int[] expected = [1, 2, 3, 4, 5, 6, 7, 8, 9];

        var grid = Grid.ParseDelimeted(input, ' ', int (ReadOnlySpan<char> c) => int.Parse(c));
        var current = 0;
        for (int r = 0; r < grid.Rows; r++)
        {
            for (int c = 0; c < grid.Columns; c++)
            {
                Assert.Equal(expected[current], grid[r, c]);
                current ++;
            }
        }
    }

    [Theory]
    [InlineData("a\nb")]
    [InlineData("cat\ndog")]
    public void Parse(string input)
    {
        var grid = Grid.Parse(input);
        var lines = input.Split('\n');
        Assert.Equal(lines.Length, grid.Rows);
        Assert.Equal(lines[0].Length, grid.Columns);
        var expected = input.Replace("\n", "");
        var e = grid.GetEnumerator();
        var current = 0;
        while (e.MoveNext())
        {
            Assert.Equal(expected[current], e.Current);
            current++;
        }
        Assert.Equal(expected.Length, current);
    }
}