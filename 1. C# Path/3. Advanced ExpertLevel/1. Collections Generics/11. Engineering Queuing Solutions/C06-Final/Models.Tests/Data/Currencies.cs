namespace Models.Tests.Data;

public static class Currencies
{
    public static Currency Usd => new("USD");
    public static Currency Eur => new("EUR");
    public static Currency Gbp => new("GBP");
    public static Currency Jpy => new("JPY");

    public static IEnumerable<Currency> TestCurrencies =>
        ReplicatingOperators.GetRandomEnglishStrings(3)
            .Select(code => new Currency(code));

    public static IEnumerable<string> TestCurrencyCodes =>
        TestCurrencies.Select(currency => currency.Code);

    public static IEnumerable<string> Codes(this IEnumerable<Currency> currencies) =>
        currencies.Select(currency => new string(currency.Code));

    public static IEnumerable<(Currency currency, int scalingFactor, int precision)> RealisticCurrencies =>
        new[] { (Usd, 1, 2), (Eur, 1, 4), (Gbp, 1, 2), (Jpy, 100, 0)};
}
