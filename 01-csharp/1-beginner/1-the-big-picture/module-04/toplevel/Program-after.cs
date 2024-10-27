using System;

Console.WriteLine("Hello, world!");

for (var n = 0; n < args.Length; n++)
{
    Console.WriteLine($"arg[{n}] = {args[n]}");
}

return 0;
