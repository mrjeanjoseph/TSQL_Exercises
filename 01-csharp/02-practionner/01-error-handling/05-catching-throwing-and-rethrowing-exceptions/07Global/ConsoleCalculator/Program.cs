using ConsoleCalculator;
using static System.Console;

// Note: Additional input validation omitted for brevity

AppDomain currentAppDomain = AppDomain.CurrentDomain;
currentAppDomain.UnhandledException += 
    new UnhandledExceptionEventHandler(HandleException);


WriteLine("Enter first number");
int number1 = int.Parse(ReadLine()!);

WriteLine("Enter second number");
int number2 = int.Parse(ReadLine()!);

WriteLine("Enter operation");
string operation = ReadLine()!.ToUpperInvariant();

try
{
    var calculator = new Calculator();
    int result = calculator.Calculate(number1, number2, operation);
    DisplayResult(result);
}
catch (ArgumentNullException ex) when (ex.ParamName == "operation")
{
    // Log.Error(ex);
    WriteLine($"Operation was not provided. {ex}");
}
catch (ArgumentNullException ex)
{
    // Log.Error(ex);
    WriteLine($"An argument was null. {ex}");
}
catch (ArgumentOutOfRangeException ex)
{
    // Log.Error(ex);
    WriteLine($"Operation is not supported. {ex}");
}
catch (Exception ex)
{
    WriteLine($"Sorry, something went wrong. {ex}");
}
finally
{
    WriteLine("...finally...");
}

WriteLine("\nPress enter to exit.");
ReadLine();
    

static void DisplayResult(int result) => WriteLine($"Result is: {result}");

static void HandleException(object sender, UnhandledExceptionEventArgs e)
{
    WriteLine($"Sorry there was a problem and we need to close. Details: {e.ExceptionObject}");
}
