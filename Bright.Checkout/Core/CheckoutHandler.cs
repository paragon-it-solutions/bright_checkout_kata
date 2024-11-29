using Bright.Checkout.Contracts.Core;
using Bright.Checkout.Contracts.Services;
using Bright.Checkout.Extensions;

namespace Bright.Checkout.Core;

/// <summary>
/// Represents a handler for the checkout process.
/// </summary>
/// <param name="checkoutService">The service responsible for checkout operations.</param>
public class CheckoutHandler(ICheckoutService checkoutService) : ICheckoutHandler
{
    /// <summary>
    /// Processes the checkout by scanning items and calculating the total price.
    /// </summary>
    /// <remarks>
    /// This method prompts the user to scan items until 'BUY' is entered.
    /// It then calculates and displays the total cost of the scanned items.
    /// </remarks>
    public void ProcessCheckout()
    {
        string productCodeInput;
        Console.WriteLine("### Checkout Initialised ###");
        
        do
        {
            Console.Write("Scan an item to continue or type BUY to stop: ");
            productCodeInput = ConsoleExtensions.GetCleanStringToUpper();

            if (productCodeInput != "BUY")
            {
                bool scannedSuccessfully = checkoutService.Scan(productCodeInput);
                
                Console.WriteLine(scannedSuccessfully
                    ? $"Product with {productCodeInput} scanned successfully."
                    : $"Failed to scan product with SKU {productCodeInput}.");
            }
        } while (productCodeInput != "BUY");
        
        Console.WriteLine("### Checking Out ###");
        int totalCost = checkoutService.CalculateTotalPrice();
        Console.WriteLine($"### Your Total Came to: {totalCost} ###");
    }
}