namespace Models;

public record Money : IComparable<Money>
{
    private decimal _amount;
    private int _precision;

    public Money(decimal amount, Currency currency, int precision)
    {
        this.Precision = precision.NonNegative(nameof(precision));
        this.Amount = decimal.Round(amount.NonNegative(nameof(currency)), precision);
        this.Currency = currency;
    }

    public decimal Amount 
    {
        get => this._amount;
        init => this._amount = value.NonNegative(nameof(Amount));
    }

    public int Precision
    {
        get => this._precision;
        init => this._precision = value.NonNegative(nameof(Precision));
    }

    public Currency Currency { get; init; }

    public PayRate PerHour() => new PayRate(this, TimeSpan.FromHours(1));

    public Money Divide(decimal factor) =>
        this with { Amount = this.Amount / factor.NonZero(nameof(factor)) };

    public Money Multiply(decimal factor) =>
        this with { Amount = this.Amount * factor };

    public Money Add(Money other) =>
        this.Currency.Equals(other.Currency) ? this with { Amount = Amount + other.Amount }
        : throw new ArgumentException($"Cannot add disparate currencies {this.Currency} and {other.Currency}");

    public override string ToString() => 
        $"{this.Amount.ToString(this.AmountFormat)} {this.Currency}";

    public int CompareTo(Money? other) =>
        other is null ? 1
        : this.Currency.Equals(other.Currency) ? this.Amount.CompareTo(other.Amount)
        : throw new ArgumentException($"Cannot compare disparate currencies {this.Currency} and {other.Currency}");

    private string AmountFormat =>
        "#,##0" + 
        (this.Precision > 0 ? "." + new string('0', this.Precision) : string.Empty);
}