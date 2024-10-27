using System.Linq;

void DisplayStrings(string context, string[] strings)
{
    Console.WriteLine($"{context}:");

    foreach (var s in strings)
    {
        Console.WriteLine(s);
    }

    Console.WriteLine();
}

// Prior to C# 12, you must include the type of the array as part of the RHS:
//
string[] stooges1 = new string[] {"Moe", "Larry", "Curly"};

DisplayStrings("Pre C# 12 syntax (string[])", stooges1);

// Prior to C# 12, the only syntactic clean up you could do was to leverage 'var' on the LHS:
//
string[] stooges2 = new [] {"Moe", "Larry", "Curly"};

DisplayStrings("Pre C# 12 syntax (var)", stooges2);

// There was also no intrinsic way to combine two collections. Would have
// to resort to explicit use of LINQ or other methods, for example:
//
var twoStooges = new string[] {"Moe", "Larry"};
var moreStooges = new string[] {"Curly", "Shemp"};
var fourStooges = twoStooges.Concat(moreStooges).ToArray();

DisplayStrings("Pre C# 12 collection combine", fourStooges);