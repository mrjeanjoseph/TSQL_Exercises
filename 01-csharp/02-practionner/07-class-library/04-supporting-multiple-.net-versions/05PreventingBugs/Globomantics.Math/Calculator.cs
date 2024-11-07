namespace Globomantics.Math
{
    public static class Calculator
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static string AsHex(int a)
        {
            var hex = a.ToString("X");

#if NET6_0
            return $"{hex} from .NET 6";
#elif NET461
            return $"{hex} from .NET Framework 4.6.1";
#else
            return $"{hex} from .NET Standard 2.0";
#endif
        }

        public static void WriteAsHex(int a)
        {
            string hex = a.ToString("X");

#if NET6_0
            Console.WriteLine($"{hex} from .NET 6");
#elif NET461
            System.Console.WriteLine($"{hex} from .NET Framework 4.6.1");
#elif NETSTANDARD2_0
            System.Console.WriteLine($"{hex} from .NET Standard 2.0");
#else
            throw new System.PlatformNotSupportedException();
#endif
        }
    }
}