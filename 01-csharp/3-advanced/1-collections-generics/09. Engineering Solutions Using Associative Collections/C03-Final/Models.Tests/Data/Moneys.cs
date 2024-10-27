namespace Models.Tests.Data;

public static class Moneys
{
    public static IEnumerable<Money> TestData =>
        Currencies.RealisticCurrencies
            .RepeatRandomly()
            .Zip(
                ReplicatingOperators.GetRandomDoubleValues(10, 200),
                ((Currency currency, int factor, int precision) tuple, double value) => (tuple.currency, amount: tuple.factor * value, tuple.precision))
            .Select(tuple => new Money((decimal)tuple.amount, tuple.currency, tuple.precision));
}