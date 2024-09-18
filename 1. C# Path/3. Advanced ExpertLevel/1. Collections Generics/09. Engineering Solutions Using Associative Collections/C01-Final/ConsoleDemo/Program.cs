using BenchmarkDotNet.Running;

try
{
    //CurrencyCreationBenchmark.RunTotalMemoryTest(1_000_000);
    BenchmarkRunner.Run<CurrencyCreationBenchmark>();
}
catch (Exception e)
{
    Console.WriteLine($"ERROR: {e.Message}");
}