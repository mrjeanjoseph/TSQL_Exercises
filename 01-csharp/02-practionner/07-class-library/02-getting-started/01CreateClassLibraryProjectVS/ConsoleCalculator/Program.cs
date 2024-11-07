using static System.Console;

WriteLine("Welcome to the Globomantics calculator!");
WriteLine();

// Input validation omitted to keep demo code simple
WriteLine("Please enter your first integer number");
int number1 = int.Parse(ReadLine()!);

WriteLine("Please enter an operation");
string? operation = ReadLine();

WriteLine("Please enter your second integer number");
int number2 = int.Parse(ReadLine()!);

if (operation == "+")
{
    var result = Add(number1, number2);
    WriteLine($"The result is: {result}");
}
else
{
    WriteLine($"The operation '{operation}' is not currently supported.");
}

WriteLine("Press enter to exit");
ReadLine();

static int Add(int a, int b)
{
    return a + b;
}