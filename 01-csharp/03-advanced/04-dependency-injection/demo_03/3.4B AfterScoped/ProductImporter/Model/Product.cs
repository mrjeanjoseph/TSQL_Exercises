namespace ProductImporter.Model;
    
public class Product
{
    public Product(Guid id, string name, Money price, int stock)
    {
        Id = id;
        Name = name;
        Price = price;
        Stock = stock;
    }

    public Guid Id { get; }
    public string Name { get; }
    public Money Price { get; }
    public int Stock { get; }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        var other = (Product)obj;

        return Id == other.Id
            && Name == other.Name
            && Price == other.Price
            && Stock == other.Stock;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name, Price, Stock);
    }
}
