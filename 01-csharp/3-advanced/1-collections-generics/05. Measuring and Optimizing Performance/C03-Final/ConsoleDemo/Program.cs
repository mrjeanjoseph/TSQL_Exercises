using BenchmarkDotNet.Running;

try
{
    BenchmarkRunner.Run<FirstPageBenchmark>();
}
catch (Exception e)
{
    Console.WriteLine($"ERROR: {e.Message}");
}