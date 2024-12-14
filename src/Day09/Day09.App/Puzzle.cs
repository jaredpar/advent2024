using System.Diagnostics;
using System.IO.Compression;
using System.Linq.Expressions;
using System.Net.Quic;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using Advent.Util;
using Entry = (int Id, int Count);

namespace Day09;

public sealed class Puzzle
{
    public const int FreeId = -1;
    public const int ToDeletId = -1;

    public static LinkedList<Entry> Parse(string input)
    {
        var list = new LinkedList<Entry>();
        int id = 0;
        int index = 0;
        while (index < input.Length)
        {
            var count = input[index] - '0';
            list.AddLast((id, count));
            id++;
            if (index + 1 < input.Length)
            {
                count = input[index + 1] - '0';
                list.AddLast((FreeId, count));
            }

            index += 2;
        }

        return list;
    }

    public static string AsString(IEnumerable<Entry> list)
    {
        var builder = new StringBuilder();
        using var e = list.GetEnumerator();
        while (e.MoveNext())
        {
            var current = e.Current;
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
        }

        return builder.ToString();
    }

    public static long Checksum(IEnumerable<Entry> list)
    {
        var realIndex = 0;
        var index = 0;
        var sum = 0L;
        using var e = list.GetEnumerator();
        while (e.MoveNext())
        {
            var current = e.Current;
            var count = 0;
            while (count < current.Count)
            {
                if (current.Id != FreeId)
                {
                    sum += (realIndex * current.Id);
                }
                realIndex++;
                count++;
            }

            index++;    
        }

        return sum;
    }

    public static long ChecksumCompacted(string input)
    {
        var list = Parse(input);
        Compact(list);
        return Checksum(list);
    }

    public static long ChecksumCompactedWhole(string input)
    {
        var list = Parse(input);
        CompactWholeSlow(list);
        return Checksum(list);
    }

    public static void Compact(LinkedList<Entry> list)
    {
        Debug.Assert(list.First is not null);
        Debug.Assert(list.First.Next is not null);

        var freeNode = list.First.Next;
        var freeEntry = freeNode!.Value;
        var consumeNode = list.Last;
        if (consumeNode!.Value.Id == FreeId)
        {
            consumeNode = consumeNode.Previous!;
        }
        var consumeEntry = consumeNode.Value;
        LinkedListNode<Entry>? last = null;

        do
        {
            switch (freeEntry.Count  - consumeEntry.Count)
            {
                case >0:
                    list.AddBefore(freeNode, consumeEntry);
                    freeEntry.Count -= consumeEntry.Count;
                    NextConsume();
                    break;
                case 0:
                    list.AddBefore(freeNode, consumeEntry);
                    NextFree();
                    NextConsume();
                    break;
                case <0:
                    list.AddBefore(freeNode, new Entry(consumeEntry.Id, freeEntry.Count));
                    consumeEntry.Count -= freeEntry.Count;
                    NextFree();
                    break;
            }
        } while (last is null);

        while (last.Next is not null)
        {
            list.Remove(last.Next);
        }

        void NextFree()
        {
            if (object.ReferenceEquals(freeNode.Next, consumeNode))
            {
                if (consumeEntry.Count > 0)
                {
                    last = list.AddBefore(freeNode, consumeEntry);
                }
                else
                {
                    last = freeNode.Previous!;
                }

                Debug.Assert(last is not null);
            }
            else
            {
                Debug.Assert(freeNode.Next is not null);
                Debug.Assert(freeNode.Next.Next is not null);

                var temp = freeNode;
                freeNode = freeNode.Next.Next;
                freeEntry = freeNode.Value;
                list.Remove(temp);
            }
        }

        void NextConsume()
        {
            if (object.ReferenceEquals(consumeNode.Previous, freeNode))
            {
                last = freeNode.Previous;
            }
            else
            {
                Debug.Assert(consumeNode.Previous is not null);
                Debug.Assert(consumeNode.Previous.Previous is not null);
                consumeNode = consumeNode.Previous.Previous;
                consumeEntry = consumeNode.Value;
            }
        }
    }

