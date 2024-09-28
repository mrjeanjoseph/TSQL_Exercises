using Module2.BeforeDI.Model;

namespace Module2.BeforeDI.Source;

public interface IPriceParser
{
    Money Parse(string price);
}
