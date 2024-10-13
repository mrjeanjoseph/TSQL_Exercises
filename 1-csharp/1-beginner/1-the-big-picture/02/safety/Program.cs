class Program
{
    static void Main()
    {
        var numbers = new int[] { 1, 2, 3, 4, 5 };
        var sum = 0;

        for (var n = 0; n < numbers.Length; n++)
        {
            sum += numbers[n];
        }

        System.Console.WriteLine(sum);
    }
}
