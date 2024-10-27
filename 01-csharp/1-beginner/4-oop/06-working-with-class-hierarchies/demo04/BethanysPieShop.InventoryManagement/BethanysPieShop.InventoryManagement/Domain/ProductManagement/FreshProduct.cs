using BethanysPieShop.InventoryManagement.Domain.Contracts;
using BethanysPieShop.InventoryManagement.Domain.General;
using System.Text;

namespace BethanysPieShop.InventoryManagement.Domain.ProductManagement
{
    public class FreshProduct: Product, ISaveable
    {
        public DateTime ExpiryDateTime { get; set; }
        public string? StorageInstructions { get; set; }

        public FreshProduct(int id, string name, string? description, Price price, UnitType unitType, int maxAmountInStock) : base(id, name, description, price, unitType, maxAmountInStock)
        {

        }

        protected override double GetProductStockValue()
        {
            if (DateTime.Now > ExpiryDateTime)
            {
                return Price.ItemPrice * AmountInStock * 0.8;//since the product stock is expired, the value is lower
            }
            return Price.ItemPrice * AmountInStock;
        }

        public override string DisplayDetailsFull()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Id} {Name} \n{Description}\n{Price}\n{AmountInStock} item(s) in stock");


            if (IsBelowStockTreshold)
            {
                sb.AppendLine("\n!!STOCK LOW!!");
            }

            sb.AppendLine("Storage instructions: " + StorageInstructions);//since this line needs to go here, we can't call the base here
            sb.AppendLine("Expiry date: " + ExpiryDateTime.ToShortDateString());

            return sb.ToString();
        }

        public override void IncreaseStock()
        {
            AmountInStock++;
        }

        public string ConvertToStringForSaving()
        {
            return $"{Id};{Name};{Description};{maxItemsInStock};{Price.ItemPrice};{(int)Price.Currency};{(int)UnitType};{2};";
        }

        public override object Clone()
        {
            return new FreshProduct(0, this.Name, this.Description, new Price() { ItemPrice = this.Price.ItemPrice, Currency = this.Price.Currency }, this.UnitType, this.maxItemsInStock);
        }
    }
}
