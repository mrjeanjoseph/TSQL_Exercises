using System.Text;
namespace Models.Tests.Data;

public static class ReplicatingOperators
{
    public static IEnumerable<T> RepeatRandomly<T>(this IEnumerable<T> sequence)
    {
        T[] data = sequence.ToArray();
        Random numbersGenerator = new(42);

        while (true)
        {
            yield return data[numbersGenerator.Next(data.Length)];
        }
    }

    public static IEnumerable<Worker> Replicate(
        this IEnumerable<Worker> workers, int count, float payRateRange) =>
        workers.SelectMany(worker => Enumerable.Repeat(worker, count))
            .Zip(GetRandomValues(1 / (1 + payRateRange), 1 + payRateRange), (worker, factor) => worker.Replicate(factor));

    internal static IEnumerable<float> GetRandomValues(float min, float max) =>
        GetRandomNumericValues(rng => rng.NextSingle()).Select(x => min + ((max - min) * x));

    internal static IEnumerable<double> GetRandomDoubleValues(double min, double max) =>
        GetRandomNumericValues(rng => rng.NextDouble()).Select(x => min + ((max - min) * x));

    internal static IEnumerable<char> GetRandomEnglishLetters() =>
        GetRandomNumericValues(rng => rng.Next(26)).Select(i => (char)('a' + i));

    internal static IEnumerable<byte> GetRandomBytes() =>
        GetRandomNumericValues(rng => rng.Next(256)).Select(i => (byte)i);

    internal static IEnumerable<byte[]> GetRandomByteArrays(int length)
    {
        List<byte> pending = new();

        foreach (byte b in GetRandomBytes())
        {
            pending.Add(b);
            if (pending.Count == length)
            {
                yield return pending.ToArray();
                pending.Clear();
            }
        }
    }

    private static IEnumerable<T> GetRandomNumericValues<T>(Func<Random, T> getNext)
    {
        Random numbersGenerator = new(42);
        while (true) yield return getNext(numbersGenerator);
    }

    internal static IEnumerable<string> GetRandomEnglishStrings(int length)
    {
        StringBuilder result = new();

        foreach (char c in GetRandomEnglishLetters())
        {
            result.Append(c);
            if (result.Length == length)
            {
                yield return result.ToString();
                result.Clear();
            }
        }
    }

    private static Worker Replicate(this Worker worker, float payRateFactor) =>
        worker.ScalePayRate((decimal)payRateFactor);
}