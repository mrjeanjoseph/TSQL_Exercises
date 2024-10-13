using ProductImporter.Model;

namespace ProductImporter.Logic.Target;

public interface IProductTarget
{
    void Open();
    void AddProduct(Product product);
    void Close();
}
