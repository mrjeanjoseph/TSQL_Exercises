using ProductImporter.Model;

namespace ProductImporter.Logic.Transformation;

public interface IProductTransformer
{
    Product ApplyTransformations(Product product);
}
