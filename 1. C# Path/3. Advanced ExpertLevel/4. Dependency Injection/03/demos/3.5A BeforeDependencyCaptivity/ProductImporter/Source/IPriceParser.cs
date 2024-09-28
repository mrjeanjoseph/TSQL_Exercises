using ProductImporter.Model;

namespace ProductImporter.Source;

public interface IPriceParser
{
    Money Parse(string price);
}
