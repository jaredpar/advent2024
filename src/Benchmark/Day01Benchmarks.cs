using BenchmarkDotNet.Attributes;
using Day01;

[MemoryDiagnoser(true)]
public class Day01Benchmarks
{
    [Benchmark]
    public void Part1()
    {
        Puzzle.GetDistance(Input.Real);
    }

    [Benchmark]
    public void Part2()
    {
        Puzzle.GetSimilarity(Input.Real);
    }
}