namespace ProductImporter.Logic.Transformations;

public class DisposableProductTransformation : IProductTransformation, IDisposable
{
    public void Dispose()
    {
        ; // Nothing to do, just a place to add a breakpoint
    }

    public void Execute()
    {
        ; // Nothing to do, just want to implement the interface
    }
}