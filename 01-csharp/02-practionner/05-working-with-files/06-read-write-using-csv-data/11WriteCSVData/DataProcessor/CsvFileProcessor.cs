using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace DataProcessor;

internal class CsvFileProcessor
{
    public string InputFilePath { get; }
    public string OutputFilePath { get; }

    public CsvFileProcessor(string inputFilePath, string outputFilePath)
    {
        InputFilePath = inputFilePath;
        OutputFilePath = outputFilePath;
    }

    public void Process()
    {
        using StreamReader inputReader = File.OpenText(InputFilePath);

        var csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Comment = '@',
            AllowComments = true,
            TrimOptions = TrimOptions.Trim            
        };
        using CsvReader csvReader = new CsvReader(inputReader, csvConfiguration);
        csvReader.Context.RegisterClassMap<ProcessedOrderMap>();

        IEnumerable<ProcessedOrder> records = csvReader.GetRecords<ProcessedOrder>();

        using StreamWriter output = File.CreateText(OutputFilePath);
        using var csvWriter = new CsvWriter(output, CultureInfo.InvariantCulture);

        csvWriter.WriteRecords(records);
    }
}
