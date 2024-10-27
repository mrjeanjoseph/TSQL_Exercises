using BenchmarkDotNet.Running;

try
{
    BenchmarkRunner.Run<CurrencyCreationBenchmark>();
}
catch (Exception e)
{
    Console.WriteLine($"ERROR: {e.Message}");
}