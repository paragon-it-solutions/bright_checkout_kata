using Bright.Checkout.Model;

namespace Bright.Checkout.Helpers;

public static class DefaultProductHelper
{
    public static Dictionary<string, Product> GetDefaultProducts()
    {
        // Array of default product codes to avoid use of strings directly in the code.
        string[] defaultProductCodes = ["A", "B", "C", "D"];

        Dictionary<string, Product> defaultProducts = new();

        defaultProducts.Add(defaultProductCodes[0], new Product
        {
            ProductCode = defaultProductCodes[0], StandardUnitPrice = 50,
            PricingRule = new PricingRule
            {
                MultiBuyQuantity = 3,
                MultiBuyPrice = 130
            }
        });

        defaultProducts.Add(defaultProductCodes[1], new Product
        {
            ProductCode = defaultProductCodes[1], StandardUnitPrice = 30,
            PricingRule = new PricingRule
            {
                MultiBuyQuantity = 2,
                MultiBuyPrice = 45
            }
        });

        defaultProducts.Add(defaultProductCodes[2], new Product
        {
            ProductCode = defaultProductCodes[2], StandardUnitPrice = 20
        });
        
        defaultProducts.Add(defaultProductCodes[3], new Product
        {
            ProductCode = defaultProductCodes[3], StandardUnitPrice = 15
        });
        
        return defaultProducts;
    }
}