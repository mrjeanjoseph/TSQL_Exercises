using Samples.Debugging.ConsoleApp.Expenses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samples.Debugging.ConsoleApp
{
    public class DataInitializer
    {
        public List<Expense> CreateSampleExpenses()
        {
            List<Expense> expenses = new List<Expense>
            {
                new Expense
                {
                    ID = 1,
                    Name = "Lunch",
                    Date = new DateOnly(2022,03,20),
                    Location = "The Sandwich Shack",
                    Amount = 7.50
                },
                new Expense
                {
                    ID = 2,
                    Name = "Staples",
                    Date = new DateOnly(2022,02,15),
                    Location = "Office Shop",
                    Amount = 2.50
                },
                new Expense
                {
                    ID = 3,
                    Name = "Gas",
                    Date = new DateOnly(2022,03,20),
                    Location = "Gas Depot",
                    Amount = 20.00
                }
            };

            return expenses;
        }
    }
}
