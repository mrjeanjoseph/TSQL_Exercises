namespace ProductImporter.Logic.Transformation.Util;

public class ReferenceGenerator : IReferenceGenerator
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IIncrementingCounter _incrementingCounter;

    private readonly string _prefix;

    public ReferenceGenerator(IDateTimeProvider dateTimeProvider, IIncrementingCounter incrementingCounter, string prefix)
    {
        _dateTimeProvider = dateTimeProvider;
        _incrementingCounter = incrementingCounter;
        _prefix = prefix;
    }

    public string GetReference()
    {
        var dateTime = _dateTimeProvider.GetUtcDateTime();

        var reference = $"{_prefix}_{dateTime:yyyy-MM-ddTHH:mm:ss.FFF}-{_incrementingCounter.GetNext():D4}";

        return reference;
    }
}
