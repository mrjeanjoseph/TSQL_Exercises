using BenchmarkDotNet.Attributes;

namespace ConsoleDemo;

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
}