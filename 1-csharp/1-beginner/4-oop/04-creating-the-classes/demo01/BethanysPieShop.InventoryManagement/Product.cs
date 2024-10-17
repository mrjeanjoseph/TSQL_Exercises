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

    }
}
