using Module2.DIApplied.Model;

namespace Module2.DIApplied.Source;

public interface IProductSource
{
    void Open();
    bool hasMoreProducts();
    Product GetNextProduct();
    void Close();
}