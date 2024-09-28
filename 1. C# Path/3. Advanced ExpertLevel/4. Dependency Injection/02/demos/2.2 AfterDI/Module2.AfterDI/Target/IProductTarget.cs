using Module2.AfterDI.Model;

namespace Module2.AfterDI.Target;

public interface IProductTarget
{
    void Open();
    void AddProduct(Product product);
    void Close();
}
