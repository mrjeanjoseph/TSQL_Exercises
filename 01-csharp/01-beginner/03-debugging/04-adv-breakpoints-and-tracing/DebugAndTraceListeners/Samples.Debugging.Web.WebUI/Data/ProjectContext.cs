#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Samples.Debugging.Web.WebUI.Models;

namespace Samples.Debugging.Web.WebUI.Data
{
    public class ProjectContext : DbContext
    {
        public ProjectContext (DbContextOptions<ProjectContext> options)
            : base(options)
        {
        }

        public DbSet<Samples.Debugging.Web.WebUI.Models.Expense> Expenses { get; set; }
        public DbSet<Samples.Debugging.Web.WebUI.Models.ExpenseType> ExpenseTypes { get; set; }
        public DbSet<Samples.Debugging.Web.WebUI.Models.ExpenseTypeCategory> ExpenseTypeCategories { get; set; }

    }
}
