using Bright.Checkout.Model;

namespace Bright.Checkout.Helpers;

public static class ProductHelper
{
    /// <summary>
    ///     Generates a Product object from a string representation.
    /// </summary>
    /// <param name="productString">
    ///     A string containing product information in the format:
    ///     "ProductCode StandardUnitPrice MultiBuyQuantity MultiBuyPrice".
    ///     EXAMPLE: "A 50 2 130"
    /// </param>
    /// <returns>
    ///     A Product object if the string is successfully parsed; otherwise, null.
    ///     The Product object contains the product code, standard unit price, and optional multi-buy pricing rule.
    /// </returns>
    /// <remarks>
    ///     The function expects the input string to h2ave either 2 or 4 space-separated values.
    ///     If 2 values are provided, it creates a Product with just the product code and standard unit price.
    ///     If 4 values are provided, it also includes a PricingRule with multi-buy quantity and price.
    /// </remarks>
    public static Product? GenerateProductFromString(string productString)
    {
        Product? product = null;

        string[] parts = productString.Split(' ');

        if (parts.Length is >= 2 and <= 4)
        {
            string productCode = parts[0];
            try
            {
                if (int.TryParse(parts[1], out int standardPrice))
                {
                    if (parts.Length == 4)
                    {
                        int multiBuyQuantity = int.Parse(parts[2]);
                        int multiBuyPrice = int.Parse(parts[3]);
                        {
                            product = new Product
                            {
                                ProductCode = productCode,
                                StandardUnitPrice = standardPrice,
                                PricingRule = new PricingRule
                                {
                                    MultiBuyPrice = multiBuyPrice,
                                    MultiBuyQuantity = multiBuyQuantity,
                                },
                            };
                        }
                    }
                    else
                    {
                        product = new Product
                        {
                            ProductCode = productCode,
                            StandardUnitPrice = standardPrice,
                        };
                    }

                    Console.WriteLine($"Product {productCode} added successfully.");
                }
            }
            catch
            {
                Console.WriteLine(
                    "Failed to add product. Please make sure you values are provided ProductCode StandardUnitPrice [DiscountQuantity DiscountPrice."
                );
                Console.WriteLine("Example: A 50 2 130");
            }
        }
        
        return product;
    }
}