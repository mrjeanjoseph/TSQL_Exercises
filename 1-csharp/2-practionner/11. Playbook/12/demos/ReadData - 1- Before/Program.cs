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

