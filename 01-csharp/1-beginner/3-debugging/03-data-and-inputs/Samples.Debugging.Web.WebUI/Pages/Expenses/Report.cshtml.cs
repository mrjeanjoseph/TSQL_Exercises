using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Samples.Debugging.Web.WebUI.Models;
using Samples.Debugging.Web.WebUI.Repositories;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Samples.Debugging.Web.WebUI.Pages.Expenses
{
    public class ReportModel : PageModel
    {
        int userId = 123;

        // repositories for accessing data
        private IExpenseRepository _expenseRepository;
        private IExpenseTypeRepository _expenseTypeRepository;

        // lists for filtering
        public List<SelectListItem> YearList { get; set; }
        public List<SelectListItem> MonthList { get; set; }

        // selected values for filtering lists above
        [BindProperty(SupportsGet = true)]
        public int SelectedYear { get; set; }
        [BindProperty(SupportsGet = true)]
        public int SelectedMonth { get; set; }

        // list of expenses for month (not used for data binding)
        public IList<Expense> Expenses { get; set; }

        // list of expense summaries (bound to View)
        public IList<ExpenseSummary> ExpenseSummaries { get; set; }

        // total of all monthly expenses (bound to View)
        [DataType(DataType.Currency)]
        public double ExpenseTotal { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="expenseRepository"></param>
        /// <param name="expenseTypeRepository"></param>
        public ReportModel(IExpenseRepository expenseRepository, IExpenseTypeRepository expenseTypeRepository)
        {
            _expenseRepository = expenseRepository;
            _expenseTypeRepository = expenseTypeRepository;
        }

        /// <summary>
        /// Method that's called when page loads and when Filter button is pressed
        /// </summary>
        /// <returns></returns>
        public async Task OnGet()
        {
            // build the year and month drop down lists for filtering
            BuildFilterChoiceLists();
            
            // initialize the collection that gets bound to the View (even though its initially empty)
            ExpenseSummaries = new List<ExpenseSummary>();

            // when page first loads, these values are zero
            if (SelectedYear == 0 && SelectedMonth == 0)
            {
                SelectedYear = DateTime.Now.Year;
                SelectedMonth = DateTime.Now.Month;
            }
            else
            {
                // get expense data
                DateTime startDate = new DateTime(SelectedYear, SelectedMonth, 1);
                int daysinMonth = DateTime.DaysInMonth(startDate.Year, startDate.Month);
                DateTime endDate = new DateTime(SelectedYear, SelectedMonth, daysinMonth);

                // get list of expenses for the selected month
                Expenses = await _expenseRepository.GetMonthlyExpenses(userId, startDate, endDate);

                BuildSummaries();

            }

        }

        /// <summary>
        /// Populate the expense summary data to display
        /// </summary>
        private void BuildSummaries()
        {

            // query the list of Expenses to group by expense type, sum of expenses and count of each expense type instances
            var query = Expenses.GroupBy(
                x => x.ExpenseType.ID,
                x => x.Price,
                (expenseTypeId, prices) => new { ExpenseTypeID = expenseTypeId, ExpenseTypeTotal = prices.Sum(), ExpenseCount = prices.Count() });

            var queryTotals = query.ToList();

            // get list of Expense Type Categories from repository 
            var Categories = _expenseTypeRepository.GetExpenseTypeCategories();

            // iterate through categories and build data model for binding to the View
            foreach(var category in Categories)
            {
                // create data structure for expense category, and summary of expenses in selected month
                var expenseSummary = new ExpenseSummary();
                expenseSummary.ExpenseTypeCategoryName = category.Name;

                // initialize the list of expenses within the category, so we can add instances for each expense type
                expenseSummary.Summaries = new List<ExpenseTypeSummary>();

                // get master list of expense types for the category
                var expenseTypes = _expenseTypeRepository.GetExpenseTypesByCategoryId(category.ID);

                // add each expense type to list - regardless of whether expenses of this type were incurred
                foreach (var expenseType in expenseTypes)
                {
                    // create data structure to represent expense type for the summary
                    var etSummary = new ExpenseTypeSummary();
                    etSummary.ExpenseTypeID = expenseType.ID;
                    etSummary.ExpenseTypeName = expenseType.Name;
                    
                    // query the list of summaries created earlier in the method (from the expenses for the month)
                    var queryTotalInstance = queryTotals.Where(x => x.ExpenseTypeID == expenseType.ID).FirstOrDefault();

                    // if expense is found, add it to the total
                    if (queryTotalInstance != null)
                    {
                        etSummary.ExpensesCount = queryTotalInstance.ExpenseCount;
                        etSummary.ExpensesTotal = queryTotalInstance.ExpenseTypeTotal;

                        // add to global Total
                        ExpenseTotal += queryTotalInstance.ExpenseTypeTotal;

                    }
                    else
                    {
                        etSummary.ExpensesCount = 0;
                        etSummary.ExpensesTotal = 0;
                    }

                    expenseSummary.Summaries.Add(etSummary);

                } // end loop for expense types

                ExpenseSummaries.Add(expenseSummary);

            } // end loop for expense type categories

        }

        /// <summary>
        /// Build the dropdown lists for months and past 5 years
        /// </summary>
        private void BuildFilterChoiceLists()
        {
            // build year list
            var currentYear = DateTime.Now.Year;
            YearList = new List<SelectListItem>();

            for (int i = 0; i <= 5; i++)
            {
                var year = currentYear - i;
                YearList.Add(new SelectListItem
                {
                    Value = year.ToString(),
                    Text = year.ToString()
                });
            }

            // build month list
            MonthList = new List<SelectListItem>();

            for (int i = 0; i < 12; i++)
            {
                string monthName = CultureInfo.CurrentUICulture.DateTimeFormat.MonthNames[i];
                MonthList.Add(new SelectListItem
                {
                    Value = (i+1).ToString(),
                    Text = monthName,
                });
            }
        }
    }

    /// <summary>
    /// Class for binding Expense Categories to View
    /// </summary>
    public class ExpenseSummary
    {
        public string ExpenseTypeCategoryName { get; set; }
        public List<ExpenseTypeSummary> Summaries { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ExpenseTypeSummary
    {
        public int ExpenseTypeID { get; set; }
        public string ExpenseTypeName { get; set; }
        public int ExpensesCount { get; set; }
        [DataType(DataType.Currency)]
        public double ExpensesTotal { get; set; }
    }
}
