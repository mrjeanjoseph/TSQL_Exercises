namespace Models.Tests.Data;

public static class Workers
{
    public static IEnumerable<Worker> TestData =>
        TestWorkerContent.Zip(Guids.TestData, (worker, guid) => 
            new Worker(guid, worker.name, Currencies.Usd.Of(worker.rate, 2).PerHour()))
            .Once();

    private static IEnumerable<(string name, decimal rate)> TestWorkerContent => new[]
    {
        ("Jack", 85.4728M), ("Jill", 100.6928M), ("Joe", 61), ("Jimmy", 124),
        ("Jane", 95), ("Jake", 72), ("John", 45), ("Julie", 97), ("Jasmin", 59.95M),
        ("Jerry", 71), ("Jacob", 55), ("Joyce", 98.42M), ("Jared", 64),
        ("Josie", 105.6M), ("Judith", 89), ("Jay", 44), ("Jamie", 68)
    };

    public static IEnumerable<Worker> GetWorkers(int count) =>
        GetRawWorkers().Take(count)
            .Zip(
                ReplicatingOperators.GetRandomValues(1/.8F, 1.2F),
                (worker, factor) => worker.ScalePayRate((decimal)factor))
            .Zip(
                Guids.TestData,
                (worker, guid) => new Worker(guid, worker.Name, worker.Rate)
            );

    private static IEnumerable<Worker> GetRawWorkers()
    {
        while (true)
        {
            foreach (Worker worker in TestData) yield return worker;
        }
    }
}