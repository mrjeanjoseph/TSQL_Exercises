using System.Collections.Immutable;

namespace Models;

public class MoneyBag : IEnumerable<Money>
{
    private MoneyBag(ImmutableSortedDictionary<Currency, Money> balances)
    {
        this.CurrencyToBalance = balances;
    }
    
    private ImmutableSortedDictionary<Currency, Money> CurrencyToBalance { get; }

    public static MoneyBag Empty => new(ImmutableSortedDictionary<Currency, Money>.Empty);
    public bool IsEmpty => this.CurrencyToBalance.Count == 0;

    public MoneyBag Add(Money other) =>
        this.With(this.FindOrZero(other.Currency, other.Precision).AddStrict(other));

    public MoneyBag Subtract(Money other) =>
        this.With(this.FindOrZero(other.Currency, other.Precision).Subtract(other));

    public bool CanSubtract(Money other) =>
        this.FindOrZero(other.Currency, other.Precision).CanSubtract(other);
    
    private MoneyBag With(Money balance) => new(this.Set(balance));
    
    private ImmutableSortedDictionary<Currency, Money> Set(Money balance) =>
        balance.IsZero ? this.CurrencyToBalance.Remove(balance.Currency)
        : this.CurrencyToBalance.SetItem(balance.Currency, balance);

    public Money Strict => this.Values.Single();
    public bool IsStrict => this.CurrencyToBalance.Count == 1;

    public Money this[Currency currency] => this.CurrencyToBalance[currency];

    private Money FindOrZero(Currency currency, int precision) =>
        this.CurrencyToBalance.TryGetValue(currency, out Money? known) ? known
        : currency.Of(0, precision);

    public IEnumerator<Money> GetEnumerator() => this.Values.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    private IEnumerable<Money> Values => this.CurrencyToBalance.Values;

    public override string ToString() =>
       this.IsEmpty ? "0" : string.Join(" + ", this.Values.Select(money => money.ToString()));
}