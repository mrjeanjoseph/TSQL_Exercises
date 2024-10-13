using Module2.AfterDI.Model;

namespace Module2.AfterDI.Source;

public interface IProductSource
{
    void Open();
    bool hasMoreProducts();
    Product GetNextProduct();
    void Close();
}