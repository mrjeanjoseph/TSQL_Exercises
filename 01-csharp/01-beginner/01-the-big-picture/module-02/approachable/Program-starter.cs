using System;

class Program
{
    static int Main(string[] args)
    {
        Console.WriteLine("Hello, world!");

        for (int n = 0; n < args.Length; n++)
        {
            Console.WriteLine("arg[{0}] = {1}", n, args[n]);
        }

        return 0;
    }
}
