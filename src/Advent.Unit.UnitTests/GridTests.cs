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

        var grid = Grid<int>.ParseDelimeted(input, ' ', c => int.Parse(c));
        var current = 0;
        for (int r = 0; r < grid.Rows; r++)
        {
            for (int c = 0; c < grid.Columns; c++)
            {
                Assert.Equal(expected[current], grid.GetValue(r, c));
                current ++;
            }
        }
    }
}