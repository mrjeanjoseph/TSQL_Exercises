using ProductImporter.Model;
using ProductImporter.Transformations;

namespace ProductImporter.Logic.Transformations;

public class CurrencyNormalizer : IProductTransformation
{
    private readonly IProductTransformationContext _productTransformationContext;

    public CurrencyNormalizer(IProductTransformationContext productTransformationContext)
    {
        _productTransformationContext = productTransformationContext;
    }

    public void Execute()
    {
        var product = _productTransformationContext.GetProduct();

        if (product.Price.IsoCurrency == Money.USD)
        {
            var newPrice = new Money(Money.EUR, product.Price.Amount * Money.USDToEURRate);
            var newProduct = new Product(product.Id, product.Name, newPrice, product.Stock);

            _productTransformationContext.SetProduct(newProduct);
        }
    }
}
