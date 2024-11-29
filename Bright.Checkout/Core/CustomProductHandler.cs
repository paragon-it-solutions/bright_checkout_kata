using Bright.Checkout.Contracts.Core;
using Bright.Checkout.Contracts.Services;
using Bright.Checkout.Extensions;
using Bright.Checkout.Helpers;
using Bright.Checkout.Model;

namespace Bright.Checkout.Core;

/// <summary>
///     Handles the creation of custom products.
/// </summary>
public class CustomProductHandler(IProductService productService) : ICustomProductHandler
{
    /// <summary>
    ///     Handles the process of adding custom products to the product service.
    ///     This method prompts the user to decide whether they want to add custom products.
    /// </summary>
    /// <remarks>
    ///     The method allows users to input custom product details including product code,
    ///     standard unit price, and optional multi-buy quantity and price. It continues to
    ///     prompt for additional products until the user chooses to stop. If any custom
    ///     products are added, they replace the default products in the product service.
    /// </remarks>
    public void HandleCustomProducts()
    {
        string useCustomProducts;
        do
        {
            Console.Write(
                "Would you like to provide custom products? These will replace the default! (Y/N): "
            );
            useCustomProducts = ConsoleExtensions.GetCleanStringToUpper();
        } while (useCustomProducts != "Y" && useCustomProducts != "N");

        if (useCustomProducts == "Y")
        {
            var customProducts = new Dictionary<string, Product>();

            if (useCustomProducts == "Y")
            {
                string addMore;

                do
                {
                    Console.WriteLine(
                        "Enter product details in the format: ProductCode StandardUnitPrice [MultiBuyQuantity MultiBuyPrice]"
                    );
                    Console.WriteLine("Note items in brackets are optional.");
                    Console.WriteLine("Example: 'A 50 2 130' or 'A 50' are both valid inputs");
                    string input = ConsoleExtensions.GetCleanStringToUpper() ?? string.Empty;

                    Product? product = ProductHelper.GenerateProductFromString(input);

                    if (product != null)
                    {
                        customProducts.Add(product.ProductCode, product);
                    }
                    else
                    {
                        Console.WriteLine("Failed to add product.");
                    }

                    do
                    {
                        Console.Write("Do you want to add another product? (Y/N): ");
                        addMore = ConsoleExtensions.GetCleanStringToUpper();
                    } while (addMore != "Y" && addMore != "N");
                } while (addMore == "Y");
            }

            // Sets the custom products to the productService if any exist
            if (customProducts.Count > 0)
            {
                bool success = productService.SetProducts(customProducts);
                if (success)
                {
                    Console.WriteLine("Custom products added successfully!");
                }
                else
                {
                    Console.WriteLine("Failed to set custom products.");
                }
            }
        }
    }
}