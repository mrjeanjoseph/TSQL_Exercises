namespace BethanysPieShop.InventoryManagement.Domain.ProductManagement
{
    public partial class Product
    {
        private void UpdateLowStock()
        {
            if (AmountInStock < 10)//for now a fixed value
            {
                IsBelowStockTreshold = true;
            }
        }

        private void Log(string message)
        {
            //this could be written to a file
            Console.WriteLine(message);
        }

        private string CreateSimpleProductRepresentation()
        {
            return $"Product {Id} ({Name})";
        }
    }
}
