using Pluralsight.CShPlaybook.Exceptions;

DemoDataFileSet dataFileSet = new DemoDataFileSet();
(string FilePath, string FileName) chosenFile = new();
try
{
    chosenFile = dataFileSet.AskUserChooseFilePathToRead();

    var products = ProductJsonReader.ReadProducts(chosenFile.FilePath);

    Console.WriteLine(@"The products are:");
    Console.WriteLine("-----------------");
    foreach (var product in products)
        Console.WriteLine(product.ToString()! + (product.IsSpecialProduct ? " (Special product)" : null));
}
catch (FileNotFoundException)
{
    Console.WriteLine($"Error! The file {chosenFile.FileName} was not found");
}
catch (IOException)
{
    Console.WriteLine($"Error! Cannot read file {chosenFile.FileName}");
}
catch (UnauthorizedAccessException)
{
    Console.WriteLine($"Error! Permission was denied to read the file {chosenFile.FileName}");
}
catch (Exception ex)
{
    Console.WriteLine(@$"Error! Something went wrong!
Error message was {ex.Message}
Exception type was {ex.GetType()}");
}
finally
{
    dataFileSet.UnlockAndCloseFile();
}

