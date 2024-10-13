using ProductImporter.Shared;
using ProductImporter.Model;

namespace ProductImporter.Target;

public class CsvProductTarget : IProductTarget
{
    private readonly Configuration _configuration;
    private readonly IProductFormatter _productFormatter;
    private readonly IImportStatistics _importStatistics;

    private StreamWriter? _streamWriter;

    public CsvProductTarget(Configuration configuration, IProductFormatter productFormatter, IImportStatistics importStatistics)
    {
        _configuration = configuration;
        _productFormatter = productFormatter;
        _importStatistics = importStatistics;
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

        _importStatistics.IncrementOutputCount();
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
