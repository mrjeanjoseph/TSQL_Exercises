using Samples.Debugging.Web.WebUI.Models;

namespace Samples.Debugging.Web.WebUI.Repositories
{
    public interface IExpenseTypeRepository
    {
        IEnumerable<ExpenseTypeCategory> GetExpenseTypeCategories();
        IEnumerable<ExpenseType> GetExpenseTypes();
        IEnumerable<ExpenseType> GetExpenseTypesByCategoryId(int categoryId);
    }
}