using Module2.DIApplied.Shared;
using Module2.DIApplied.Model;

namespace Module2.DIApplied.Target;

public class ProductTarget : IProductTarget
{
    private readonly Configuration _configuration;
    private readonly IProductFormatter _productFormatter;

    private StreamWriter? _streamWriter;

    public ProductTarget(Configuration configuration, IProductFormatter productFormatter)
    {
        _configuration = configuration;
        _productFormatter = productFormatter;
    }

    public void Open()
    {
        _streamWriter = new StreamWriter(_configuration.TargetCsvPath);

        var headerLine = _productFormatter.GetHeaderLine();
        _streamWriter.WriteLine(headerLine);
    }

    public void AddProduct(Product product)
    {
        if (_streamWriter == null)
            throw new InvalidOperationException("Cannot add products to a target that is not yet open");

        var productLine = _productFormatter.Format(product);
        _streamWriter.WriteLine(productLine);
    }

    public void Close()
    {
        if (_streamWriter == null)
            throw new InvalidOperationException("Cannot close a target that is not yet open");

        _streamWriter.Flush();
        _streamWriter.Close();
    }
}
