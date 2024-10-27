namespace ProductImporter.Util;

public class ReferenceGenerator : IReferenceGenerator
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IIncrementingCounter _incrementingCounter;
    private int counter = -1;

    public ReferenceGenerator(IDateTimeProvider dateTimeProvider, IIncrementingCounter incrementingCounter)
    {
        _dateTimeProvider = dateTimeProvider;
        _incrementingCounter = incrementingCounter;
    }

    public string GetReference()
    {
        counter++;
        var dateTime = _dateTimeProvider.GetUtcDateTime();

        var reference = $"{dateTime:yyyy-MM-ddTHH:mm:ss.FFF}-{_incrementingCounter.GetNext():D4}";

        return reference;
    }
}