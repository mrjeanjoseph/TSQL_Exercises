using System;
using System.Linq;

class Program
{
    static void Main()
    {
        var numbers = new int[] { 1, 2, 3, 4, 5 };
        var sum = numbers.Aggregate(
            0,
            (total, num) => {
                Console.WriteLine($"total = {total}, num = {num}");
                return total + num;
            }
        );
        Console.WriteLine(sum);
    }
}
