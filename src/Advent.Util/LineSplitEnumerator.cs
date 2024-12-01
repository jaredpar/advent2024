using System.Buffers;

namespace Advent.Util;

public ref struct LineSplitEnumerator(ReadOnlySpan<char> span)
{
    private static SearchValues<char> NewLineCharacters { get; } = SearchValues.Create(['\r', '\n']);

    private ReadOnlySpan<char> _span = span;
    private ReadOnlySpan<char> _current;

    public ReadOnlySpan<char> Current
    {
        get
        {
            if (_current == default)
            {
                throw new InvalidOperationException();
            }

            return _current;
        }
    }

    public bool MoveNext()
    {
        if (_span == default)
        {
            _current = default;
            return false;
        }

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
}