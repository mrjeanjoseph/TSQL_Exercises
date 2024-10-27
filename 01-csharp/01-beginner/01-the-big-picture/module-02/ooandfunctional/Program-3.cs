using System;
using System.Linq;

class Program
{
    static void Main()
    {
        var numbers = new int[] { 1, 2, 3, 4, 5 };
        var sum = numbers.Aggregate(
            0,                          // Initial value of accumulator
            (total, num) => total + num // Operation to perform on each value
        );
        Console.WriteLine(sum);
    }
}
