try
{
    TimeSpan interval = TimeSpan.FromHours(1);
    WorkItem[] items = FetchWorkItems().ToArray();

    WorkItemsTimeWindow window = new(interval);
    Report(window, GetStartTime());

    DateTime? timeout = null;

    int pos = 0;
    while (pos < items.Length)
    {
        if (timeout < items[pos].AssignmentTime)
        {
            window.SetCurrentTime(timeout.Value);
            Report(window, timeout.Value);
        }
        else
        {
            window.Add(items[pos++]);
            Report(window, window.Tail.AssignmentTime);
        }

        timeout =
            window.Count == 0 ? null
            : window.Head.AssignmentTime.Add(interval);
    }
}
catch (Exception e)
{
    Console.WriteLine($"ERROR: {e.Message}");
}

DateTime GetStartTime() => DateTime.Today.AddHours(8);
DateTime GetEndTime() => GetStartTime().AddHours(10);

IEnumerable<WorkItem> FetchWorkItems() =>
    new TestWorkItemsService(Workers.GetWorkers(100), GetStartTime())
        .GetAll()
        .TakeWhile(item => item.AssignmentTime < GetEndTime());

void Report(WorkItemsTimeWindow window, DateTime time) =>
    Console.WriteLine(
        $"{time:HH:mm:ss}\t{window.Count}\t{window.TotalCost}\t" +
        $"{(window.Count > 0 ? window.Maximum.Cost : MoneyBag.Empty)}");
