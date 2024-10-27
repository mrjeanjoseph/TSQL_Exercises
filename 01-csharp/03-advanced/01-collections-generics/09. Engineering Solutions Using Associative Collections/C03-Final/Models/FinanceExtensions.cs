namespace Models;

public static class FinanceExtensions
{
    public static Money Average(this IEnumerable<Money> sequence)
    {
        using IEnumerator<Money> current = sequence.GetEnumerator();

        if (!current.MoveNext()) throw new Exception("Sequence contains no elements.");

        int count = 1;
        Money sum = current.Current;

        while (current.MoveNext())
        {
             count += 1;
             sum = sum.AddStrict(current.Current);
        }

        return sum.Divide((decimal)count);
    }

    public static PayRate AveragePayRate(this IEnumerable<Worker> workers) =>
        workers.Select(worker => 
            worker.Rate.In(TimeSpan.FromHours(1))).Average().PerHour();
}