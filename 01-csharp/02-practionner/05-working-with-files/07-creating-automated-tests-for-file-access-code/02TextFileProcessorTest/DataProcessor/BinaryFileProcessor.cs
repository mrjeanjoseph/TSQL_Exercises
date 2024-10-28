using System.IO.Abstractions;

namespace DataProcessor;

internal class BinaryFileProcessor
{
    private readonly IFileSystem _fileSystem;

    public string InputFilePath { get; }
    public string OutputFilePath { get; }

    public BinaryFileProcessor(string inputFilePath, 
                               string outputFilePath,
                               IFileSystem fileSystem)
    {
        InputFilePath = inputFilePath;
        OutputFilePath = outputFilePath;
        _fileSystem = fileSystem;
    }

    public BinaryFileProcessor(string inputFilePath, string outputFilePath)
            : this(inputFilePath, outputFilePath, new FileSystem()) { }

    public void Process()
    {
        using var inputFileStream = _fileSystem.File.Open(InputFilePath, FileMode.Open);
        using var binaryReader = new BinaryReader(inputFileStream);

        using var outputFileStream = _fileSystem.File.Create(OutputFilePath);
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
