using ProductImporter.Model;

namespace ProductImporter.Logic.Source;

public interface IPriceParser
{
    Money Parse(string price);
}
