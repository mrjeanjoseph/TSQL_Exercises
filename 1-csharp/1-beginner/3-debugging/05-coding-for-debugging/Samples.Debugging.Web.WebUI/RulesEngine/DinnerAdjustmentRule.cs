using Samples.Debugging.Web.WebUI.Models;

namespace Samples.Debugging.Web.WebUI.RulesEngine
{
    public class DinnerAdjustmentRule : IAdjustmentRule
    {
        public bool IsApplicable(Expense ex)
        {
            if (ex.ExpenseType.Name.Contains("Meals & Entertainment") && 
                (
                    ex.Description.ToLower().Contains("dinner") 
                    || ex.Description.ToLower().Contains("supper")
                ))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public double Evaluate(Expense ex)
        {
            if (ex.Price > 15.00)
            {
                return 15.00;
            }
            else
            {
                return ex.Price;
            }
        }

    }
}
