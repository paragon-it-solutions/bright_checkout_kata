using Microsoft.Extensions.DependencyInjection;
using Bright.Checkout.Contracts.Data;
using Bright.Checkout.Contracts.Services;
using Bright.Checkout.Model;
using Bright.Checkout.Helpers;
using Bright.Checkout.Services;

var services = new ServiceCollection();

// Create the dictionary of products
Dictionary<string, Product> products = DefaultProductHelper.GetDefaultProducts();

// Register IProductRepository
services.AddSingleton<IProductRepository>();

// Register ICheckoutService
services.AddTransient<ICheckoutService, CheckoutService>();

// Build the service provider
var serviceProvider = services.BuildServiceProvider();

// Verifies implementation of ICheckoutService exists
var checkoutService = serviceProvider.GetRequiredService<ICheckoutService>();

Console.WriteLine("Hello, World!");

// "Welcome to checkout kata!"

// The program aims to simulate a simple checkout system that calculates the total
// cost based on optional multi-buy pricing rules

// "Would you like to provide custom products? (Y/N):"

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



