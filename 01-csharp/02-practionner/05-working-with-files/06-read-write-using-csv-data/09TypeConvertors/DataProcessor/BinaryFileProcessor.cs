namespace DataProcessor;

internal class BinaryFileProcessor
{
    public string InputFilePath { get; }
    public string OutputFilePath { get; }

    public BinaryFileProcessor(string inputFilePath, string outputFilePath)
    {
        InputFilePath = inputFilePath;
        OutputFilePath = outputFilePath;
    }

    public void Process()
    {
        var openToReadFrom = new FileStreamOptions { Mode = FileMode.Open };
        using FileStream inputFileStream = File.Open(InputFilePath, openToReadFrom);
        using var binaryReader = new BinaryReader(inputFileStream);

        using FileStream outputFileStream = File.Create(OutputFilePath);
        using var binaryWriter = new BinaryWriter(outputFileStream);       

        byte largestByte = 0;
        
        while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length)
        {
            byte currentByte = binaryReader.ReadByte();

            binaryWriter.Write(currentByte);

            if (currentByte > largestByte)
            {
                largestByte = currentByte;
            }            
        }

        binaryWriter.Write(largestByte);
    }
}
