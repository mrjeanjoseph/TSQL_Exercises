try
{
    Workers.GetWorkers(1_000_000)
        .ToFullySortedList(Worker.RateComparer)
        .GetExtremesAndPercentiles(.1f, .1f)
        .WriteLines();
}
catch (Exception e)
{
    Console.WriteLine($"ERROR: {e.Message}");
}
