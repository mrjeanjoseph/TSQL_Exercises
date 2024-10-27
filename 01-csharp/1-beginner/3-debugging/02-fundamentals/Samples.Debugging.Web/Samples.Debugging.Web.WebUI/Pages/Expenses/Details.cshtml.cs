using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Samples.Debugging.Web.WebUI.Data;
using Samples.Debugging.Web.WebUI.Models;

namespace Samples.Debugging.Web.WebUI.Pages.Expenses
{
    public class DetailsModel : PageModel
    {
        private readonly Samples.Debugging.Web.WebUI.Data.ProjectContext _context;

        public DetailsModel(Samples.Debugging.Web.WebUI.Data.ProjectContext context)
        {
            _context = context;
        }

        public Expense Expense { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Expense = await _context.Expenses.FirstOrDefaultAsync(m => m.ID == id);

            if (Expense == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
