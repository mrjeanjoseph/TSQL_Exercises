namespace Models.Tests.Data;

public static class Workers
{
    public static IEnumerable<Worker> TestData => new[]
    {
        new Worker("Jack", Currencies.Usd.Of(85.4728M).PerHour()),
        new Worker("Jill", Currencies.Usd.Of(100.6928M).PerHour()),
        new Worker("Joe", Currencies.Usd.Of(61).PerHour()),
        new Worker("Jimmy", Currencies.Usd.Of(124).PerHour()),
        new Worker("Jane", Currencies.Usd.Of(95).PerHour()),
        new Worker("Jake", Currencies.Usd.Of(72).PerHour()),
        new Worker("John", Currencies.Usd.Of(45).PerHour()),
        new Worker("Julie", Currencies.Usd.Of(97).PerHour()),
        new Worker("Jasmin", Currencies.Usd.Of(59.95M).PerHour()),
        new Worker("Jerry", Currencies.Usd.Of(71).PerHour()),
        new Worker("Jacob", Currencies.Usd.Of(55).PerHour()),
        new Worker("Joyce", Currencies.Usd.Of(98.42M).PerHour()),
        new Worker("Jared", Currencies.Usd.Of(64).PerHour()),
        new Worker("Josie", Currencies.Usd.Of(105.6M).PerHour()),
        new Worker("Judith", Currencies.Usd.Of(89).PerHour()),
        new Worker("Jay", Currencies.Usd.Of(44).PerHour()),
        new Worker("Jamie", Currencies.Usd.Of(68).PerHour())
    }.Once();
}