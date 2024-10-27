using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Samples.Debugging.Web.WebUI.Data;
using Samples.Debugging.Web.WebUI.Models;
using Samples.Debugging.Web.WebUI.Repositories;

namespace Samples.Debugging.Web.WebUI.Pages.Expenses
{
    public class IndexModel : PageModel
    {
        private IExpenseRepository _expenseRepository;

        public IndexModel(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public IList<Expense> Expense { get;set; }

        public async Task OnGetAsync()
        {
            Expense = await _expenseRepository.GetExpenses(123);
        }
    }
}
