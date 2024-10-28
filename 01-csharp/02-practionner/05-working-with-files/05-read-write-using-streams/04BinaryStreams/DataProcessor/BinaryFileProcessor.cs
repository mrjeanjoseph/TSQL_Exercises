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

        using FileStream outputFileStream = File.Create(OutputFilePath);

        const int endOfStream = -1;

        int largestByte = 0;

        // Read next byte (as an int): returns -1 if end of stream
        int currentByte = inputFileStream.ReadByte();
        while (currentByte != endOfStream)
        {
            outputFileStream.WriteByte((byte)currentByte);

            if (currentByte > largestByte)
            {
                largestByte = currentByte;
            }

            currentByte = inputFileStream.ReadByte();
        }

        outputFileStream.WriteByte((byte)largestByte);
    }
}
