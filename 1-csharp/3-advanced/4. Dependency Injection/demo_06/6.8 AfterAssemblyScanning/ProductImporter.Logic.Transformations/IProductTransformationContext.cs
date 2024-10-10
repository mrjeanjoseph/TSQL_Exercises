using ProductImporter.Model;

namespace ProductImporter.Transformations;

public interface IProductTransformationContext
{
    void SetProduct(Product product);
    public Product GetProduct();
    bool IsProductChanged();
}
