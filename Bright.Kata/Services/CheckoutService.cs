using Bright.Kata.Contracts.Data;
using Bright.Kata.Contracts.Services;
using Bright.Kata.Model;

namespace Bright.Kata.Services;

/// <summary>
///     Represents a service for managing checkout operations.
/// </summary>
/// <param name="productRepository">The repository for accessing product information.</param>
public class CheckoutService(IProductRepository productRepository) : ICheckoutService
{
    // Initialize dictionary for storing product information.
    private readonly Dictionary<string, Product> _products = productRepository.GetProducts();
    
    // Initialize dictionary for storing scanned items and their quantities.
    private readonly Dictionary<string, BasketItem> _basket = new();


    /// <summary>
    /// Scans an item by and adds it to the current checkout session.
    /// </summary>
    /// <param name="productCode">The unique code identifying the item to be scanned.</param>
    /// <exception cref="KeyNotFoundException">Thrown when the product with the specified item code is not found.</exception>
    /// <remarks>
    ///     This method attempts to find the product in the _products dictionary using the provided item code.
    ///     If found, it either increments the quantity of an existing basket item or adds a new basket item.
    /// </remarks>
    public void Scan(string productCode)
    {
        _products.TryGetValue(productCode, out Product? product);

        if (product == null)
        {
            throw new KeyNotFoundException($"Product SKU {productCode} not found!");
        }

        _basket.TryGetValue(productCode, out BasketItem? basketItem);

        if (basketItem != null)
        {
            basketItem.Quantity++;
        }
        else
        {
            _basket.Add(productCode, new BasketItem(product));
        }
    }

    /// <summary>
    ///     Calculates and returns the total price of all scanned items in the current checkout session.
    /// </summary>
    /// <returns>The total price as an integer, representing the sum in the smallest currency unit (e.g., cents).</returns>
    public int GetTotalPrice()
    {
        throw new NotImplementedException();
    }
}