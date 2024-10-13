namespace Models;

public readonly record struct Currency : IComparable<Currency>
{
    private readonly string _code = null!;

    public Currency(string code)
    {
        this.Code = code;
    }

    public string Code
    {
        get => this._code;
        init => this._code = value.NonEmpty(nameof(Code)).ToUpper();
    }

    public int CompareTo(Currency other) =>
        this._code.CompareTo(other._code);

    public Money Of(decimal amount, int precision) => new(amount, this, precision);

    public override string ToString() => this.Code;
}
