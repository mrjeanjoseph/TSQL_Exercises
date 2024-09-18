using System.Reflection;
using Pluralsight.CShPlaybook.ControlFlow;

string filePath = Assembly.GetEntryAssembly()!.Location;

Console.WriteLine("Entry assembly is " + Path.GetFileName(filePath));
Console.WriteLine("Folders are:");
foreach (string folder in FolderProcessor.EnumParentNames_Do(filePath).Reverse())
	Console.WriteLine(folder);
return;

