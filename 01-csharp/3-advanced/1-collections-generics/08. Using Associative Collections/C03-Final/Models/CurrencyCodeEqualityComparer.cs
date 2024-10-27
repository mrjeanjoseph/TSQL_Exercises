namespace Models;

public class CurrencyCodeEqualityComparer : IEqualityComparer<string>
{
    public bool Equals(string? x, string? y) => string.Equals(x, y, StringComparison.OrdinalIgnoreCase);
    public int GetHashCode(string? obj) => obj?.GetHashCode() ?? 0;
}
