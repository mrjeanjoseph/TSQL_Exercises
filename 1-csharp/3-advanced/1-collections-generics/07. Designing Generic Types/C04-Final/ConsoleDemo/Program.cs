try
{
    Workers.GetWorkers(40)
        .ToFullySortedList(worker => worker.HourlyRate)
        .ToGrid(120, 2).WriteLines();
}
catch (Exception e)
{
    Console.WriteLine($"ERROR: {e.Message}");
}