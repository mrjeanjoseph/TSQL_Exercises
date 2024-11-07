using Globomantics.Math;
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
    var result = Calculator.Add(number1, number2);
    WriteLine($"The result is: {result}");
    WriteLine($"The result in hexadecimal is: {Calculator.AsHex(result)}");
}
else
{
    WriteLine($"The operation '{operation}' is not currently supported.");
}

WriteLine("Press enter to exit");
ReadLine();

