using Bright.Checkout.Contracts.Data;
using Bright.Checkout.Contracts.Services;
using Bright.Checkout.Extensions;
using Bright.Checkout.Model;

namespace Bright.Checkout.Services;

/// <summary>
///     Represents a service for managing checkout operations.
/// </summary>
/// <param name="productService">The service for accessing product information.</param>
public class CheckoutService(IProductService productService) : ICheckoutService
{
    // Initialize dictionary for storing product information.
    private readonly Dictionary<string, Product> _products = productService.GetProducts();

    // Initialize dictionary for storing scanned items and their quantities.
    private readonly Dictionary<string, BasketItem> _basket = new();

    /// <summary>
    ///     Scans a product and adds it to the checkout basket.
    /// </summary>
    /// <param name="productCode">The unique code identifying the product to be scanned.</param>
    /// <returns>
    ///     <c>true</c> if the product was successfully scanned and added to the basket;
    ///     <c>false</c> if the product was not found or if there was an error during scanning.
    /// </returns>
    /// <remarks>
    ///     This method attempts to find the product in the _products dictionary using the provided product code.
    ///     If found, it either increments the quantity of an existing basket item or adds a new basket item.
    /// </remarks>
    public bool Scan(string productCode)
    {
        _products.TryGetValue(productCode, out Product? product);

        if (product == null)
        {
            Console.WriteLine($"Product SKU '{productCode}' not found!");
            return false;
        }

        _basket.TryGetValue(productCode, out BasketItem? basketItem);

        try
        {
            if (basketItem != null)
            {
                basketItem.Quantity++;
            }
            else
            {
                _basket.Add(productCode, new BasketItem(product));
            }
        }
        catch
        {
            Console.WriteLine($"Failed to scan product with SKU '{productCode}'!");
            return false;
        }

        return true;
    }

    /// <summary>
    ///     Calculates the total price of all items in the current checkout session.
    /// </summary>
    /// <returns>The total price of all items in the basket.</returns>
    public int GetTotalPrice()
    {
        int totalPrice = 0;

        foreach (BasketItem basketItem in _basket.Values)
        {
            totalPrice += basketItem.GetTotalPrice();
        }

        return totalPrice;
    }
}