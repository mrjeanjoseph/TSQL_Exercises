using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samples.Debugging.ConsoleApp.Expenses
{
    public class ExpenseManager
    {
        List<Expense> expenses;

        /// <summary>
        /// Constructor - initializes a sample list of expenses
        /// </summary>
        public ExpenseManager()
        {

            DataInitializer init = new DataInitializer();
            expenses = init.CreateSampleExpenses();

        }

        public void GetExpenses()
        {
            Console.WriteLine("List of Expenses:\n");

            Console.WriteLine($"{"ID",-5}{"ExpenseName",-25}{"Location",-25}{"Date",-25}{"Amount",-25}\n");

            foreach (Expense expense in expenses)
            {
                Console.WriteLine($"{expense.ID,-5}{expense.Name,-25}{expense.Location,-25}{expense.Date,-25}{expense.Amount,-25:C}");
            }
        }

        public void CreateExpense()
        {

            Console.WriteLine("Create New Expense\n");
            Expense newExpense = new Expense();

            Console.Write("Expense Name:");
            newExpense.Name = Console.ReadLine();

            Console.Write("Expense Location:");
            newExpense.Location = Console.ReadLine();

            Console.Write("Expense Date:");
            newExpense.Date = DateOnly.Parse(Console.ReadLine());

            Console.Write("Expense Amount:");
            newExpense.Amount = double.Parse(Console.ReadLine());

            int highestID = expenses.Max(a => a.ID);
            newExpense.ID = highestID + 1;

            this.expenses.Add(newExpense);

        }

        public void EditExpense()
        {
            Console.WriteLine("Edit Expense\n");

            Console.Write("Enter Expense ID: ");
            var input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input))
            {
                int id;

                bool success = Int32.TryParse(input, out id);

                if (success)
                {

                    Expense? expenseEdit = expenses.FirstOrDefault(e => e.ID == id);

                    if (expenseEdit != null)
                    {
                        Console.WriteLine($"{"ID",-5}{"ExpenseName",-25}{"Location",-25}{"Date",-25}{"Amount",-25}\n");
                        Console.WriteLine($"{expenseEdit.ID,-5}{expenseEdit.Name,-25}{expenseEdit.Location,-25}{expenseEdit.Date,-25}{expenseEdit.Amount,-25:C}");

                        Console.Write("Enter new expense name (press enter to keep value):");
                        var newName = Console.ReadLine();
                        if (!string.IsNullOrEmpty(newName))
                        {
                            expenseEdit.Name = newName;
                        }

                        Console.Write("Enter new expense location (press enter to keep value):");
                        var newLocation = Console.ReadLine();
                        if (!string.IsNullOrEmpty(newLocation))
                        {
                            expenseEdit.Location = newLocation;
                        }

                        Console.Write("Enter new expense date (press enter to keep value):");
                        var newDate = Console.ReadLine();
                        if (!string.IsNullOrEmpty(newDate))
                        {
                            expenseEdit.Date = DateOnly.Parse(newDate);
                        }

                        Console.Write("Enter new expense amount (press enter to keep value):");
                        var newAmount = Console.ReadLine();
                        if (!string.IsNullOrEmpty(newAmount))
                        {
                            expenseEdit.Amount = double.Parse(newAmount);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Expense not found with ID:{input}");
                    }
                }
                else
                {
                    Console.WriteLine($"Input must be an integer.");
                }
            }
            else
            {
                Console.WriteLine("Input cannot be null.");
            }
        }

        public void DeleteExpense()
        {
            Console.WriteLine("Delete Expense.\n");

            Console.Write("Enter Expense ID: ");
            var input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input))
            {
                int id;

                bool success = Int32.TryParse(input, out id);

                if (success)
                {

                    Expense? expenseToDelete = expenses.FirstOrDefault(e => e.ID == id);

                    if (expenseToDelete != null)
                    {

                        expenses.Remove(expenseToDelete);
                        Console.WriteLine("Expense successfully deleted.\n");

                    }
                    else
                    {
                        Console.WriteLine($"Expense not found with ID:{input}");
                    }
                }
                else
                {
                    Console.WriteLine($"Input must be an integer.");
                }
            }
            else
            {
                Console.WriteLine("Input cannot be null.");
            }
        }

        public void TotalExpenses()
        {
            int numberOfExpenses = expenses.Count();

            double total = 0;

            for (int i = 0; i < numberOfExpenses; i++)
            {
                total += expenses[i].Amount;
            }

            Console.WriteLine($"Expenses Total: {total:C}\n");

        }
    }
}
