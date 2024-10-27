using System.Diagnostics;
using Models.Tests.Data;

namespace Models.Tests.Services;

public class DelayingWorkersService : IWorkersService
{
    public DelayingWorkersService(int workersCount, TimeSpan searchDelay)
    {
        this.IdToWorker = Workers.GetWorkers(workersCount).ToDictionary(worker => worker.Id);
        this.SearchDelay = searchDelay;
    }

    private Dictionary<Guid, Worker> IdToWorker { get; }
    private TimeSpan SearchDelay { get; }

    public Worker Find(Guid id) =>
        Delay(this.IdToWorker[id], this.SearchDelay);

    public IEnumerable<Worker> GetAll() => this.IdToWorker.Values;

    private static T Delay<T>(T item, TimeSpan delay)
    {
        Stopwatch currentTime = Stopwatch.StartNew();
        while (currentTime.Elapsed < delay) Thread.Yield();
        return item;
    }
}