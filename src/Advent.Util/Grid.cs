using System.Collections.Immutable;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;

namespace Advent.Util;

public readonly struct GridSpan<T>
{
    public Grid<T> Grid { get; }
    public int Row { get; }
    public int Column { get; }
    public int Length { get; }
    public int End => Column + Length;
    public Memory<T> Memory => Grid.GetRowMemory(Row).Slice(Column, Length);
    public Span<T> Span => Grid.GetRowSpan(Row).Slice(Column, Length);

    public ref T this[int index] => ref Grid.GetValue(Row, Column + index);

    public GridSpan(Grid<T> grid, int row, int column, int length)
    {
        Grid = grid;
        Row = row;
        Column = column;
        Length = length;
    }

    public GridSpan<T> Slice(int start, int length) => new GridSpan<T>(Grid, Row, Column + start, length);

    public bool Contains(int row, int column) => row == Row && column >= Column && column < Column + Length;

    public bool IsAdjacent(int row, int column)
    {
        if (row == Row)
        {
            return column == Column - 1 || column == Column + Length;
        }

        if ((row + 1 == Row) || (row - 1 == Row))
        {
            return column >= (Column - 1) && column < (Column + Length + 1);
        }

        return false;
    }

    public override string ToString() => $"{nameof(GridSpan<T>)}: {Row}, {Column}, {Length}";
}

public enum GridDirection
{
    Right,
    Down,
    Left,
    Up,
    DiagonalRightDown,
    DiagonalLeftDown,
    DiagonalRightUp,
    DiagonalLeftUp
}

public readonly record struct GridPosition(int Row, int Column)
{
    public GridPosition Move(GridDirection direction) =>
        direction switch 
        {
            GridDirection.Right => new(Row, Column + 1),
            GridDirection.Down => new(Row + 1, Column),
            GridDirection.Left => new(Row, Column - 1),
            GridDirection.Up => new(Row - 1, Column),
            GridDirection.DiagonalRightDown => new(Row + 1, Column + 1),
            GridDirection.DiagonalLeftDown => new(Row + 1, Column - 1),
            GridDirection.DiagonalRightUp => new(Row - 1, Column + 1),
            GridDirection.DiagonalLeftUp => new(Row - 1, Column - 1),
            _ => throw new InvalidOperationException()
        };

    public static GridPosition operator-(GridPosition position) =>
        new(-position.Row, -position.Column);

    public static GridPosition operator+(GridPosition left, (int Row, int Column) right) =>
        left + new GridPosition(right.Row, right.Column);

    public static GridPosition operator+(GridPosition left, GridPosition right) =>
        new(left.Row + right.Row, left.Column + right.Column);

    public static GridPosition operator-(GridPosition left, (int Row, int Column) right) =>
        left - new GridPosition(right.Row, right.Column);

    public static GridPosition operator-(GridPosition left, GridPosition right) =>
        new(left.Row - right.Row, left.Column - right.Column);

    public override string ToString() => $"R:{Row} C:{Column}";
}

public sealed class Grid<T>
{
    private delegate void IncrementFunc(ref int row, ref int column);

    private readonly T[] _items;
    private readonly int _columns;

    public int Rows => _items.Length / _columns;
    public int Columns => _columns;

    public ref T this[GridPosition position] => ref GetValue(position);
    public ref T this[int row, int column] => ref GetValue(row, column);

    public Grid(int rows, int columns)
    {
        if (rows <= 0 || columns <= 0)
        {
            throw new ArgumentOutOfRangeException();
        }

        _items = new T[rows * columns];
        _columns = columns;
    }

    public Enumerator GetEnumerator() => new(this);

    public bool IsValid(GridPosition position) =>
        position.Row >= 0 &&
        position.Row < Rows &&
        position.Column >= 0 &&
        position.Column < Columns;

    public IEnumerable<(int Row, int Column)> GetAdjacentIndexes(int row, int column)
    {
        if (row - 1 >= 0)
        {
            yield return (row - 1, column);
            if (column - 1 >= 0)
                yield return (row - 1, column - 1);
            if (column + 1 < Columns)
                yield return (row - 1, column + 1);
        }

        if (row + 1 < Rows)
        {
            yield return (row + 1, column);
            if (column - 1 >= 0)
                yield return (row + 1, column - 1);
            if (column + 1 < Columns)
                yield return (row + 1, column + 1);
        }

        if (column - 1 >= 0)
            yield return (row, column - 1);

        if (column + 1 < Columns)
            yield return (row, column + 1);
    }

    public ref T GetValue(GridPosition position) => ref GetValue(position.Row, position.Column);

    public ref T GetValue(int row, int column) => ref _items[(row * _columns) + column];

    public Memory<T> GetRowMemory(int row) => _items.AsMemory(row * _columns, _columns);

    public Span<T> GetRowSpan(int row) => _items.AsSpan(row * _columns, _columns);

