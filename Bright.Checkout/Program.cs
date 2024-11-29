using Bright.Checkout.Contracts.Data;
using Bright.Checkout.Contracts.Services;
using Bright.Checkout.Data;
using Bright.Checkout.Extensions;
using Bright.Checkout.Helpers;
using Bright.Checkout.Model;
using Bright.Checkout.Services;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

// Register Repositories
services.AddSingleton<IProductRepository, ProductRepository>();

// Register Services
services.AddTransient<ICheckoutService, CheckoutService>();
services.AddTransient<IProductService, ProductService>();

// Build the service provider
ServiceProvider serviceProvider = services.BuildServiceProvider();

// Gets the required services for use in Program
var checkoutService = serviceProvider.GetRequiredService<ICheckoutService>();
var productService = serviceProvider.GetRequiredService<IProductService>();

Console.WriteLine("### Welcome to Bright Software Group - Checkout Kata! ###");

Console.WriteLine(
    "The program aims to simulate a simple checkout system that calculates the total cost based on optional multi-buy pricing rules\n"
);


//? Allows user to select customer products 
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
        productService.SetProducts(customProducts);
    }
}

// Gets collection of products
Dictionary<string,Product> currentProducts = productService.GetProducts();

//? Allows user to customise default product pricing rules
string customiseDefaultProducts;
do
{
    Console.Write(
        "Would you customise the default product pricing rules? (Y/N): "
    );
    customiseDefaultProducts = ConsoleExtensions.GetCleanStringToUpper();
} while (customiseDefaultProducts != "Y" && customiseDefaultProducts != "N");

if (customiseDefaultProducts == "Y")
{
    if (customiseDefaultProducts == "Y")
    {
        string modifyMore;

        do
        {
            Console.WriteLine(
                "Enter SKU for product to update:"
            );
            string productCode = ConsoleExtensions.GetCleanStringToUpper();
            
            currentProducts.TryGetValue(productCode, out Product? productToUpdate);

            if (productToUpdate != null)
            {
                Console.WriteLine("Enter Multi-Buy pricing rule in the format: MinimumQuantity MultiBuyPrice");
                Console.WriteLine("EXAMPLE: 2 30");
                
                string multiBuyRules = ConsoleExtensions.GetCleanStringToUpper();
                PricingRule? pricingRule = PricingRuleHelper.PricingRuleFromString(multiBuyRules);

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


// If YES, Loop starts to allow user to modify pricing of products in the dictionary
// User must enter ProductCode and new PricingRules separated by a space, e.g. A 50 2 130
// User asked if they wish to modify more products - can modify as many products as they want

// IF NO
// The program will proceed to the checkout

// Initialise CheckoutService with products

// "Please scan items to add to your basket:"