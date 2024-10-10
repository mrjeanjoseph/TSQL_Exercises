using Pluralsight.CShPlaybook.Generics;

Course course = new("Filip Ekberg", "C# 10 Advanced Language Features");
course.RelatedItems.Add(new("Xavier Morera", "Working with JSON in .NET 6"));
course.RelatedItems.Add(new("Zoran Horvat", "Collections and Generics in C# 10"));
course.RelatedItems.Add(new("Chris Behrens", "C# 10 Performance Playbook"));

Library library = new("NUnit");
library.RelatedItems.Add(new("xUnit"));
library.RelatedItems.Add(new("moq"));

Console.WriteLine($"{course.Title} by {course.Author}");
foreach (var relatedItem in course.RelatedItems)
	Console.WriteLine($"   {relatedItem.Title} by {relatedItem.Author}");

Console.WriteLine();
Console.WriteLine(library.Name);
foreach (var relatedItem in library.RelatedItems)
	Console.WriteLine(relatedItem.Name);