namespace Models;

public class MoneyBag : IEnumerable<Money>
{
    public MoneyBag(IEnumerable<Money> moneys) => throw new NotImplementedException();

    public MoneyBag(params Money[] moneys)
        : this((IEnumerable<Money>)moneys) { }
    
    private Dictionary<Currency, Money> CurrencyToBalance { get; }

    public static MoneyBag Zero => new();
    public bool IsZero => throw new NotImplementedException();

    public void Add(Money other) => throw new NotImplementedException();
    public void Subtract(Money other) => throw new NotImplementedException();
    public bool CanSubtract(Money other) => throw new NotImplementedException();

    public Money Strict => throw new NotImplementedException();
    public bool IsStrict => throw new NotImplementedException();

    public Money this[Currency currency] => throw new NotImplementedException();

    public IEnumerator<Money> GetEnumerator() => throw new NotImplementedException();
    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    public override string ToString() => throw new NotImplementedException();
}