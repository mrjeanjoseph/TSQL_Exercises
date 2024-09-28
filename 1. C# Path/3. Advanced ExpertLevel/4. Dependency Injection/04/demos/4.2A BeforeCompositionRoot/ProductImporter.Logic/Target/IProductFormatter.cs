using ProductImporter.Model;

namespace ProductImporter.Logic.Target;

public interface IProductFormatter
{
    string Format(Product product);
    string GetHeaderLine();
}
