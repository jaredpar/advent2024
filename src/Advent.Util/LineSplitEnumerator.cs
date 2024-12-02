using System.Buffers;
using System.Linq.Expressions;

namespace Advent.Util;

public ref struct LineSplitEnumerator(ReadOnlySpan<char> span)
{
    private static SearchValues<char> NewLineCharacters { get; } = SearchValues.Create(['\r', '\n']);

    private const int NotStarted = 0;
    private const int Enumerating = 1;
    private const int Done = 2;

    private int _state;
    private ReadOnlySpan<char> _span = span;
    private ReadOnlySpan<char> _current;

    public ReadOnlySpan<char> Current
    {
        get
        {
            if (_state != Enumerating)
            {
                throw new InvalidOperationException();
            }

            return _current;
        }
    }

    public bool MoveNext()
    {
        if (_state == Enumerating && _span.IsEmpty)
        {
            _state = Done;
            return false;
        }

        if (_state == Done)
        {
            return false;
        }

        _state = Enumerating;

        var index = _span.IndexOfAny(NewLineCharacters);
        if (index < 0)
        {
            _current = _span;
            _span = default;
            return true;
        }

        _current = _span.Slice(0, index);
        if (index + 1 < _span.Length && 
            _span[index] == '\r' &&
            _span[index + 1] == '\n')
        {
            _span = _span.Slice(index + 2);
        }
        else
        {
            _span = _span.Slice(index + 1);
        }

        return true;
    }

    public static int CountLines(ReadOnlySpan<char> span)
    {
        var count = 1;
        do
        {
            var index = span.IndexOfAny(NewLineCharacters);
            if (index < 0)
            {
                return count;
            }

            count++;
            if (index + 1 < span.Length && 
                span[index] == '\r' &&
                span[index + 1] == '\n')
            {
                span = span.Slice(index + 2);
            }
            else
            {
                span = span.Slice(index + 1);
            }
        } while (true);
    }
}