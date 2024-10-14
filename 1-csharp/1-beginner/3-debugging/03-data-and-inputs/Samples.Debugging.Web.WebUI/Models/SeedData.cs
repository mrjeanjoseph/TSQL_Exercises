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

                if (!context.ExpenseTypes.Any())
                {
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

                // Create sample expense data

                // get date information to add expenses to last month
                var lastMonthTemp = DateTime.Now.AddMonths(-1);
                int numDaysLastMonth = DateTime.DaysInMonth(lastMonthTemp.Year, lastMonthTemp.Month);
                var lastMonthLastDay = new DateTime(lastMonthTemp.Year, lastMonthTemp.Month, numDaysLastMonth);
                numDaysLastMonth *= -1; // make the number negative to use in creating random dates

                // get date information to add expenses to the month before last
                var secondLastMonthTemp = DateTime.Now.AddMonths(-2);
                int numDaysSecondLastMonth = DateTime.DaysInMonth(secondLastMonthTemp.Year, secondLastMonthTemp.Month);
                var secondLastMonthLastDay = new DateTime(secondLastMonthTemp.Year, secondLastMonthTemp.Month, numDaysSecondLastMonth);
                numDaysSecondLastMonth *= -1; // make the number negative to use in creating random dates

                // get date information to add expenses to the month before last
                var thirdLastMonthTemp = DateTime.Now.AddMonths(-3);
                int numDaysThirdLastMonth = DateTime.DaysInMonth(thirdLastMonthTemp.Year, thirdLastMonthTemp.Month);
                var thirdLastMonthLastDay = new DateTime(thirdLastMonthTemp.Year, thirdLastMonthTemp.Month, numDaysThirdLastMonth);
                numDaysThirdLastMonth *= -1; // make the number negative to use in creating random dates

                Random randomInt = new Random();

                int userId = 123;

                // hard code first entry so we can search for it to check if sample data exists
                string sampleDescription = "Lunch";
                string sampleLocation = "Chicken Hut";
                double samplePrice = 8.25;
                var dateMod = lastMonthLastDay.AddDays(randomInt.Next(numDaysLastMonth-2, -1));

                // check if first sample expense is already created
                var sampleExp = context.Expenses.Where(e => e.Description == sampleDescription).Where(e => e.Location == sampleLocation)
                    .Where(e => e.Price == samplePrice).FirstOrDefault();

                if(sampleExp == null)
                {

                    var mealType = context.ExpenseTypes
                         .Where(t => t.Name == "Meals & Entertainment").FirstOrDefault();

                    var mealExp1 = new Expense
                    {
                        Description = sampleDescription,
                        Location = sampleLocation,
                        Price = samplePrice,
                        ExpenseTypeID = mealType.ID,
                        UserID = userId,
                        DateIncurred = dateMod
                    };

                    var mealExp2 = new Expense
                    {
                        Description = "Dinner",
                        Location = "The Steakhouse",
                        Price = 35.87,
                        ExpenseTypeID = mealType.ID,
                        UserID = userId,
                        DateIncurred = dateMod
                    };

                    dateMod = secondLastMonthLastDay.AddDays(randomInt.Next(numDaysSecondLastMonth-2, -1));

                    var mealExp3 = new Expense
                    {
                        Description = "Lunch",
                        Location = "Burger Joint",
                        Price = 11.55,
                        ExpenseTypeID = mealType.ID,
                        UserID = userId,
                        DateIncurred = dateMod
                    };

                    var mealExp4 = new Expense
                    {
                        Description = "Dinner",
                        Location = "Veggie Heaven",
                        Price = 16.22,
                        ExpenseTypeID = mealType.ID,
                        UserID = userId,
                        DateIncurred = dateMod
                    };

                    dateMod = lastMonthLastDay.AddDays(randomInt.Next(numDaysLastMonth - 2, -1));

                    var mealExp5 = new Expense
                    {
                        Description = "Lunch",
                        Location = "Chicken Hut",
                        Price = 7.25,
                        ExpenseTypeID = mealType.ID,
                        UserID = userId,
                        DateIncurred = dateMod
                    };

                    var mealExp6 = new Expense
                    {
                        Description = "Dinner",
                        Location = "Barney's Cuisine",
                        Price = 85.12,
                        ExpenseTypeID = mealType.ID,
                        UserID = userId,
                        DateIncurred = dateMod
                    };

                    dateMod = secondLastMonthLastDay;

                    var mealExp7 = new Expense
                    {
                        Description = "Lunch",
                        Location = "Joe's Burger Barn",
                        Price = 10.00,
                        ExpenseTypeID = mealType.ID,
                        UserID = userId,
                        DateIncurred = dateMod
                    };

                    var mealExp8 = new Expense
                    {
                        Description = "Dinner",
                        Location = "The House of Hotcakes",
                        Price = 34.22,
                        ExpenseTypeID = mealType.ID,
                        UserID = userId,
                        DateIncurred = dateMod
                    };

                    var mealExp9 = new Expense
                    {
                        Description = "Lunch",
                        Location = "Joe's Burger Barn",
                        Price = 10.00,
                        ExpenseTypeID = mealType.ID,
                        UserID = userId,
                        DateIncurred = thirdLastMonthLastDay.AddDays(randomInt.Next(numDaysThirdLastMonth - 2, -1))
                };

                    var mealExp10 = new Expense
                    {
                        Description = "Dinner",
                        Location = "The House of Hotcakes",
                        Price = 34.22,
                        ExpenseTypeID = mealType.ID,
                        UserID = userId,
                        DateIncurred = thirdLastMonthLastDay
                    };

                    var suppliesType = context.ExpenseTypes
                         .Where(t => t.Name == "Supplies").FirstOrDefault();

                    var supplyExp1 = new Expense
                    {
                        Description = "Pens",
                        Location = "The Office Place",
                        Price = 13.45,
                        ExpenseTypeID = suppliesType.ID,
                        UserID = userId,
                        DateIncurred = secondLastMonthLastDay.AddDays(randomInt.Next(numDaysSecondLastMonth - 2, -1))
                };

                    var supplyExp2 = new Expense
                    {
                        Description = "Paper Clips",
                        Location = "Online Giant",
                        Price = 5.35,
                        ExpenseTypeID = suppliesType.ID,
                        UserID = userId,
                        DateIncurred = lastMonthLastDay.AddDays(randomInt.Next(numDaysLastMonth - 2, -1))
                    };

                    var supplyExp3 = new Expense
                    {
                        Description = "Hand Sanitizer",
                        Location = "Barb's Convenience",
                        Price = 8.00,
                        ExpenseTypeID = suppliesType.ID,
                        UserID = userId,
                        DateIncurred = lastMonthLastDay.AddDays(randomInt.Next(numDaysLastMonth - 2, -1))
                    };

                    var supplyExp4 = new Expense
                    {
                        Description = "Face Masks",
                        Location = "Seller's",
                        Price = 8.55,
                        ExpenseTypeID = suppliesType.ID,
                        UserID = userId,
                        DateIncurred = secondLastMonthLastDay.AddDays(randomInt.Next(numDaysSecondLastMonth - 2, -1))
                    };

                    var supplyExp5 = new Expense
                    {
                        Description = "Air Freshener",
                        Location = "Sellers",
                        Price = 7.25,
                        ExpenseTypeID = suppliesType.ID,
                        UserID = userId,
                        DateIncurred = secondLastMonthLastDay.AddDays(randomInt.Next(numDaysSecondLastMonth - 2, -1))
                    };

                    var supplyExp6 = new Expense
                    {
                        Description = "Copy Paper",
                        Location = "The Office Shop",
                        Price = 25.99,
                        ExpenseTypeID = suppliesType.ID,
                        UserID = userId,
                        DateIncurred = secondLastMonthLastDay
                    };

                    var supplyExp7 = new Expense
                    {
                        Description = "Printer Ink",
                        Location = "The Office Shop",
                        Price = 50.00,
                        ExpenseTypeID = suppliesType.ID,
                        UserID = userId,
                        DateIncurred = lastMonthLastDay.AddDays(randomInt.Next(numDaysLastMonth - 2, -1))
                    };

                    var supplyExp8 = new Expense
                    {
                        Description = "Monitor Cleaner",
                        Location = "The Office Shop",
                        Price = 12.33,
                        ExpenseTypeID = suppliesType.ID,
                        UserID = userId,
                        DateIncurred = lastMonthLastDay.AddDays(randomInt.Next(numDaysLastMonth - 2, -1))
                    };

                    var supplyExp9 = new Expense
                    {
                        Description = "Printer Ink",
                        Location = "The Office Shop",
                        Price = 50.00,
                        ExpenseTypeID = suppliesType.ID,
                        UserID = userId,
                        DateIncurred = thirdLastMonthLastDay.AddDays(randomInt.Next(numDaysThirdLastMonth - 2, -1))
                    };

                    var supplyExp10 = new Expense
                    {
                        Description = "Monitor Cleaner",
                        Location = "The Office Shop",
                        Price = 12.33,
                        ExpenseTypeID = suppliesType.ID,
                        UserID = userId,
                        DateIncurred = thirdLastMonthLastDay.AddDays(randomInt.Next(numDaysThirdLastMonth - 2, -1))
                    };

                    var FuelType = context.ExpenseTypes
                         .Where(t => t.Name == "Fuel").FirstOrDefault();

                    var fuelExp1 = new Expense
                    {
                        Description = "Gas",
                        Location = "Hale's Gas Bar",
                        Price = 50.00,
                        ExpenseTypeID = FuelType.ID,
                        UserID = userId,
                        DateIncurred = lastMonthLastDay.AddDays(randomInt.Next(numDaysLastMonth - 2, -1))
                    };

                    var fuelExp2 = new Expense
                    {
                        Description = "Gas",
                        Location = "Atlantic Gas",
                        Price = 62.50,
                        ExpenseTypeID = FuelType.ID,
                        UserID = userId,
                        DateIncurred = secondLastMonthLastDay.AddDays(randomInt.Next(numDaysSecondLastMonth - 2, -1))
                    };

                    var fuelExp3 = new Expense
                    {
                        Description = "Gas",
                        Location = "Hale's Gas Bar",
                        Price = 30.00,
                        ExpenseTypeID = FuelType.ID,
                        UserID = userId,
                        DateIncurred = lastMonthLastDay.AddDays(randomInt.Next(numDaysLastMonth - 2, -1))
                    };

                    var fuelExp4 = new Expense
                    {
                        Description = "Gas",
                        Location = "Atlantic Gas",
                        Price = 44.50,
                        ExpenseTypeID = FuelType.ID,
                        UserID = userId,
                        DateIncurred = secondLastMonthLastDay.AddDays(randomInt.Next(numDaysSecondLastMonth - 2, -1))
                    };

                    var fuelExp5 = new Expense
                    {
                        Description = "Gas",
                        Location = "Hale's Gas Bar",
                        Price = 30.00,
                        ExpenseTypeID = FuelType.ID,
                        UserID = userId,
                        DateIncurred = thirdLastMonthLastDay.AddDays(randomInt.Next(numDaysThirdLastMonth - 2, -1))
                    };

                    var fuelExp6 = new Expense
                    {
                        Description = "Gas",
                        Location = "Atlantic Gas",
                        Price = 44.50,
                        ExpenseTypeID = FuelType.ID,
                        UserID = userId,
                        DateIncurred = thirdLastMonthLastDay.AddDays(randomInt.Next(numDaysThirdLastMonth - 2, -1))
                    };

                    context.Expenses.AddRange(
                        mealExp1,
                        mealExp2,
                        mealExp3,
                        mealExp4,
                        mealExp5,
                        mealExp6,
                        mealExp7,
                        mealExp8,
                        mealExp9,                        
                        mealExp10,
                        supplyExp1,
                        supplyExp2,
                        supplyExp3,
                        supplyExp4,
                        supplyExp5,
                        supplyExp6,
                        supplyExp7,
                        supplyExp8,
                        supplyExp9,
                        supplyExp10,
                        fuelExp1,
                        fuelExp2,
                        fuelExp3,
                        fuelExp4,
                        fuelExp5,
                        fuelExp6
                    );

                    context.SaveChanges();

                }
            }
        }
    }
}
