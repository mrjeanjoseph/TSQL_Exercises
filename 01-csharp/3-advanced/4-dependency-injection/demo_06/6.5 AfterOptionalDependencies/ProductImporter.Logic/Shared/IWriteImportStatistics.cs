namespace ProductImporter.Logic.Shared;

public interface IWriteImportStatistics
{
    void IncrementImportCount();
    void IncrementOutputCount();
    void IncrementTransformationCount();
}
