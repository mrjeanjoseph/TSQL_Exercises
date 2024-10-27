using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Samples.Debugging.Web.WebUI.Data;
using Samples.Debugging.Web.WebUI.Models;
using Samples.Debugging.Web.WebUI.Repositories;

namespace Samples.Debugging.Web.WebUI.Pages.Expenses
{
    public class IndexModel : PageModel
    {

        #region Properties

        private IExpenseRepository _expenseRepository;
        private IExpenseTypeRepository _expenseTypeRepository;

        private int userId = 123;

        [BindProperty(SupportsGet = true)]
        public string SearchDescription { get; set; }

        [BindProperty(SupportsGet = true)]
        public int SearchExpenseType { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchLocation { get; set; }

        [BindProperty(SupportsGet = true)]
        [DataType(DataType.Date)]
        public DateTime SearchDateStart { get; set; }

        [BindProperty(SupportsGet = true)]
        [DataType(DataType.Date)]
        public DateTime SearchDateEnd { get; set; }

        [BindProperty(SupportsGet = true)]
        [DataType(DataType.Currency)]
        public double SearchPriceMin { get; set; }

        [BindProperty(SupportsGet = true)]
        [DataType(DataType.Currency)]
        public double SearchPriceMax { get; set; }

        public IList<Expense> Expenses { get; set; }

        [DataType(DataType.Currency)]
        public double AmountTotal { get; set; }

        public SelectList ExpenseTypeList { get; set; }

        #endregion

        #region ctor

        public IndexModel(IExpenseRepository expenseRepository, IExpenseTypeRepository expenseTypeRepository)
        {
            _expenseRepository = expenseRepository;
            _expenseTypeRepository = expenseTypeRepository;
        }

        #endregion

        public async Task OnGetAsync()
        {
            // get list of expenses based on filter criteria
            Expenses = await _expenseRepository.SearchExpenses(userId, SearchDescription, SearchExpenseType, SearchLocation, SearchDateStart, SearchDateEnd, SearchPriceMin, SearchPriceMax);


            // total the expense prices
            foreach(Expense expense in Expenses)
            {
                AmountTotal += expense.Price;
            }

            // populate the filter criteria on the View
            ExpenseTypeList = new SelectList(_expenseTypeRepository.GetExpenseTypes(), "ID", "Name");

            // use the lowest and highest dates of retrieved expenses as the default values
            SearchDateStart = _expenseRepository.GetMinExpenseDate(userId);
            SearchDateEnd = _expenseRepository.GetMaxExpenseDate(userId);

        }
    }
}
