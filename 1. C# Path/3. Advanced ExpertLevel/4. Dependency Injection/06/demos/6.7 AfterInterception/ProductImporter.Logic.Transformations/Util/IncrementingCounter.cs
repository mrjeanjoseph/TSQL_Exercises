namespace ProductImporter.Logic.Transformation.Util;

public class IncrementingCounter : IIncrementingCounter, IDisposable
{
    private int _counter = -1;

    public void Dispose()
    {
        ; // Nothing to do, just a place to add a breakpoint
    }

    public int GetNext()
    {
        _counter++;

        return _counter;
    }
}
