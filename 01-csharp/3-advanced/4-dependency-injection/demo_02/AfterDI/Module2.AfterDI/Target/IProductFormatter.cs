using Module2.AfterDI.Model;

namespace Module2.AfterDI.Target;

public interface IProductFormatter
{
    string Format(Product product);
    string GetHeaderLine();
}
