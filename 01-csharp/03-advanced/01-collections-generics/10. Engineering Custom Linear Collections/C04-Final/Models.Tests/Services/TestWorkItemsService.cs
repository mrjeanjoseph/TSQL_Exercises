using Models.Tests.Data;

namespace Models.Tests.Services;

public class TestWorkItemsService : IWorkItemsService
{
    public TestWorkItemsService(IEnumerable<Worker> workers)
    {
        this.Workers = workers.SelectMany(Repeat).ToList();
    }

    private static IEnumerable<Worker> Repeat(Worker worker, int index) =>
        Enumerable.Repeat(worker, (int)Math.Max(Math.Pow(index+ 1, 3), 10));

    private IEnumerable<Worker> Workers { get; }

    private IEnumerable<TimeSpan> WorkTimes =>
        ReplicatingOperators.GetRandomTimeSpans(
            TimeSpan.FromMinutes(30), TimeSpan.FromHours(4));

    public IEnumerable<WorkItem> GetAll() =>
        this.Workers.RepeatRandomly().Zip(
            this.WorkTimes,
            (worker, time) => new WorkItem(worker.Rate.In(time), worker.Id));
}
