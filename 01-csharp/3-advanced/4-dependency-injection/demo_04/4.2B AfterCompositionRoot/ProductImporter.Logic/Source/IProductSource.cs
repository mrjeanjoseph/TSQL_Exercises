using ProductImporter.Model;

namespace ProductImporter.Logic.Source;

public interface IProductSource
{
    void Open();
    bool hasMoreProducts();
    Product GetNextProduct();
    void Close();
}