using Module2.BeforeDI.Model;

namespace Module2.BeforeDI.Target;

public interface IProductFormatter
{
    string Format(Product product);
    string GetHeaderLine();
}
