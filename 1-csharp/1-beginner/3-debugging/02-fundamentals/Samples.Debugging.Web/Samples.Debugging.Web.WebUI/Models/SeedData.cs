using Microsoft.EntityFrameworkCore;
using Samples.Debugging.Web.WebUI.Data;

namespace Samples.Debugging.Web.WebUI.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ProjectContext(
                serviceProvider.GetRequiredService<DbContextOptions<ProjectContext>>()))
            {
                if (context == null || context.ExpenseTypes == null)
                {
                    throw new ArgumentNullException("Null ProjectContext");
                }

                if (context.ExpenseTypes.Any())
                {
                    return;
                }

                context.ExpenseTypeCategories.AddRange(
                    new ExpenseTypeCategory
                    {
                        ID = 1,
                        Name = "Expenses"
                    },
                    new ExpenseTypeCategory
                    {
                        ID = 2,
                        Name = "Vehicle"
                    },
                    new ExpenseTypeCategory
                    {
                        ID = 3,
                        Name = "Home Office"
                    }
                );

                context.ExpenseTypes.AddRange(
                    new ExpenseType
                    {
                        Name = "Advertising",
                        CategoryId = 1
                    }, 
                    new ExpenseType
                    {
                        Name = "Fuel (not vehicles)",
                        CategoryId = 1
                    }, 
                    new ExpenseType
                    {
                        Name = "Repairs & Maintenance",
                        CategoryId = 1
                    }, 
                    new ExpenseType
                    {
                        Name = "Meals & Entertainment",
                        CategoryId = 1
                    }, 
                    new ExpenseType
                    {
                        Name = "Supplies",
                        CategoryId = 1
                    }, 
                    new ExpenseType
                    {
                        Name = "Office Expenses",
                        CategoryId = 1
                    }, 
                    new ExpenseType
                    {
                        Name = "Rent",
                        CategoryId = 1
                    }, 
                    new ExpenseType
                    {
                        Name = "Property Taxes",
                        CategoryId = 1
                    }, 
                    new ExpenseType
                    {
                        Name = "Travel",
                        CategoryId = 1
                    }, 
                    new ExpenseType
                    {
                        Name = "Telephone & Utilities",
                        CategoryId = 1
                    }, 
                    new ExpenseType
                    {
                        Name = "Licenses, Dues, Memberships",
                        CategoryId = 1
                    },
                    new ExpenseType
                    {
                        Name = "Salaries, Wages and Benefits",
                        CategoryId = 1
                    },
                    new ExpenseType
                    {
                        Name = "Misc",
                        CategoryId = 1
                    },
                    new ExpenseType
                     {
                         Name = "Fuel",
                         CategoryId = 2
                     },
                    new ExpenseType
                    {
                        Name = "Repairs & Maintenance",
                        CategoryId = 2
                    },
                    new ExpenseType
                    {
                        Name = "Insurance",
                        CategoryId = 2
                    },
                    new ExpenseType
                    {
                        Name = "License & Registration",
                        CategoryId = 2
                    },
                    new ExpenseType
                    {
                        Name = "Interest (if financed)",
                        CategoryId = 2
                    },
                    new ExpenseType
                    {
                        Name = "Lease Costs (if leased)",
                        CategoryId = 2
                    },
                    new ExpenseType
                    {
                        Name = "Heat",
                        CategoryId = 3
                    },
                    new ExpenseType
                    {
                        Name = "Electricity",
                        CategoryId = 3
                    },
                    new ExpenseType
                    {
                        Name = "Insurance",
                        CategoryId = 3
                    },
                    new ExpenseType
                    {
                        Name = "Maintenance",
                        CategoryId = 3
                    },
                    new ExpenseType
                    {
                        Name = "Mortgage Interest",
                        CategoryId = 3
                    },
                    new ExpenseType
                    {
                        Name = "Property Taxes",
                        CategoryId = 3
                    },
                    new ExpenseType
                    {
                        Name = "Phone",
                        CategoryId = 3
                    },
                    new ExpenseType
                    {
                        Name = "Water",
                        CategoryId = 3
                    },
                    new ExpenseType
                    {
                        Name = "Internet",
                        CategoryId = 3
                    },
                    new ExpenseType
                    {
                        Name = "Cable",
                        CategoryId = 3
                    },
                    new ExpenseType
                    {
                        Name = "Other",
                        CategoryId = 3
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
