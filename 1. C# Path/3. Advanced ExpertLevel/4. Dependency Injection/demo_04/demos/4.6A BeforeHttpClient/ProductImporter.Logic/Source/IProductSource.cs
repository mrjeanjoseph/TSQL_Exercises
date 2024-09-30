using ProductImporter.Model;

namespace ProductImporter.Logic.Source;

public interface IProductSource
{
    Task OpenAsync();
    bool hasMoreProducts();
    Product GetNextProduct();
    void Close();
}