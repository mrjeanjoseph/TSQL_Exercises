namespace ProductImporter.Logic.Transformation.Util;

public class DateTimeProvider : IDateTimeProvider, IDisposable
{
    private readonly DateTime _currentDateTime;

    public DateTimeProvider()
    {
        _currentDateTime = DateTime.UtcNow;
    }

    public void Dispose()
    {
        ; // Nothing to do, just a place to add a breakpoint
    }

    public DateTime GetUtcDateTime()
    {
        return _currentDateTime;
    }
}
