// See https://aka.ms/new-console-template for more information

using Samples.Debugging.ConsoleApp.Expenses;

ExpenseManager expenseManager = new ExpenseManager();

const string exitOption = "6";
string? input;

do
{
    Console.WriteLine("Expense App Menu:");
    Console.WriteLine("1. View Expenses");
    Console.WriteLine("2. Enter New Expense");
    Console.WriteLine("3. Edit Expense");
    Console.WriteLine("4. Delete Expense");
    Console.WriteLine("5. Total Expenses");
    Console.WriteLine($"{exitOption}. Exit Application");

    Console.WriteLine();
    Console.Write("Please select an option: ");
    input = Console.ReadLine();

    Console.WriteLine();

    if (input != null && input != "")
    {
        int menuOption = int.Parse(input);

        switch (menuOption)
        {
            case 1:
                expenseManager.GetExpenses();
                break;
            case 2:
                expenseManager.CreateExpense();
                break;
            case 3:
                expenseManager.EditExpense();
                break;
            case 4:
                expenseManager.DeleteExpense();
                break;
            case 5:
                expenseManager.TotalExpenses();
                break;
            case 6:
                Console.WriteLine("Exit App chosen.");
                break;
        }
    }

    Console.WriteLine();

} while (input != exitOption);

Console.WriteLine("Exiting app.");



