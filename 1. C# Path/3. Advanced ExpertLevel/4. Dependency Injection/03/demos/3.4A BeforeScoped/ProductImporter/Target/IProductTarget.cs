using ProductImporter.Model;

namespace ProductImporter.Target;

public interface IProductTarget
{
    void Open();
    void AddProduct(Product product);
    void Close();
}
