using Bright.Checkout.Model;

namespace Bright.Checkout.Helpers;

/// <summary>
/// Helper class for creating PricingRule objects from string input.
/// </summary>
public static class PricingRuleHelper
{
    /// <summary>
    /// Converts a string representation of a pricing rule into a PricingRule object.
    /// </summary>
    /// <param name="multiBuyRulesString">A string containing the multi-buy quantity and price, separated by a space.</param>
    /// <returns>A PricingRule object if the string is successfully parsed; otherwise, null.</returns>
    /// <exception cref="FormatException">Thrown when the input string is not in the correct format.</exception>
    public static PricingRule? PricingRuleFromString(string multiBuyRulesString)
    {
        string[] parts = multiBuyRulesString.Split(' ');

        if (parts.Length == 2)
        {
            try
            {
                int multiBuyQuantity = int.Parse(parts[0]);
                int multiBuyPrice = int.Parse(parts[1]);
                
                Console.WriteLine("Pricing rule added successfully.");

                return new PricingRule
                {
                    MultiBuyQuantity = multiBuyQuantity,
                    MultiBuyPrice = multiBuyPrice
                };
            }
            catch
            {
                Console.WriteLine(
                    "Failed to add pricing rule. Please make sure you provide valid integers for MultiBuyQuantity and MultiBuyPrice."
                );
            }
        }
        else
        {
            Console.WriteLine(
                "Failed to add pricing rule. Please provide exactly two values: MultiBuyQuantity MultiBuyPrice."
            );
        }

        return null;
    }
}