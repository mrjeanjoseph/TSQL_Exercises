using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTest461
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var hex = Globomantics.Math.Calculator.AsHex(255);
            Console.WriteLine(hex);
            Console.ReadLine();

        }
    }
}
