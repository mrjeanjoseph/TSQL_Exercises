namespace Models.Tests.Data;

public static class Workers
{
    public static IEnumerable<Worker> TestData => new[]
    {
        new Worker("Jack", Currencies.Usd.Of(85.4728M, 2).PerHour()),
        new Worker("Jill", Currencies.Usd.Of(100.6928M, 2).PerHour()),
        new Worker("Joe", Currencies.Usd.Of(61, 2).PerHour()),
        new Worker("Jimmy", Currencies.Usd.Of(124, 2).PerHour()),
        new Worker("Jane", Currencies.Usd.Of(95, 2).PerHour()),
        new Worker("Jake", Currencies.Usd.Of(72, 2).PerHour()),
        new Worker("John", Currencies.Usd.Of(45, 2).PerHour()),
        new Worker("Julie", Currencies.Usd.Of(97, 2).PerHour()),
        new Worker("Jasmin", Currencies.Usd.Of(59.95M, 2).PerHour()),
        new Worker("Jerry", Currencies.Usd.Of(71, 2).PerHour()),
        new Worker("Jacob", Currencies.Usd.Of(55, 2).PerHour()),
        new Worker("Joyce", Currencies.Usd.Of(98.42M, 2).PerHour()),
        new Worker("Jared", Currencies.Usd.Of(64, 2).PerHour()),
        new Worker("Josie", Currencies.Usd.Of(105.6M, 2).PerHour()),
        new Worker("Judith", Currencies.Usd.Of(89, 2).PerHour()),
        new Worker("Jay", Currencies.Usd.Of(44, 2).PerHour()),
        new Worker("Jamie", Currencies.Usd.Of(68, 2).PerHour())
    }.Once();

    public static IEnumerable<Worker> GetWorkers() =>
        GetRawWorkers().Zip(
            ReplicatingOperators.GetRandomValues(1/.8F, 1.2F),
            (worker, factor) => worker.ScalePayRate((decimal)factor));

    public static IEnumerable<Worker> GetWorkers(int count) =>
        GetWorkers().Take(count);

    public static IEnumerable<Worker> GetWorkersUniqueRate(int count) =>
        GetWorkers().DistinctBy(worker => worker.Rate).Take(count);

    private static IEnumerable<Worker> GetRawWorkers()
    {
        while (true)
        {
            foreach (Worker worker in TestData) yield return worker;
        }
    }
}