using System;
using System.Collections.Generic;
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
    public class EditModel : PageModel
    {
        private IExpenseRepository _expenseRepository;
        private IExpenseTypeRepository _expenseTypeRepository;

        [BindProperty]
        public Expense Expense { get; set; }

        [BindProperty(SupportsGet = true)]
        public int ExpenseTypeCategoryId { get; set; }

        public SelectList ExpenseTypeCategoryList { get; set; }
        public SelectList ExpenseTypeList { get; set; }

        public EditModel(IExpenseRepository expenseRepository, IExpenseTypeRepository expenseTypeRepository)
        {
            _expenseRepository = expenseRepository;
            _expenseTypeRepository = expenseTypeRepository;
        }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Expense = await _expenseRepository.GetExpenseById((int)id);

            if (Expense == null)
            {
                return NotFound();
            }

            ExpenseTypeCategoryId = Expense.ExpenseType.CategoryId;
            PopulateExpenseCategoryDropDownList(Expense.ExpenseType.CategoryId);
            PopulateExpenseTypeDropDownList(Expense.ExpenseTypeID);

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            var emptyExpense = new Expense();

            if (await TryUpdateModelAsync<Expense>(
                emptyExpense,
                "expense",
                s => s.ID, s => s.DateIncurred, s => s.Description, s => s.Location, s => s.Price, s => s.ExpenseTypeID, s => s.UserID))
            {

                try
                {
                    var numberOfUpdates = await _expenseRepository.UpdateExpense(emptyExpense);

                    if (numberOfUpdates < 1)
                    {
                        // TODO: log issue and notify user
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    // TODO: log issue and notify user
                }
            }

            return RedirectToPage("./Index");

        }

        public void PopulateExpenseCategoryDropDownList(object selectedExpenseCategory = null)
        {
            var expenseCategories = _expenseTypeRepository.GetExpenseTypeCategories();
            ExpenseTypeCategoryList = new SelectList(expenseCategories, "ID", "Name", selectedExpenseCategory);
        }


        public void PopulateExpenseTypeDropDownList(object selectedExpenseType = null)
        {
            var expenseTypes = _expenseTypeRepository.GetExpenseTypes();
            ExpenseTypeList = new SelectList(expenseTypes, "ID", "Name", selectedExpenseType);
        }

        public JsonResult OnGetCategories([FromQuery] int categoryId)
        {
            var expenseCategories = _expenseTypeRepository.GetExpenseTypesByCategoryId(categoryId);
            return new JsonResult(expenseCategories);
        }

    }
}
