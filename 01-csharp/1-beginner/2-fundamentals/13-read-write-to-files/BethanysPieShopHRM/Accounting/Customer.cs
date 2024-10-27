using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Accounting
{
    internal class Customer
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
