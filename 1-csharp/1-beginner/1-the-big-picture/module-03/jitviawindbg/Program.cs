using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Main called. Press ENTER when ready to call Add.");
        Console.ReadLine();

        var sum = Add(30, 12);

        Console.WriteLine(sum);
        Console.WriteLine("Press ENTER to exit program.");
        Console.ReadLine();
    }

    static int Add(int a, int b)
    {
        return (a + b);
    }
}
