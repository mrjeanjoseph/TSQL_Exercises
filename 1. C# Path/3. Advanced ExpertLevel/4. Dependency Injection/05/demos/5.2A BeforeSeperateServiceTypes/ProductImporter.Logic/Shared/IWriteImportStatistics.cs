namespace ProductImporter.Logic.Shared;

public interface IImportStatistics
{
    string GetStatistics();

    void IncrementImportCount();
    void IncrementOutputCount();
    void IncrementTransformationCount();
}
