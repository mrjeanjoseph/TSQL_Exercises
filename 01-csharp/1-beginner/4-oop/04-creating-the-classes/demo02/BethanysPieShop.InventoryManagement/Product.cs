using System.Diagnostics;
using System.Text;
using System.Xml.Linq;

namespace BethanysPieShop.InventoryManagement
{
    public class Product
    {

        private int id;
        private string name = string.Empty;
        private string? description;

        private int maxItemsInStock = 0;

        private UnitType unitType;
        private int amountInStock = 0;
        private bool isBelowStockTreshold = false;

        //ToDo: add price value


        public void UseProduct(int items)
        {
            if (items <= amountInStock)
            {
                //use the items
                amountInStock -= items;

                UpdateLowStock();

                Log($"Amount in stock updated. Now {amountInStock} items in stock.");
            }
            else
            {
                Log($"Not enough items on stock for {CreateSimpleProductRepresentation()}. {amountInStock} available but {items} requested.");
            }
        }

        public void IncreaseStock()
        {
            amountInStock++;
        }

        private void DecreaseStock(int items, string reason)
        {
            if (items <= amountInStock)
            {
                //decrease the stock with the specified number items
                amountInStock -= items;
            }
            else
            {
                amountInStock = 0;
            }

            UpdateLowStock();

            Log(reason);
        }

        public string DisplayDetailsShort()
        {
            return $"{id}. {name} \n{amountInStock} items in stock";
        }

        public string DisplayDetailsFull()
        {
            StringBuilder sb = new();
            //ToDo: add price here too
            sb.Append($"{id} {name} \n{description}\n{amountInStock} item(s) in stock");

            if (isBelowStockTreshold)
            {
                sb.Append("\n!!STOCK LOW!!");
            }

            return sb.ToString();

        }

        private void UpdateLowStock()
        {
            if (amountInStock < 10)//for now a fixed value
            {
                isBelowStockTreshold = true;
            }
        }

        private void Log(string message)
        {
            //this could be written to a file
            Console.WriteLine(message);
        }

        private string CreateSimpleProductRepresentation()
        {
            return $"Product {id} ({name})";
        }


    }
}
