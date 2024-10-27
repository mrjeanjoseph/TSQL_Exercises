using Samples.Debugging.Web.WebUI.Models;

namespace Samples.Debugging.Web.WebUI.RulesEngine
{
    public interface IAdjustmentRule
    {
        bool IsApplicable(Expense ex);
        double Evaluate(Expense ex);
    }
}
