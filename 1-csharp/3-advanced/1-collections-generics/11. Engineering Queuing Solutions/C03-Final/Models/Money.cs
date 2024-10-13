namespace Models;

public record Money : IComparable<Money>
{
    private decimal _amount;

    public Money(decimal amount, Currency currency, int precision)
    {
        this.Precision = precision.NonNegative(nameof(precision));
        this.Amount = amount;
        this.Currency = currency;
    }

    public decimal Amount
    {
        get => this._amount;
        init => this._amount = decimal.Round(value.NonNegative(nameof(Amount)), this.Precision);
    }

    public int Precision { get; }

    public Currency Currency { get; init; }

    public bool IsZero => this.Amount == 0;

    public PayRate PerHour() => new(this, TimeSpan.FromHours(1));

    public Money Divide(decimal factor) =>
        this with { Amount = this.Amount / factor.NonZero(nameof(factor)) };

    public Money Multiply(decimal factor) =>
        this with { Amount = this.Amount * factor };

    public Money AddStrict(Money other) =>
        this with { Amount = Amount + this.Compatible(other).Amount };

    public bool CanAddStrict(Money other) =>
        this.IsCompatible(other);

    public MoneyBag Add(Money other) => MoneyBag.Empty.Add(this).Add(other);

    public Money Subtract(Money other) =>
        this.CompareTo(other) >= 0 ? this with { Amount = this.Amount - other.Amount }
        : throw new ArgumentException("Not enough funds");

    public bool CanSubtract(Money other) =>
        this.IsCompatible(other) && this.Amount >= other.Amount;

    public Money WithPrecision(int precision) =>
        new(this.Amount, this.Currency, precision);

    private Money Compatible(Money other) =>
        this.Currency.Equals(other.Currency) ? this.CompatiblePrecision(other)
        : throw new ArgumentException($"Cannot combine currencies {this.Currency} and {other.Currency}");

    private Money CompatiblePrecision(Money other) =>
        this.Precision.Equals(other.Precision) ? other
        : throw new ArgumentException($"Cannot combine money with precisions {this.Precision} and {other.Precision}");

    private bool IsCompatible(Money other) =>
        this.Currency.Equals(other) && this.Precision.Equals(other.Precision);

    public override string ToString() =>
        $"{this.Amount.ToString(this.AmountFormat)} {this.Currency}";

    public int CompareTo(Money? other) =>
        other is null ? 1 : this.Amount.CompareTo(this.Compatible(other).Amount);

    private string AmountFormat =>
        "#,##0" +
        (this.Precision > 0 ? "." + new string('0', this.Precision) : string.Empty);
}