    public static void CompactWhole(LinkedList<Entry> list)
    {
        var freeArray = BuildFreeArray();
        var currentNode = list.Last;
        var currentIndex = list.Count - 1;

        if (currentNode!.Value.Id == FreeId)
        {
            Previous();
        }

        while (currentNode is not null)
        {
            if (currentNode.Value.Id != FreeId)
            {
                var node = FindInsertAfter(currentNode.Value, currentIndex);
                if (node is not null)
                {
                    list.AddAfter(node, currentNode.Value);
                    currentNode.ValueRef.Id = FreeId;
                }
            }

            currentNode = currentNode.Previous;
            currentIndex--;
        }

        CompactFreeEnd();

        // Compat all the free nodes at the end of the list
        void CompactFreeEnd()
        {
            var node = list.Last;
            while (
                node is { Value: { Id: FreeId } } &&
                node.Previous is { Value: { Id: FreeId } } previous)
            {
                previous.ValueRef.Count += node.Value.Count;
                list.Remove(node);
                node = previous;
            }
        }

        void Previous()
        {
            if (currentNode is not null)
            {
                currentNode = currentNode.Previous;
                currentIndex--;
            }
        }

        LinkedListNode<Entry>? FindInsertAfter(Entry entry, int entryIndex)
        {
            (int FreeIndex, int ListIndex)? tuple = null;

            for (int i = entry.Count; i < freeArray.Length; i++)
            {
                if (freeArray[i] is { Node : { } } element)
                {
                    if (element.ListIndex > entryIndex)
                    {
                        freeArray[i] = (null, -1, true);
                        continue;
                    }

                    if (tuple is not { } t ||
                        element.ListIndex < t.ListIndex)
                    {
                        tuple = (i, element.ListIndex);
                    }
                }
            }

            if (tuple is { } found)
            {
                var node = freeArray[found.FreeIndex].Node!.Previous;
                AllocateFreeNode(found.FreeIndex, entry.Count);
                return node;
            }

            return null;
        }

        void AllocateFreeNode(int freeArrayIndex, int allocated)
        {
            var (freeNode, freeListIndex, _) = freeArray[freeArrayIndex];
            Debug.Assert(freeNode is not null);
            Debug.Assert(freeListIndex >= 0);

            // First lets find the next node with the same count
            var node = freeNode.Next;
            var index = freeListIndex + 1;
            while (node is not null)
            {
                if (index >= currentIndex)
                {
                    node = null;
                    break;
                }

                if (node.Value.Id == FreeId && node.Value.Count == freeArrayIndex)
                {
                    freeArray[freeArrayIndex] = (node, index, false);
                    break;
                }

                node = node.Next;
                index++;
            }

            if (node is null)
            {
                freeArray[freeArrayIndex] = (null, -1, true);
            }

            // Next let's see if this node needs to be slotted into the free
            // list. The new count could position it before an exisiting node
            // in the list.
            var rest = freeNode.ValueRef.Count -= allocated;
            if (rest == 0)
            {
                list.Remove(freeNode);
            }
            else if (
                freeArray[rest] is { Node : { } } element &&
                freeListIndex < element.ListIndex)
            {
                freeArray[rest] = (freeNode, freeListIndex, false);
            }
        }

        (LinkedListNode<Entry>? Node, int ListIndex, bool Done)[] BuildFreeArray()
        {
            var maxFree = GetMaxFree();
            var array = new (LinkedListNode<Entry>? Node, int Index, bool Done)[maxFree + 1];
            var node = list.First;
            var index = 0;
            var found = 0;
            while (node is not null && found < maxFree)
            {
                if (node.Value.Id == FreeId)
                {
                    var count = node.Value.Count;
                    ref var elem = ref array[count];
                    if (elem.Node is null)
                    {
                        elem.Node = node;
                        elem.Index = index;
                        found++;;
                    }
                }
                node = node.Next;
                index++;
            }

            return array;

            int GetMaxFree()
            {
                using var e = list.GetEnumerator();
                var max = 1;
                while (e.MoveNext())
                {
                    if (e.Current.Id == FreeId && e.Current.Count > max)
                    {
                        max = e.Current.Count;
                    }
                }

                return max;
            }
        }
    }

    public static IEnumerable<LinkedListNode<Entry>> FreeEnumeratorForward(LinkedList<Entry> list, LinkedListNode<Entry> limitNode)
    {
        var node = list.First;
        while (node is not null && !object.ReferenceEquals(limitNode, node))
        {
            if (node.Value.Id == FreeId)
            {
                yield return node;
            }
            node = node.Next;
        }
    }

    public static IEnumerable<LinkedListNode<Entry>> FileEnumeratorReverse(LinkedList<Entry> list)
    {
        var node = list.Last;
        while (node is not null)
        {
            if (node.Value.Id != FreeId)
            {
                yield return node;
            }
            node = node.Previous;
        }
    }

    public static void CompactWholeSlow(LinkedList<Entry> list)
    {
        foreach (var fileNode in FileEnumeratorReverse(list))
        {
            ref var fileValue = ref fileNode.ValueRef;
            foreach (var freeNode in FreeEnumeratorForward(list, fileNode))
            {
                if (object.ReferenceEquals(freeNode, fileNode))
                {
                    break;
                }

                ref var freeValue = ref freeNode.ValueRef;
                if (freeValue.Count == fileValue.Count)
                {
                    freeValue.Id = fileValue.Id;
                    fileValue.Id = FreeId;
                    break;
                }
                else if (freeValue.Count > fileValue.Count)
                {
                    list.AddBefore(freeNode, fileValue);
                    freeValue.Count -= fileValue.Count;
                    fileValue.Id = FreeId;
                    break;
                }
            }
        }
    }
}
