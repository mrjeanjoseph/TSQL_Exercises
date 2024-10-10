using ProductImporter.Model;

namespace ProductImporter.Logic.Transformation;

public class NullProductTransformer : IProductTransformer
{
    public Product ApplyTransformations(Product product)
    {
        return product;
    }
}