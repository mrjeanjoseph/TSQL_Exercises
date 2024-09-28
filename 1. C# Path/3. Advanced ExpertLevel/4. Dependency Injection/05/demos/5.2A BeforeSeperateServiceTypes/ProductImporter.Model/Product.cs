using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProductImporter.Model;

public class Product
{
    public Product()
    {
        Price = new Money(Money.EUR, 0m);
        Reference = String.Empty;
    }

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
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Money Price { get; set; }
    public int Stock { get; set; }
    public string Reference { get; set; }

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
