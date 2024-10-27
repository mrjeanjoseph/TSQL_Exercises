using Samples.Debugging.Web.WebUI.Models;

namespace Samples.Debugging.Web.WebUI.Repositories
{
    public interface IExpenseRepository
    {
        Task<Expense> GetExpenseById(int userId);
        Task<IList<Expense>> GetExpenses(int userId);
        Task<bool> AddExpense(Expense expense);
        Task<int> UpdateExpense(Expense expense);
    }
}