namespace Models;

public class MoneyBag : IEnumerable<Money>
{
    public MoneyBag(IEnumerable<Money> moneys)
    {
        this.CurrencyToBalance = new();
        foreach (Money money in moneys) this.Add(money);
    }

    public MoneyBag(params Money[] moneys)
        : this((IEnumerable<Money>)moneys) { }
    
    private SortedDictionary<Currency, Money> CurrencyToBalance { get; }

    public static MoneyBag Zero => new();
    public bool IsZero => this.CurrencyToBalance.Count == 0;

    public void Add(Money other) =>
        this.Set(this.FindOrZero(other.Currency, other.Precision).AddStrict(other));

    public void Subtract(Money other) =>
        this.Set(this.FindOrZero(other.Currency, other.Precision).Subtract(other));

    public bool CanSubtract(Money other) =>
        this.FindOrZero(other.Currency, other.Precision).CanSubtract(other);
    
    private void Set(Money balance)
    {
        if (balance.IsZero)
            this.CurrencyToBalance.Remove(balance.Currency);
        else
            this.CurrencyToBalance[balance.Currency] = balance;
    }

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
       this.IsZero ? "0" : string.Join(" + ", this.Values.Select(money => money.ToString()));
}