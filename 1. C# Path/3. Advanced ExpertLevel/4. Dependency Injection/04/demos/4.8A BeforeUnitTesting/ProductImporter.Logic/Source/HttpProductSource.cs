using ProductImporter.Logic.Shared;
using ProductImporter.Model;
using System.Text.Json;

namespace ProductImporter.Logic.Source;

public class HttpProductSource : IProductSource
{
    private HttpClient _httpClient;
    private IImportStatistics _importStatistics;

    private readonly Queue<Product> _remainingProducts;

    public HttpProductSource(HttpClient httpClient, IImportStatistics importStatistics)
    {
        _httpClient = httpClient;
        _importStatistics = importStatistics;

        _remainingProducts = new Queue<Product>();
    }


    public void Close()
    {
        ; // Empty by design
    }

    public Product GetNextProduct()
    {
        var product =  _remainingProducts.Dequeue();
        _importStatistics.IncrementImportCount();

        return product;
    }

    public bool hasMoreProducts()
    {
        return _remainingProducts.Any();
    }

    public async Task OpenAsync()
    {
        using var productsStream = await _httpClient.GetStreamAsync("ps-di-files/main/products.json");
        var products = await JsonSerializer.DeserializeAsync<Product[]>(productsStream);

        foreach(var product in products)
        {
            _remainingProducts.Enqueue(product);
        }
    }
}