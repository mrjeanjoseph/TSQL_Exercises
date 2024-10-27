using BethanysPieShop.InventoryManagement.Domain.Contracts;
using BethanysPieShop.InventoryManagement.Domain.General;
using System.Text;

namespace BethanysPieShop.InventoryManagement.Domain.ProductManagement
{
    public abstract partial class Product: ICloneable
    {

        private int id;
        private string name = string.Empty;
        private string? description;

        protected int maxItemsInStock = 0;


        public int Id
        {
            get { return id; }
            set
            {
                id = value;
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value.Length > 50 ? value[..50] : value;
            }
        }

        public string? Description
        {
            get { return description; }
            set
            {
                if (value == null)
                {
                    description = string.Empty;
                }
                else
                {
                    description = value.Length > 250 ? value[..250] : value;

                }
            }
        }

        public Price Price { get; set; }

        public UnitType UnitType { get; set; }

        public int AmountInStock { get; protected set; }
        public bool IsBelowStockTreshold { get; protected set; }


        public Product(int id) : this(id, string.Empty)
        {
        }

        public Product(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Product(int id, string name, string? description, Price price, UnitType unitType,  int maxAmountInStock)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            UnitType = unitType;

            maxItemsInStock = maxAmountInStock;

            if (AmountInStock < StockTreshold)
            {
                IsBelowStockTreshold = true;
            }
        }

        public virtual void UseProduct(int items)
        {
            if (items <= AmountInStock)
            {
                //use the items
                AmountInStock -= items;

                UpdateLowStock();

                Log($"Amount in stock updated. Now {AmountInStock} items in stock.");
            }
            else
            {
                Log($"Not enough items on stock for {CreateSimpleProductRepresentation()}. {AmountInStock} available but {items} requested.");
            }
        }

        //public virtual void IncreaseStock()
        //{
        //    AmountInStock++;
        //}

        public abstract void IncreaseStock();

        public virtual void IncreaseStock(int amount)
        {
            int newStock = AmountInStock + amount;

            if (newStock <= maxItemsInStock)
            {
                AmountInStock += amount;
            }
            else
            {
                AmountInStock = maxItemsInStock;//we only store the possible items, overstock isn't stored
                Log($"{CreateSimpleProductRepresentation} stock overflow. {newStock - AmountInStock} item(s) ordere that couldn't be stored.");
            }

            if (AmountInStock > StockTreshold)
            {
                IsBelowStockTreshold = false;
            }
        }

        protected virtual void DecreaseStock(int items, string reason)
        {
            if (items <= AmountInStock)
            {
                //decrease the stock with the specified number items
                AmountInStock -= items;
            }
            else
            {
                AmountInStock = 0;
            }

            Log(reason);
        }

        //part of public interface
        public void UpdateLowStock()
        {
            if (AmountInStock < StockTreshold)
            {
                IsBelowStockTreshold = true;
            }
        }

        public virtual string DisplayDetailsShort()
        {
            return $"{Id}. {Name} \n{AmountInStock} items in stock";
        }

        public virtual string DisplayDetailsFull()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"{Id} {Name} \n{Description}\n{Price}\n{AmountInStock} item(s) in stock");

            if (IsBelowStockTreshold)
            {
                sb.Append("\n!!STOCK LOW!!");
            }

            return sb.ToString();

            //return DisplayDetailsFull("");
        }

        public virtual string DisplayDetailsFull(string extraDetails)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"{Id} {Name} \n{Description}\n{AmountInStock} item(s) in stock");

            sb.Append(extraDetails);

            if (IsBelowStockTreshold)
            {
                sb.Append("\n!!STOCK LOW!!");
            }

            return sb.ToString();
        }

        protected virtual double GetProductStockValue()
        {
            return Price.ItemPrice * AmountInStock;
        }

        public abstract object Clone();
    }
}
