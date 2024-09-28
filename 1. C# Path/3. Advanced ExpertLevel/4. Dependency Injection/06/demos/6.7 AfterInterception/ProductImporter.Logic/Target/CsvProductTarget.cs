using CsvHelper;
using Microsoft.Extensions.Options;
using ProductImporter.Logic.Shared;
using ProductImporter.Model;

namespace ProductImporter.Logic.Target;

public class CsvProductTarget : IProductTarget, IDisposable
{
    private readonly IOptions<CsvProductTargetOptions> _csvProductTargetOptions;
    private readonly IWriteImportStatistics _importStatistics;

    private CsvWriter _csvWRiter;

    public CsvProductTarget(IOptions<CsvProductTargetOptions> csvProductTargetOptions, IWriteImportStatistics importStatistics)
    {
        _csvProductTargetOptions = csvProductTargetOptions;
        _importStatistics = importStatistics;
    }

    public void Open()
    {
        var streamWriter = new StreamWriter(_csvProductTargetOptions.Value.TargetCsvPath);
        _csvWRiter = new CsvWriter(streamWriter, System.Globalization.CultureInfo.CurrentCulture, false);

        _csvWRiter.WriteHeader(typeof(Product));
        _csvWRiter.NextRecord();
    }

    public void AddProduct(Product product)
    {
        if (_csvWRiter == null)
            throw new InvalidOperationException("Cannot add products to a target that is not yet open");

        _csvWRiter.WriteRecord(product);
        _csvWRiter.NextRecord();

        _importStatistics.IncrementOutputCount();
    }

    public void Close()
    {
        if (_csvWRiter == null)
            throw new InvalidOperationException("Cannot close a target that is not yet open");

        _csvWRiter.Flush();
    }

    public void Dispose()
    {
        _csvWRiter.Dispose();
    }
}
