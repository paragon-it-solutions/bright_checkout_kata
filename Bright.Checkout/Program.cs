using Bright.Checkout.Contracts.Data;
using Bright.Checkout.Contracts.Services;
using Bright.Checkout.Extensions;
using Bright.Checkout.Services;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

// Register IProductRepository
services.AddSingleton<IProductRepository>();

// Register ICheckoutService
services.AddTransient<ICheckoutService, CheckoutService>();

// Build the service provider
ServiceProvider serviceProvider = services.BuildServiceProvider();

// Verifies implementation of ICheckoutService exists
var checkoutService = serviceProvider.GetRequiredService<ICheckoutService>();

Console.WriteLine("### Welcome to Bright Software Group - Checkout Kata! ###");

Console.WriteLine(
    "The program aims to simulate a simple checkout system that calculates the total cost based on optional multi-buy pricing rules\n");

string useCustomProducts;

do
{
    Console.Write("Would you like to provide custom products? These will replace the default! (Y/N): ");
    useCustomProducts = ConsoleExtensions.GetCleanStringToUpper();
} while (useCustomProducts != "Y" && useCustomProducts != "N");

if (useCustomProducts == "Y")
{
    // Code for handling custom products
}
// Code for using default products
// Rest of your program...

// If YES, Loop starts to allow user to create product and add to dictionary:
// User must enter ProductCode and StandardUnitPrice separated by a space, with optional PricingRules e.g. A 50 2 130
// User asked if they wish to add more products - can add as many products as they want

// If NO
// The program will use default products
// "Would you like to customise default products? (Y/N):"

// If YES, Loop starts to allow user to modify pricing of products in the dictionary
// User must enter ProductCode and new PricingRules separated by a space, e.g. A 50 2 130
// User asked if they wish to modify more products - can modify as many products as they want

// IF NO
// The program will proceed to the checkout

// Initialise CheckoutService with products

// "Please scan items to add to your basket:"