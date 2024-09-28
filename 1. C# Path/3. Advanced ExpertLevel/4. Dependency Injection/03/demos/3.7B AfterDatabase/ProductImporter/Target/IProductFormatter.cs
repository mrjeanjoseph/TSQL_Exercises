using ProductImporter.Model;

namespace ProductImporter.Target;

public interface IProductFormatter
{
    string Format(Product product);
    string GetHeaderLine();
}
