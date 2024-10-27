void DisplayStrings(string context, string[] strings)
{
    Console.WriteLine($"{context}:");

    foreach (var s in strings)
    {
        Console.WriteLine(s);
    }

    Console.WriteLine();
}

// Starting with C# 12 (target framework = .NET 8), the following syntax is
// supported on the RHS (collection expression). The compiler will do the
// work to init the LHS based on the RHS. But notice that we need to provide
// enough type information on the LHS to enable compiler type inference
// (can't use var on the LHS).
//
string[] stooges3 = ["Moe", "Larry", "Curly"];

DisplayStrings("C# 12 collection initializer syntax", stooges3);

// Related, C# 12 also supports a spread operator to reference one collection expression
// from within another collection expression.
//
string[] twoStooges = ["Moe", "Larry"];
string[] moreStooges = ["Curly", "Shemp"];
string[] fourStooges = [..twoStooges, ..moreStooges];

DisplayStrings("C# 12 collection spread operator", fourStooges);