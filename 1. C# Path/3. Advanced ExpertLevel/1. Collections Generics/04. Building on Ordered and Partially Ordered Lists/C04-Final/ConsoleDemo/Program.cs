using System.Diagnostics;

try
{
    IPaginated<Worker> pages =
        Workers.TestData.Replicate(50_000, .05F).Paginate(Worker.RateComparer, 112_000);
    
    Stopwatch pageTimer = Stopwatch.StartNew();
    IEnumerator<IPage<Worker>> enumerator = pages.GetEnumerator();
    
    while (enumerator.MoveNext())
    {
        IPage<Worker> page = enumerator.Current;
        PayRate rate = page.AveragePayRate();
        Console.WriteLine($"Page #{page.Ordinal}: {page.Count}x{rate} [{pageTimer.Elapsed}]");
        pageTimer.Restart();
        break;
    }
}
catch (Exception e)
{
    Console.WriteLine($"ERROR: {e.Message}");
}