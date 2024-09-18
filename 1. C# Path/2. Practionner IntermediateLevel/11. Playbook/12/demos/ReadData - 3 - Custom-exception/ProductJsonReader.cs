using System.Text.Json;
namespace Pluralsight.CShPlaybook.Exceptions;

public static class ProductJsonReader
{    public static List<DiyProduct> ReadProducts(string filePath)
    {
        string jsonString = File.ReadAllText(filePath);
        List<DiyProduct>? lst = System.Text.Json.JsonSerializer.Deserialize<List<DiyProduct>>(jsonString);
        return lst ?? new List<DiyProduct>();
    }
}
