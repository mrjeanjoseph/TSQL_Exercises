using Microsoft.EntityFrameworkCore;
using Samples.Debugging.Web.WebUI.Data;
using Samples.Debugging.Web.WebUI.Models;

namespace Samples.Debugging.Web.WebUI.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private ProjectContext _projectContext;

        public ExpenseRepository(ProjectContext projectContext)
        {
            _projectContext = projectContext;
        }

        public async Task<IList<Expense>> GetExpenses(int userId)
        {
            return await _projectContext.Expenses
                .Include(x => x.ExpenseType)
                //.Where(x => x.UserID == userId)
                .ToListAsync();
        }

        public async Task<Expense> GetExpenseById(int id)
        {
            var expense = await _projectContext.Expenses
                .Include(ex => ex.ExpenseType)
                .Where(ex => ex.ID == id).FirstOrDefaultAsync();
               
            return expense;
        }

        public async Task<bool> AddExpense(Expense expense)
         {
            _projectContext.Expenses.Add(expense);
            return (await _projectContext.SaveChangesAsync() > 0);
        }

        public async Task<int> UpdateExpense(Expense expense)
        {
            _projectContext.Expenses.Attach(expense).State = EntityState.Modified;
            return await _projectContext.SaveChangesAsync();
        }

    }
}
