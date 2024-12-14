
namespace Advent.Util;

public static class StandardUtil
{
    public static long CountDigits(long number)
    {
        if (number == 0) return 1;
        return (int)Math.Floor(Math.Log10(Math.Abs(number)) + 1);
    }

    public static long CountDigits(int number)
    {
        if (number == 0) return 1;
        return (int)Math.Floor(Math.Log10(Math.Abs(number)) + 1);
    }
}