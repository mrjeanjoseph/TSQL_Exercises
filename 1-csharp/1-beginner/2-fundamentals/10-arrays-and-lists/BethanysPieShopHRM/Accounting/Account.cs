using System;
using System.Collections.Generic;
using System.Text;

namespace BethanysPieShopHRM.Accounting
{
    public class Account
    {
        private string accountNumber;

        public string AccountNumber
        {
            get { return accountNumber; }
            set
            {
                accountNumber = value;
            }
        }

    }
}
