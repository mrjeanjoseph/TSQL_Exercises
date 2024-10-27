using Models.Tests.Data;

namespace Models.Tests.Services;

public class TestWorkItemsService : IWorkItemsService
{
    public TestWorkItemsService(IEnumerable<Worker> workers, DateTime startingTime)
    {
        this.Workers = workers.SelectMany(Repeat).ToList();
        this.StartingTime = startingTime;
    }

    private DateTime StartingTime { get; }

    private static IEnumerable<Worker> Repeat(Worker worker, int index) =>
        Enumerable.Repeat(worker, (int)Math.Max(Math.Pow(index+ 1, 3), 10));

    private IEnumerable<Worker> Workers { get; }

    private IEnumerable<TimeSpan> WorkTimes =>
        Timers.GetRandomTimeSpans(
            TimeSpan.FromMinutes(30), TimeSpan.FromHours(4));

    private IEnumerable<DateTime> AssignmentTimes(DateTime start) =>
        Timers.GetRandomDateTimes(
            start, TimeSpan.FromSeconds(90), TimeSpan.FromHours(12));

    public IEnumerable<WorkItem> GetAll() =>
        this.Workers.RepeatRandomly()
            .Zip(this.WorkTimes, (worker, duration) => (worker, duration))
            .Zip(this.AssignmentTimes(this.StartingTime), 
                 (work, assignment) => (work.worker, work.duration, assignment))
            .Select(tuple => new WorkItem(tuple.worker.Rate.In(tuple.duration), tuple.worker.Id, tuple.assignment));
}
