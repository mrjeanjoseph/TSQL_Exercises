namespace ProductImporter.Model;

public class Money
{
    public Money(string isoCurrency, decimal amount)
    {
        IsoCurrency = isoCurrency;
        Amount = amount;
    }
    public string IsoCurrency { get; set; }
    public decimal Amount { get; set; }
}