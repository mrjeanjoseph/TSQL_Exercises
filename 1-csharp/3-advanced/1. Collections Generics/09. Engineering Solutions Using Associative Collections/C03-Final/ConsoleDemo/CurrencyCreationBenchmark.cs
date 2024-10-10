using BenchmarkDotNet.Attributes;

namespace ConsoleDemo;

[MemoryDiagnoser]
public class CurrencyCreationBenchmark
{
    [Params(1_000, 10_000, 100_000, 1_000_000)] public int CollectionSize { get; set; }

    private static IEnumerable<string> CurrencyCodes =>
        Currencies.TestCurrencies.Take(10).RepeatRandomly().Codes();
    
    [Benchmark(Baseline = true)]
    public Currency[] PlainCreate()
    {
        Currency[] currencies = new Currency[this.CollectionSize];
        using IEnumerator<string> code = CurrencyCodes.GetEnumerator();
        for (int i = 0; i < currencies.Length; i++)
        {
            code.MoveNext();
            currencies[i] = new(code.Current);
        }
        return currencies;
    }

    [Benchmark]
    public Currency[] CachedCreate()
    {
        HashSet<Currency> knownCurrencies = new();
        Currency[] currencies = new Currency[this.CollectionSize];
        using IEnumerator<string> code = CurrencyCodes.GetEnumerator();
        for (int i = 0; i < currencies.Length; i++)
        {
            code.MoveNext();
            Currency currency = new(code.Current);
            if (knownCurrencies.TryGetValue(currency, out Currency known))
            {
                currency = known;
            }
            else
            {
                knownCurrencies.Add(currency);
            }
            currencies[i] = currency;
        }
        return currencies;
    }

    [Benchmark]
    public Currency[] MemoizedCreate()
    {
        Dictionary<string, Currency> knownCurrencies =
            new(new CurrencyCodeEqualityComparer());
        Currency[] currencies = new Currency[this.CollectionSize];
        using IEnumerator<string> code = CurrencyCodes.GetEnumerator();
        for (int i = 0; i < currencies.Length; i++)
        {
            code.MoveNext();
            if (!knownCurrencies.TryGetValue(code.Current, out currencies[i]))
            {
                knownCurrencies[code.Current] = currencies[i] = new Currency(code.Current);
            }
        }
        return currencies;
    }

    private static void RunTotalMemoryTest(string label, Func<Currency[]> method)
    {
        Currency[] plainData = method();
        Console.WriteLine($"{label}: {GC.GetTotalMemory(true),10:#,##0} bytes");
        GC.KeepAlive(plainData);
    }

    public static void RunTotalMemoryTest(int collectionSize)
    {
        CurrencyCreationBenchmark benchmark = new() { CollectionSize = collectionSize };
        RunTotalMemoryTest("   PlainCreate", benchmark.PlainCreate);
        RunTotalMemoryTest("  CachedCreate", benchmark.CachedCreate);
        RunTotalMemoryTest("MemoizedCreate", benchmark.MemoizedCreate);
    }
}