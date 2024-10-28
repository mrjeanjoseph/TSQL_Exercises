using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.IO.Abstractions;

namespace DataProcessor;

internal class CsvFileProcessor
{
    private readonly IFileSystem _fileSystem;

    public string InputFilePath { get; }
    public string OutputFilePath { get; }

    public CsvFileProcessor(string inputFilePath, 
                            string outputFilePath,
                            IFileSystem fileSystem)
    {
        InputFilePath = inputFilePath;
        OutputFilePath = outputFilePath;
        _fileSystem = fileSystem;
    }

    public CsvFileProcessor(string inputFilePath, string outputFilePath)
            : this(inputFilePath, outputFilePath, new FileSystem()) { }

    public void Process()
    {
        using var inputReader = _fileSystem.File.OpenText(InputFilePath);

        var csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Comment = '@',
            AllowComments = true,
            TrimOptions = TrimOptions.Trim            
        };
        using CsvReader csvReader = new CsvReader(inputReader, csvConfiguration);
        csvReader.Context.RegisterClassMap<ProcessedOrderMap>();

        IEnumerable<ProcessedOrder> records = csvReader.GetRecords<ProcessedOrder>();

        using var output = _fileSystem.File.CreateText(OutputFilePath);
        using var csvWriter = new CsvWriter(output, CultureInfo.InvariantCulture);

        csvWriter.WriteRecords(records);
    }
}
