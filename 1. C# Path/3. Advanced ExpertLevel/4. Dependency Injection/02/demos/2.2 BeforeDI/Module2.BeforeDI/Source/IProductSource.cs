using Module2.BeforeDI.Model;

namespace Module2.BeforeDI.Source;

public interface IProductSource
{
    void Open();
    bool hasMoreProducts();
    Product GetNextProduct();
    void Close();
}