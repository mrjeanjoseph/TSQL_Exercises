using System.Diagnostics;

try
{
    Stopwatch timer = Stopwatch.StartNew();

    Workers.GetWorkers(1_000_000)
        .ToFullySortedList(Worker.RateComparer)
        .RemoveOutliers(.2f)
        .GetExtremesAndPercentiles(.1f, .1f)
        .WriteLines();
    
    Console.WriteLine($"Done in {timer.Elapsed}");
}
catch (Exception e)
{
    Console.WriteLine($"ERROR: {e.Message}");
}
