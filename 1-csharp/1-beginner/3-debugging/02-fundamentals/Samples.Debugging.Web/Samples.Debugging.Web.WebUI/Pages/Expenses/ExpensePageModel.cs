using Samples.Debugging.Web.WebUI.Models;
using Samples.Debugging.Web.WebUI.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Samples.Debugging.Web.WebUI.Pages.Expenses
{
    public class ExpensePageModel
    {
        public SelectList ExpenseCategoryList { get; set; }

        public void PopulateExpenseCategoryDropDownList(ProjectContext _context, object selectedExpenseCategory = null)
        {
            var expenseCategoryQuery = from c in _context.ExpenseTypes
                                   orderby c.Name
                                   select c;

            ExpenseCategoryList = new SelectList(expenseCategoryQuery.AsNoTracking(),
                "ID", "Name", selectedExpenseCategory);

        }
    }
}
