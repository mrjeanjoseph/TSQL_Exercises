using Samples.Debugging.Web.WebUI.Models;

namespace Samples.Debugging.Web.WebUI.Repositories
{
    public interface IExpenseRepository
    {
        Task<Expense> GetExpenseById(int userId);
        Task<IList<Expense>> GetExpenses(int userId);
        Task<IList<Expense>> SearchExpenses(int userId, string description = "", int expenseTypeId = 0, string location = "", DateTime? dateStart = null, DateTime? dateEnd = null, double priceStart = 0, double priceEnd = 0);
        Task<bool> AddExpense(Expense expense);
        Task<int> UpdateExpense(Expense expense);
        DateTime GetMinExpenseDate(int userId);
        DateTime GetMaxExpenseDate(int userId);
        Task<IList<Expense>> GetMonthlyExpenses(int userId, DateTime dateStart, DateTime dateEnd);
    }
}