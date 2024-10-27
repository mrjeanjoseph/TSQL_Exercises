using Module2.AfterDI.Model;

namespace Module2.AfterDI.Source;

public interface IPriceParser
{
    Money Parse(string price);
}
