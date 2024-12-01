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
}