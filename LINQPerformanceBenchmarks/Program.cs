using BenchmarkDotNet.Running;

namespace LINQPerformanceBenchmarks;

internal class Program
{
    private static void Main(string[] args)
    {
        BenchmarkRunner.Run<PeopleDataBenchmark>();
    }
}