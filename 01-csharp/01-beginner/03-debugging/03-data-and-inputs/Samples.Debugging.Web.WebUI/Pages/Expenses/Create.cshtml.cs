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
    public class CreateModel : PageModel
    {

        private IExpenseRepository _expenseRepository;
        private IExpenseTypeRepository _expenseTypeRepository;

        [BindProperty]
        public Expense Expense { get; set; }

        [BindProperty(SupportsGet = true)]
        public int ExpenseTypeCategoryId { get; set; }

        public SelectList ExpenseTypeCategoryList { get; set; }
        public SelectList ExpenseTypeList { get; set; }


        public CreateModel(IExpenseRepository expenseRepository, IExpenseTypeRepository expenseTypeRepository)
        {
            _expenseRepository = expenseRepository;
            _expenseTypeRepository = expenseTypeRepository;

        }

        public IActionResult OnGet()
        {
            PopulateExpenseCategoryDropDownList();
            PopulateExpenseTypeDropDownList();

            return Page();
        }



        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {

            var emptyExpense = new Expense();


            if (await TryUpdateModelAsync<Expense>(
                emptyExpense,
                "expense",
                s => s.Description, s => s.DateIncurred, s => s.Location, s => s.Price, s => s.ExpenseTypeID))
            {

                emptyExpense.UserID = 123;
                bool success = await _expenseRepository.AddExpense(emptyExpense);

                return RedirectToPage("./Index");
            }

            return Page();

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
            var expenseCategories =  _expenseTypeRepository.GetExpenseTypesByCategoryId(categoryId);
            return new JsonResult(expenseCategories);
        }
    }
}
