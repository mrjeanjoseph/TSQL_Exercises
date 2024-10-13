namespace Models.Tests.Data;

public static class ReplicatingOperators
{
    public static IEnumerable<Worker> Replicate(this IEnumerable<Worker> workers, int count, float payRateRange) =>
        workers.SelectMany(worker => Enumerable.Repeat(worker, count))
            .Zip(GetRandomValues(1 / (1 + payRateRange), 1 + payRateRange), (worker, factor) => worker.Replicate(factor));

    internal static IEnumerable<float> GetRandomValues(float min, float max)
    {
        Random numbersGenerator = new(42);
        float range = max - min;

        while (true)
        {
            yield return (numbersGenerator.NextSingle() * range) + min;
        }
    }

    private static Worker Replicate(this Worker worker, float payRateFactor) =>
        worker.ScalePayRate((decimal)payRateFactor);
}