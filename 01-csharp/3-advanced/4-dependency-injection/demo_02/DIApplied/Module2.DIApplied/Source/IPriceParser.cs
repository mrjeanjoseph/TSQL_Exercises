using Module2.DIApplied.Model;

namespace Module2.DIApplied.Source;

public interface IPriceParser
{
    Money Parse(string price);
}
