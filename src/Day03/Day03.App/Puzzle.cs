using System.Text.RegularExpressions;
using Advent.Util;

namespace Day03;

public sealed partial class Puzzle
{
    public static int RunProgram(ReadOnlySpan<char> input)
    {
        var sum = 0;
        while (TryParseMul(ref input) is int mul)
        {
            sum += mul;
        }
        return sum;
    } 

    public static int? TryParseMul(ref ReadOnlySpan<char> input)
    {
        var match = MulRegex.Match(input.ToString());
        if (!match.Success)
        {
            return null;
        }

        input = input.Slice(match.Index + match.Length);
        var left = int.Parse(match.Groups[1].Value);
        var right = int.Parse(match.Groups[2].Value);
        return left * right;
    }

    [GeneratedRegexAttribute(@"mul\((\d{1,3}),(\d{1,3})\)")]
    public static partial Regex MulRegex { get; }

    public static int RunProgramBetter(ReadOnlySpan<char> input)
    {
        var sum = 0;
        var enable = true;

        do
        {
            var current = input;
            var index = current.IndexOf("(");
            if (index < 0 || index == current.Length - 1)
            {
                break;
            }

            var instructionSpan = current[0..index];
            if (instructionSpan is "mul")
            {
                current = current[4..];
                if (ParseSmallInt(ref current, ',') is int left &&
                    ParseSmallInt(ref current, ')') is int right)
                {
                    if (enable)
                    {
                        sum += left * right;
                    }
                    input = current;
                }
                else
                {
                    input = input[1..];
                }
            }
            else if (instructionSpan is "do" && current[index + 1] is ')')
            {
                enable = true;
                input = input[(index + 1)..];
            }
            else if (instructionSpan is "don't" && current[index + 1] is ')')
            {
                enable = false;
                input = input[(index + 1)..];
            }
            else
            {
                input = input[1..];
            }
        } while (input.Length > 0);

        return sum;
    }

    public static int? ParseSmallInt(ref ReadOnlySpan<char> input, char delimeter)
    {
        var index = input.IndexOf(delimeter);
        if (index is <= 0 or > 3)
        {
            return null;
        }

        if (int.TryParse(input[..index], out var result))
        {
            input = input[(index + 1)..];
            return result;
        }

        return null;
    }
}

