using Bright.Kata.Model;

namespace Bright.Kata.Helpers;

/// <summary>
/// Provides helper methods for default product data.
/// </summary>
public static class DefaultProductHelper
{
    /// <summary>
    /// Gets a dictionary of default products with their pricing rules.
    /// </summary>
    /// <returns>A dictionary of default products, keyed by product code.</returns>
    public static Dictionary<string, Product> GetDefaultProducts()
    {
        // Array of default product codes to avoid use of strings directly in the code.
        string[] defaultProductCodes = ["A", "B", "C", "D"];

        Dictionary<string, Product> defaultProducts = new()
        {
            {
                defaultProductCodes[0], new Product
                {
                    ProductCode = defaultProductCodes[0], StandardUnitPrice = 50,
                    PricingRule = new PricingRule
                    {
                        MultiBuyQuantity = 3,
                        MultiBuyPrice = 130
                    }
                }
            },
            {
                defaultProductCodes[1], new Product
                {
                    ProductCode = defaultProductCodes[1], StandardUnitPrice = 30,
                    PricingRule = new PricingRule
                    {
                        MultiBuyQuantity = 2,
                        MultiBuyPrice = 45
                    }
                }
            },
            { defaultProductCodes[2], new Product
            {
                ProductCode = defaultProductCodes[2], StandardUnitPrice = 20
            } },
            { defaultProductCodes[3], new Product
            {
                ProductCode = defaultProductCodes[3], StandardUnitPrice = 15
            } }
        };

        return defaultProducts;
    }
}