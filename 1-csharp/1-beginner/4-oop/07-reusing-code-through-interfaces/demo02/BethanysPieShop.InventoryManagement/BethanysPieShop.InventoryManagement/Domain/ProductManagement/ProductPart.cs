namespace BethanysPieShop.InventoryManagement.Domain.ProductManagement
{
    public partial class Product
    {

        public static int StockTreshold = 5;

        public static void ChangeStockTreshold(int newStockTreshhold)
        {
            //we will only allow this to go through if the value is > 0
            if (newStockTreshhold > 0)
                StockTreshold = newStockTreshhold;
        }

        protected void Log(string message)
        {
            //this could be written to a file
            Console.WriteLine(message);
        }

        protected string CreateSimpleProductRepresentation()
        {
            return $"Product {Id} ({Name})";
        }
    }
}
