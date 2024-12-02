namespace Advent.Util;

public static class Extensions
{
    public static void InsertSorted<T>(this List<T> list, T value)
    {
        var index = list.BinarySearch(value);
        if (index < 0)
        {
            index = ~index;
        }
        list.Insert(index, value);
    }

    public static int CountChars(this ReadOnlySpan<char> input, char value)
    {
        var count = 0;
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == value)
            {
                count++;
            }
        }
        return count;
    }

    public static int CountLines(this string input) =>
        CountLines(input.AsSpan());

    public static int CountLines(this ReadOnlySpan<char> input) =>
        LineSplitEnumerator.CountLines(input);

    public static LineSplitEnumerator SplitLines(this string input) =>
        SplitLines(input.AsSpan());

    public static LineSplitEnumerator SplitLines(this ReadOnlySpan<char> input) =>
        new LineSplitEnumerator(input);
}