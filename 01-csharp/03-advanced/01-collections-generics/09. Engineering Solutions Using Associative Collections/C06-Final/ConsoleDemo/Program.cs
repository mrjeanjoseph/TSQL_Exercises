using System.Diagnostics;

try
{
    (IWorkersService workers, IWorkItemsService workItems) = CreateServices();

    int batchSize = 1000;

    for (int capacity = 0; capacity <= 10; capacity++)
    {
        IWorkersService cached = workers.Cached(capacity);
        Stopwatch time = Stopwatch.StartNew();
        foreach (WorkItem workItem in workItems.GetAll().Take(batchSize))
        {
            cached.Find(workItem.AssignedToWorker);
        }
        Console.WriteLine($"Cache[{capacity, 2}]: Processed {batchSize} item(s) in {time.Elapsed}");
    }
}
catch (Exception e)
{
    Console.WriteLine($"ERROR: {e.Message}");
}

(IWorkersService, IWorkItemsService) CreateServices()
{
    IWorkersService workers = new DelayingWorkersService(10, TimeSpan.FromMilliseconds(5));
    IWorkItemsService workItems = new TestWorkItemsService(workers.GetAll());
    return (workers, workItems);
}