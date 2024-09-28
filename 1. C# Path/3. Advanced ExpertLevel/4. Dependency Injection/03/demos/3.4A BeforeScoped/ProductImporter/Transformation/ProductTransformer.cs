using Microsoft.Extensions.DependencyInjection;
using ProductImporter.Model;
using ProductImporter.Shared;
using ProductImporter.Transformation.Transformations;

namespace ProductImporter.Transformation;

public class ProductTransformer : IProductTransformer
{

    public Product ApplyTransformations(Product product)
    {
        // Do work here
    }
}
