try
{
    IEnumerable<Worker> rawData = Workers.GetWorkers(40);
    
    IOrderedList<Employee> sorted =
        new FullySortedList<Worker>(rawData, Worker.RateComparer);
    
    sorted.ToGrid(120, 2).WriteLines();
}
catch (Exception e)
{
    Console.WriteLine($"ERROR: {e.Message}");
}