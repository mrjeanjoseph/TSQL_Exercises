try
{
    IEnumerable<string> codes =
        Currencies.TestCurrencies.Take(10).RepeatRandomly().Codes().Take(1_000_000);
    
    List<Currency> currencies = new();
    foreach (string code in codes)
        currencies.Add(new(code));
    currencies.TrimExcess();
    long nonCachedMemory = GC.GetTotalAllocatedBytes(true);

    List<Currency> cached = currencies.Cached().ToList();
    long cachedMemory = GC.GetTotalAllocatedBytes(true) - nonCachedMemory;

    GC.KeepAlive(cached);
    GC.KeepAlive(currencies);

    Console.WriteLine($"No caching: {nonCachedMemory:#,##0} bytes");
    Console.WriteLine($"    Cached: {cachedMemory:#,##0} bytes");
}
catch (Exception e)
{
    Console.WriteLine($"ERROR: {e.Message}");
}