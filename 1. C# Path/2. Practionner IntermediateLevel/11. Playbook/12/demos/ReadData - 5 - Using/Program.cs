using Pluralsight.CShPlaybook.Exceptions;

using DemoDataFileSet dataFileSet = new DemoDataFileSet();
(string FilePath, string FileName) chosenFile = new();
try
{
    chosenFile = dataFileSet.AskUserChooseFilePathToRead();

    var products = await ProductJsonReader.ReadProductsAsync(chosenFile.FilePath);

    Console.WriteLine(@"The products are:");
    Console.WriteLine("-----------------");
    foreach (var product in products)
        Console.WriteLine(product.ToString()! + (product.IsSpecialProduct ? " (Special product)" : null));
}
catch (InvalidProductException ex) when (ex.PropName == nameof(DiyProduct.Name))
{
    Console.WriteLine($"Error! One of the products has a blank name: {ex.Product}");
}
catch (InvalidProductException ex)
{
    Console.WriteLine($"Error! One of the products is invalid: {ex.Product}");
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
