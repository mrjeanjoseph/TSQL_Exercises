class Program
{
    static void Main()
    {
        var numbers = new int[] { 1, 2, 3, 4, 5 };
        var type = numbers.GetType();

        do
        {
            System.Console.WriteLine(type.FullName);
            type = type.BaseType;
        }
        while (type != null);
    }
}
