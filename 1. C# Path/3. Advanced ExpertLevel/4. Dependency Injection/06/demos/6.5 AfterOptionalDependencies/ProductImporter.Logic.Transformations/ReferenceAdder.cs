using ProductImporter.Model;
using ProductImporter.Logic.Transformation.Util;
using ProductImporter.Transformations;

namespace ProductImporter.Logic.Transformations;

public class ReferenceAdder : IProductTransformation
{
    public const string ReferencePrefix = "PI";

    private readonly IReferenceGenerator _refenceGenerator;

    public IHaveNoImplementation OptionalDependency { get; set; }
    public IProductTransformationContext ProductTransformationContext { get; set; }


    public ReferenceAdder(Lazy<IReferenceGeneratorFactory> referenceGeneratorFactory)
    {
        _refenceGenerator = referenceGeneratorFactory.Value.CreateReferenceGenerator(ReferencePrefix);
    }

    public void Execute()
    {
        var product = ProductTransformationContext.GetProduct();

        var reference = _refenceGenerator.GetReference();

        var newProduct = new Product(product.Id, product.Name.ToLowerInvariant(), product.Price, product.Stock, reference);

        ProductTransformationContext.SetProduct(newProduct);
    }
}