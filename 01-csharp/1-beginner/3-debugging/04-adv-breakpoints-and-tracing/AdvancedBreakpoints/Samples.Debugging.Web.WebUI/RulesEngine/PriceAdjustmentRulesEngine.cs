using Samples.Debugging.Web.WebUI.Models;

namespace Samples.Debugging.Web.WebUI.RulesEngine
{
    public class PriceAdjustmentRulesEngine
    {
        List<IAdjustmentRule> rules = new List<IAdjustmentRule>();

        public PriceAdjustmentRulesEngine()
        {
            rules.Add(new BreakfastAdjustmentRule());
            rules.Add(new LunchAdjustmentRule());
            rules.Add(new DinnerAdjustmentRule());
        }

        public double CalculateAdjustedPrice(Expense ex)
        {
            double expensePrice = ex.Price;

            foreach(var rule in rules)
            {
                if (rule.IsApplicable(ex))
                {
                    expensePrice = rule.Evaluate(ex);
                }
            }

            return expensePrice;

        }
    }
}
