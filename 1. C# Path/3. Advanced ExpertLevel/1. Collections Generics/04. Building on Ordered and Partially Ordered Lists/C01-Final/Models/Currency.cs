namespace Models;

public record Currency
{
    private string _code = null!;

    public Currency(string code)
    {
        this.Code = code;
    }

    public string Code
    {
        get => this._code;
        init => this._code = value.NonEmpty(nameof(Code));
    }

    public Money Of(decimal amount) => new(amount, this, 2);

    public override string ToString() => this.Code;
}
