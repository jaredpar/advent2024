// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;

BenchmarkSwitcher.FromAssembly(typeof(Day01Benchmarks).Assembly).Run(args);