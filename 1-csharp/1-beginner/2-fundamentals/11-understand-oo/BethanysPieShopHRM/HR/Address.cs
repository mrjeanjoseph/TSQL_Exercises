using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.HR
{
    public class Address
    {
        private string street;
        private string houseNumber;
        private string zipCode;
        private string city;

        public Address(string street, string houseNumber, string zipCode, string city)
        {
            Street = street;
            HouseNumber = houseNumber;
            ZipCode = zipCode;
            City = city;
        }

        public string Street
        {
            get { return street; }
            set
            {
                street = value;
            }
        }
        public string HouseNumber
        {
            get { return houseNumber; }
            set
            {
                houseNumber = value;
            }
        }
        public string ZipCode
        {
            get { return zipCode; }
            set
            {
                zipCode = value;
            }
        }
        public string City
        {
            get
            {
                return city;
            }
            set
            {
                city = value;
            }
        }
    }
}