    public GridSpan<T> GetGridSpan(int row) => new(this, row, 0, Columns);

    /// <summary>
    /// Get the values at the specified row column in the direction and put them into 
    /// the span. Length is dictated by the length of the span.
    /// </summary>
    public bool TryGetSpan(int row, int column, GridDirection direction, Span<T> span)
    {
        var position = new GridPosition(row, column);
        for (int i = 0; i < span.Length; i++)
        {
            if (!IsValid(position))
            {
                return false;
            }

            span[i] = GetValue(position);
            position = position.Move(direction);
        };

        return true;
    }

    public IEnumerable<GridSpan<T>> GetGridSpans()
    {
        for (int r = 0; r < Rows; r++)
        {
            yield return new GridSpan<T>(this, r, 0, Columns);
        }
    }

    public IEnumerable<(T, int row, int column)> GetValues()
    {
        for (int r = 0; r < Rows; r++)
        {
            for (int c = 0; c < Columns; c++)
            {
                yield return (GetValue(r, c), r, c);
            }
        }
    }

    public struct Enumerator(Grid<T> grid)
    {
        public Grid<T> Grid { get; } = grid;
        public int Row { get; private set; } = -1;
        public int Column { get; private set; }
        public GridPosition Position => new(Row, Column);
        public T Current => Grid.GetValue(Row, Column);

        public bool MoveNext()
        {
            if (Row == -1)
            {
                Row = 0;
            }
            else
            {
                Column++;
                if (Column >= Grid.Columns)
                {
                    Row++;
                    Column = 0;
                }
            }

            return Row < Grid.Rows;
        }

        public void Dispose() { }

        public override string ToString() => $"R:{Row} C:{Column} V:{Current}";
    }

    public string RenderAsString()
    {
        var builder = new StringBuilder();
        for (int r = 0; r < Rows; r++)
        {
            for (int c = 0; c < Columns; c++)
            {
                builder.Append(GetValue(r, c));
            }
            builder.AppendLine();
        }

        return builder.ToString();
    }
}

public static class Grid
{
    public static Grid<char> Parse(string input) =>
        Parse(input, static c => c);

    public static Grid<int> ParseInts(string input) =>
        Parse(input, static c => c - '0');

    public static ImmutableArray<GridDirection> StraightDirections { get; } =
    [
        GridDirection.Right,
        GridDirection.Down,
        GridDirection.Left,
        GridDirection.Up
    ];

    public static ImmutableArray<GridDirection> AllDirections { get; } =
    [
        GridDirection.Right,
        GridDirection.Down,
        GridDirection.Left,
        GridDirection.Up,
        GridDirection.DiagonalRightDown,
        GridDirection.DiagonalLeftDown,
        GridDirection.DiagonalRightUp,
        GridDirection.DiagonalLeftUp
    ];

    /// <summary>
    /// Parse out the input by lines with each character being an element in the 
    /// <see cref="Grid<char>"/> 
    /// </summary>
    public static Grid<T> Parse<T>(string input, Func<char, T> func)
    {
        var e = input.SplitLines();
        if (!e.MoveNext())
        {
            throw new InvalidOperationException();
        }

        var rows = input.CountLines();
        var columns = e.Current.Length;
        var grid = new Grid<T>(rows, columns);
        var r = 0;
        do
        {
            var current = e.Current;
            for (int c = 0; c < current.Length; c++)
            {
                grid.GetValue(r, c) = func(current[c]);
            }
            r++;
        } while (e.MoveNext());

        return grid;
    }

    /// <summary>
    /// Parse out a grid where the delimeter between the columns is a space.
    /// </summary>
    public static Grid<T> ParseDelimeted<T>(string input, char delimeter, Func<ReadOnlySpan<char>, T> func)
    {
        var e = input.SplitLines();
        if (!e.MoveNext())
        {
            throw new InvalidOperationException();
        }

        var lineCount = input.CountLines();
        var first = e.Current;
        var columnCount = CountDelimeters(first, delimeter) + 1;
        var grid = new Grid<T>(lineCount, columnCount);
        var r = 0;
        Span<Range> rangeSpan = stackalloc Range[columnCount];
        do
        {
            var current = e.Current;
            var currentCount = current.Split(rangeSpan, delimeter, StringSplitOptions.RemoveEmptyEntries);
            if (currentCount != grid.Columns)
            {
                throw new InvalidOperationException();
            }

            for (int c = 0; c < grid.Columns; c++)
            {
                grid.GetValue(r, c) = func(current[rangeSpan[c]]);
            }

            r++;
        } while (e.MoveNext());

        return grid;

        static int CountDelimeters(ReadOnlySpan<char> line, char delimeter)
        {
            var count = 0;
            foreach (var c in line)
            {
                if (c == delimeter)
                {
                    count++;
                }
            }

            return count;
        }
    }
}