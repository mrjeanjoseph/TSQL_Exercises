using Module2.DIApplied.Model;

namespace Module2.DIApplied.Target;

public interface IProductTarget
{
    void Open();
    void AddProduct(Product product);
    void Close();
}
