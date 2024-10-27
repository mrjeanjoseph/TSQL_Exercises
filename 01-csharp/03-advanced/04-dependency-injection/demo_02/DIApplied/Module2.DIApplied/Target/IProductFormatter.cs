using Module2.DIApplied.Model;

namespace Module2.DIApplied.Target;

public interface IProductFormatter
{
    string Format(Product product);
    string GetHeaderLine();
}
