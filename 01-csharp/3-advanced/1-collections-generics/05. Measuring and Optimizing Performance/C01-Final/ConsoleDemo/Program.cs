using BenchmarkDotNet.Running;

try
{
    BenchmarkRunner.Run<SortingBenchmark>();
}
catch (Exception e)
{
    Console.WriteLine($"ERROR: {e.Message}");
}