using System.Net.Quic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Advent.Util;
using Entry = (int Id, int Count);

namespace Day09;

public sealed class Puzzle
{
    public const int FreeId = -1;

    public static List<Entry> Parse(string input)
    {
        var list = new List<Entry>(capacity: input.Length);
        int id = 0;
        int index = 0;
        while (index < input.Length)
        {
            var count = input[index] - '0';
            list.Add((id, count));
            id++;
            if (index + 1 < input.Length)
            {
                count = input[index + 1] - '0';
                list.Add((FreeId, count));
            }

            index += 2;
        }

        return list;
    }

    public static string AsString(List<Entry> list)
    {
        var builder = new StringBuilder();
        var index = 0;
        while (index < list.Count)
        {
            var current = list[index];
            while (current.Count > 0)
            {
                if (current.Id == FreeId)
                {
                    builder.Append('.');
                }
                else
                {
                    builder.Append(current.Id);
                }
                current.Count--;
            }

            index++;
        }

        return builder.ToString();
    }

    public static long Checksum(List<Entry> list)
    {
        var realIndex = 0;
        var index = 0;
        var sum = 0L;
        while (index < list.Count)
        {
            var current = list[index];
            while (current.Count > 0)
            {
                if (current.Id != FreeId)
                {
                    sum += (realIndex * current.Id);
                }
                realIndex++;
                current.Count--;
            }

            index++;    
        }

        return sum;
    }

    public static long ChecksumCompacted(string input)
    {
        var list = Parse(input);
        var compacted = Compact(list);
        return Checksum(compacted);
    }

    public static List<Entry> Compact(List<Entry> list)
    {
        var compacted = new List<Entry>(list.Count);
        compacted.Add(list[0]);

        var currentFree = list[1].Count;
        var consumeIndex = list.Count - 1;
        var currentConsume = list[consumeIndex];
        var freeIndex = 1;

        do
        {
            switch (currentFree - currentConsume.Count)
            {
                case >0:
                    compacted.Add(currentConsume);
                    currentFree -= currentConsume.Count;
                    NextConsume();
                    break;
                case 0:
                    compacted.Add(currentConsume);
                    NextFree();
                    NextConsume();
                    break;
                case <0:
                    compacted.Add(new (currentConsume.Id, currentFree));
                    currentConsume.Count -= currentFree;
                    NextFree();
                    break;
            }
        } while (freeIndex < consumeIndex);

        return compacted;

        void NextFree()
        {
            if (freeIndex + 1 == consumeIndex)
            {
                if (currentConsume.Count > 0)
                {
                    compacted.Add(currentConsume);
                }
                freeIndex = consumeIndex;
            }
            else
            {
                compacted.Add(list[freeIndex + 1]);
                freeIndex += 2;
                if (freeIndex < list.Count) 
                {
                    currentFree = list[freeIndex].Count;
                }
            }
        }

        void NextConsume()
        {
            consumeIndex -= 2;
            if (consumeIndex >= 0)
            {
                currentConsume = list[consumeIndex];
            }
            else
            {
                currentConsume = default;
            }
        }
    }   
}
