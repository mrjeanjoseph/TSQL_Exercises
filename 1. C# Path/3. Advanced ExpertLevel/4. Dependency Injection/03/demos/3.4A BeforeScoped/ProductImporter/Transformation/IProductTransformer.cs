using ProductImporter.Model;

namespace ProductImporter.Transformation;

public interface IProductTransformer
{
    Product ApplyTransformations(Product product);
}
