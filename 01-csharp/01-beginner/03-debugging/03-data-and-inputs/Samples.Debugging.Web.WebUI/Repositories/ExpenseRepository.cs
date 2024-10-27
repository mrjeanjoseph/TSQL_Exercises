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

        public async Task<IList<Expense>> SearchExpenses(int userId, string description = null, int expenseTypeId=0, 
            string location=null, DateTime? dateStart=null, DateTime? dateEnd=null, double priceStart=0, double priceEnd=0)
        {
            var expenses = (from e in _projectContext.Expenses
                            join et in _projectContext.ExpenseTypes on e.ExpenseTypeID equals et.ID
                            orderby e.DateIncurred ascending
                            select e).Include("ExpenseType");

            if (!string.IsNullOrEmpty(description))
            {
                expenses = expenses.Where(e => e.Description.Contains(description));
            }
            if (!string.IsNullOrEmpty(location))
            {
                expenses = expenses.Where(e => e.Location.Contains(location));
            }
            if (expenseTypeId != 0)
            {
                expenses = expenses.Where(e => e.ExpenseTypeID==expenseTypeId);
            }
            if(dateStart != DateTime.MinValue)
            {
                expenses = expenses.Where(e => e.DateIncurred >= dateStart);
            }
            if (dateEnd != DateTime.MinValue)
            {
                expenses = expenses.Where(e => e.DateIncurred <= dateEnd);
            }
            if(priceStart != 0)
            {
                expenses = expenses.Where(e => e.Price >= priceStart);
            }
            if (priceEnd != 0)
            {
                expenses = expenses.Where(e => e.Price <= priceEnd);
            }

            return await expenses.ToListAsync();
        }

        public async Task<IList<Expense>> GetMonthlyExpenses(int userId, DateTime dateStart, DateTime dateEnd)
        {
            return await _projectContext.Expenses
                .Include(e => e.ExpenseType)
                .Where(e => e.UserID == userId)
                .Where(e => (e.DateIncurred >= dateStart) && (e.DateIncurred <= dateEnd))
                .OrderBy(e => e.DateIncurred)
                .ToListAsync();
        }

        public async Task<Expense> GetExpenseById(int id)
        {
            var expense = await _projectContext.Expenses
                .Include(ex => ex.ExpenseType)
                .Where(ex => ex.ID == id).FirstOrDefaultAsync();
               
            return expense;
        }

        public DateTime GetMinExpenseDate(int userId)
        {
            var MinDate = (from d in _projectContext.Expenses
                           where d.UserID == userId
                           select d.DateIncurred).Min();

            return MinDate;
        }

        public DateTime GetMaxExpenseDate(int userId)
        {
            var MaxDate = (from d in _projectContext.Expenses
                           where d.UserID == userId
                           select d.DateIncurred).Max();

            return MaxDate;
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
