using System.Text.Json;
namespace Pluralsight.CShPlaybook.Exceptions;

public static class ProductJsonReader
{   
    public static List<DiyProduct> ReadProducts(string filePath)
    {
        string jsonString = File.ReadAllText(filePath);
        List<DiyProduct>? lst = System.Text.Json.JsonSerializer.Deserialize<List<DiyProduct>>(jsonString);
        return lst ?? new List<DiyProduct>();
    }

    public static async Task<List<DiyProduct>> ReadProductsAsync(string filePath)
    {
        using FileStream strm = File.OpenRead(filePath);
        List<DiyProduct>? lst = await JsonSerializer.DeserializeAsync<List<DiyProduct>>(strm);
        return lst ?? new List<DiyProduct>();
    }
}
