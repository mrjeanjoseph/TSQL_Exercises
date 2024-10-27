try
{
    FetchWorkItems().Take(100).WriteLines();
}
catch (Exception e)
{
    Console.WriteLine($"ERROR: {e.Message}");
}

DateTime GetStartTime() => DateTime.Today.AddHours(8);

IEnumerable<WorkItem> FetchWorkItems() =>
    new TestWorkItemsService(Workers.GetWorkers(100), GetStartTime()).GetAll();