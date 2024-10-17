using BethanysPieShop.InventoryManagement.Domain.General;

namespace BethanysPieShop.InventoryManagement.Domain.ProductManagement
{
    static class ProductExtensions
    {
        static double dollarToEuro = 0.92;
        static double euroToDollar = 1.11;

        static double poundToEuro = 1.14;
        static double euroToPound = 0.88;

        static double dollarToPound = 0.81;
        static double poundToDollar = 1.14;

        public static double ConvertProductPrice(this Product product, Currency targetCurrency)
        {
            Currency sourceCurrency = product.Price.Currency;
            double originalPrice = product.Price.ItemPrice;
            double convertedPrice = 0.0;

            if (sourceCurrency == Currency.Dollar && targetCurrency == Currency.Euro)
            {
                convertedPrice = originalPrice * dollarToEuro;
            }
            else if (sourceCurrency == Currency.Euro && targetCurrency == Currency.Dollar)
            {
                convertedPrice = originalPrice * euroToDollar;
            }
            else if (sourceCurrency == Currency.Pound && targetCurrency == Currency.Euro)
            {
                convertedPrice = originalPrice * poundToEuro;
            }
            else if (sourceCurrency == Currency.Euro && targetCurrency == Currency.Pound)
            {
                convertedPrice = originalPrice * euroToPound;
            }
            else if (sourceCurrency == Currency.Dollar && targetCurrency == Currency.Pound)
            {
                convertedPrice = originalPrice * dollarToPound;
            }
            else if (sourceCurrency == Currency.Pound && targetCurrency == Currency.Dollar)
            {
                convertedPrice = originalPrice * poundToDollar;
            }
            else
            {
                convertedPrice = originalPrice;
            }

            product.Price.ItemPrice = convertedPrice;

            return convertedPrice;
        }
    }
}
