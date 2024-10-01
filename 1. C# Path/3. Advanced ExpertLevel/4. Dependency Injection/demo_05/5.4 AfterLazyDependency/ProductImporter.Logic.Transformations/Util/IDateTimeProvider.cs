namespace ProductImporter.Logic.Transformation.Util;

public interface IDateTimeProvider
{
    DateTime GetUtcDateTime();
}

public interface IIncrementingCounter
{
    int GetNext();
}
