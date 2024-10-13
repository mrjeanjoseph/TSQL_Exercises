using System.ComponentModel.DataAnnotations;

namespace ProductImporter.Model;

public class Product
{
    private Product()
    { }
    public Product(Guid id, string name, Money price, int stock)
        : this(id, name, price, stock, string.Empty)
    { }

    public Product(Guid id, string name, Money price, int stock, string reference)
    {
        Id = id;
        Name = name;
        Price = price;
        Stock = stock;
        Reference = reference;
    }

    [Key]
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public Money Price { get; private set; }
    public int Stock { get; private set; }
    public string Reference { get; private set; }

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
            && Stock == other.Stock
            && Reference == other.Reference;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name, Price, Stock, Reference);
    }
}
