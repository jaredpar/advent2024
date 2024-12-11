using System.Buffers;
using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Advent.Util;

namespace Day04;

public sealed class Puzzle
{
    public static int CountXmas(string input)
    {
        var grid = Grid.Parse(input);
        var count = 0;
        using var e = new WordEnumerator(grid, 4);
        while (e.MoveNext())
        {
            if (e.Current is "XMAS")
            {
                count++;
            }
        }

        return count;
    }

    public struct WordEnumerator(Grid<char> grid, int wordLength) : IDisposable
    {
        private int _wordLength = wordLength;
        private char[]? _buffer = ArrayPool<char>.Shared.Rent(4);
        private Grid<char>.Enumerator _enumerator = grid.GetEnumerator();
        private GridDirection? _direction;
        public Grid<char> Grid { get; } = grid;
        public ReadOnlySpan<char> Current => _buffer.AsSpan(0, _wordLength);

        public bool MoveNext()
        {
            do
            {
                if (MoveNextCore() is not { } direction)
                {
                    return false;
                }

                if (Grid.TryGetSpan(_enumerator.Row, _enumerator.Column, direction, _buffer.AsSpan(0, _wordLength)))
                {
                    return true;
                }

            } while (true);
        }

        private GridDirection? MoveNextCore()
        {
            if (_buffer is null)
            {
                throw new InvalidOperationException();
            }

            if (_direction is { } direction && NextDirection(direction) is { } nextDirection)
            {
                _direction = nextDirection;
                return nextDirection;
            }
            else
            {
                if (!_enumerator.MoveNext())
                {
                    Free();
                    return null;
                }

                _direction = GridDirection.Right;
                return GridDirection.Right;
            }
        }

        private static GridDirection? NextDirection(GridDirection d) => d switch
        {
            GridDirection.Right => GridDirection.Down,
            GridDirection.Down => GridDirection.Left,
            GridDirection.Left => GridDirection.Up,
            GridDirection.Up => GridDirection.DiagonalRightDown,
            GridDirection.DiagonalRightDown => GridDirection.DiagonalLeftDown,
            GridDirection.DiagonalLeftDown => GridDirection.DiagonalRightUp,
            GridDirection.DiagonalRightUp => GridDirection.DiagonalLeftUp,
            GridDirection.DiagonalLeftUp => null,
            _ => throw new ArgumentOutOfRangeException(nameof(d), d, null)
        };

        private void Free()
        {
            Debug.Assert(_buffer is not null);
            ArrayPool<char>.Shared.Return(_buffer!);
            _buffer = null!;
        }

        public void Dispose()
        {
            if (_buffer is not null)
            {
                Free();
            }
        }
    }
}
