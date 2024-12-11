using Advent.Util;
using Xunit;

namespace Advent.Util.UnitTests;

public sealed class LineSplitEnumeratorTests
{
    private List<string> GetLinesViaReader(string input)
    {
        using var reader = new StringReader(input);
        var lines = new List<string>();
        while (reader.ReadLine() is string line)
        {
            lines.Add(line);
        }
        return lines;
    }

    private List<string> GetLinesViaEnumerator(string input)
    {
        var lines = new List<string>();
        var e = input.SplitLines();
        while (e.MoveNext())
        {
            lines.Add(e.Current.ToString());
        }
        return lines;
    }

    [Theory]
    [InlineData("hello\nworld")]
    [InlineData("hello\n\nworld")]
    [InlineData("hello\r\nworld")]
    [InlineData("hello\r\nw\norld")]
    [InlineData("\nhello\r\nw\norld")]
    public void CompareToSplit(string input)
    {
        var expected = GetLinesViaReader(input);
        var actual = GetLinesViaEnumerator(input);
        Assert.Equal(expected, actual);
    }
}
