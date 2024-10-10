using System.Diagnostics;

try
{
    (IWorkersService workers, IWorkItemsService workItems) = CreateServices();

    int batchSize = 1000;

    Stopwatch time = Stopwatch.StartNew();
    foreach (WorkItem workItem in workItems.GetAll().Take(batchSize))
    {
        workers.Find(workItem.AssignedToWorker);
    }
    Console.WriteLine($"Processed {batchSize} item(s) in {time.Elapsed}");
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