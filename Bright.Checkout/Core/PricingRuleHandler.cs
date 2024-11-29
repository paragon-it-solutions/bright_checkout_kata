using Bright.Checkout.Contracts.Services;
using Bright.Checkout.Extensions;
using Bright.Checkout.Helpers;
using Bright.Checkout.Model;

namespace Bright.Checkout.Core;

/// <summary>
///     Handles the management and customization of pricing rules for products.
/// </summary>
public class PricingRuleHandler(IProductService productService)
{
    /// <summary>
    ///     Handles the process of customizing pricing rules for products.
    /// </summary>
    /// <remarks>
    ///     This method allows users to interactively modify pricing rules for products.
    ///     It prompts the user to decide whether to customize rules.
    /// </remarks>
    public void HandleCustomPricingRules()
    {
        string useCustomPricing;
        Dictionary<string,Product> currentProducts = productService.GetProducts();

        do
        {
            Console.Write("Would you customise the default product pricing rules? (Y/N): ");
            useCustomPricing = ConsoleExtensions.GetCleanStringToUpper();
        } while (useCustomPricing != "Y" && useCustomPricing != "N");

        if (useCustomPricing == "Y")
        {
            if (useCustomPricing == "Y")
            {
                string modifyMore;

                do
                {
                    Console.WriteLine("Enter SKU for product to update:");
                    string productCode = ConsoleExtensions.GetCleanStringToUpper();

                    currentProducts.TryGetValue(productCode, out Product? productToUpdate);

                    if (productToUpdate != null)
                    {
                        Console.WriteLine(
                            "Enter Multi-Buy pricing rule in the format: MinimumQuantity MultiBuyPrice"
                        );
                        Console.WriteLine("EXAMPLE: 2 30");

                        string multiBuyRules = ConsoleExtensions.GetCleanStringToUpper();
                        PricingRule? pricingRule = PricingRuleHelper.PricingRuleFromString(
                            multiBuyRules
                        );

                        if (pricingRule != null)
                        {
                            currentProducts[productCode].SetPricingRule(pricingRule);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Product with SKU '{productCode}' not found.");
                    }

                    do
                    {
                        Console.Write("Do you want to modify another pricing rule? (Y/N): ");
                        modifyMore = ConsoleExtensions.GetCleanStringToUpper();
                    } while (modifyMore != "Y" && modifyMore != "N");
                } while (modifyMore == "Y");
            }
        }
    }
}
