using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Samples.Debugging.Web.WebUI.Models;
using Samples.Debugging.Web.WebUI.Repositories;
using Samples.Debugging.Web.WebUI.RulesEngine;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Diagnostics;

namespace Samples.Debugging.Web.WebUI.Pages.Expenses
{
    public class ReportModel : PageModel
    {
        #region Variables and Properties

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

        #endregion

        #region Constructor

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

        #endregion

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

                Debug.WriteLine("Starting Report Details", "Initialization Category");

                Debug.Write("Expenses for month: " + SelectedMonth);
                Debug.WriteLine(" and Year: " + SelectedYear);
                Debug.WriteLine("");

                BuildSummaries();

            }

        }

        /// <summary>
        /// Populate the expense summary data to display
        /// </summary>
        private void BuildSummaries()
        {

            // get list of Expense Type Categories from repository 
            var Categories = _expenseTypeRepository.GetExpenseTypeCategories();

            // Class to implement business rules pattern
            PriceAdjustmentRulesEngine rulesEngine = new PriceAdjustmentRulesEngine();

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

                    var expensesForTypeQuery = Expenses.Where(x => x.ExpenseTypeID == expenseType.ID);
                    var expensesForType = expensesForTypeQuery.ToList();

                    foreach (Expense e in expensesForType)
                    {
                        etSummary.ExpensesCount += 1;

                        // adjust the price according to business rules
                        double expensePrice = rulesEngine.CalculateAdjustedPrice(e);

                        etSummary.ExpensesTotal += expensePrice;

                        Debug.WriteLineIf(e.Price != expensePrice, "The following price was adjusted:");

                        Debug.WriteLine("ID: {0,-5}Date: {1,-20}Category: {2,-30}Description: {3,-30}Price: {4,-10}Adjusted Price: {5,-10}", 
                            e.ID, e.DateIncurred, e.Description, e.ExpenseType.Name, e.Price, expensePrice);

                    }

                    ExpenseTotal += etSummary.ExpensesTotal;

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
