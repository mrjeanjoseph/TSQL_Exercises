using ProductImporter.Model;

namespace ProductImporter.Source;

public class PriceParser : IPriceParser
{
    public Money Parse(string price)
    {
        var parts = price.Split(' ');

        var currency = parts[0];
        var amount = decimal.Parse(parts[1]);

        return new Money(currency, amount);
    }
}