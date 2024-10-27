namespace BethanysPieShopHRM.Accounting
{
    public class Customer
    {
        private string customerId;
        private string name;

        public string CustomerId
        {
            get { return customerId; }
            set
            {
                customerId = value;
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }

    }
}
