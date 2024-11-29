using Bright.Kata.Contracts.Data;
using Bright.Kata.Contracts.Services;

namespace Bright.Kata.Services;

/// <summary>
/// Represents a service for managing checkout operations.
/// </summary>
/// <param name="productRepository">The repository for accessing product information.</param>
public class CheckoutService(IProductRepository productRepository) : ICheckoutService
{
    /// <summary>
    /// Scans an item and adds it to the current checkout session.
    /// </summary>
    /// <param name="itemCode">The unique code identifying the item to be scanned.</param>
    public void Scan(string itemCode)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Calculates and returns the total price of all scanned items in the current checkout session.
    /// </summary>
    /// <returns>The total price as an integer, representing the sum in the smallest currency unit (e.g., cents).</returns>
    public int GetTotalPrice()
    {
        throw new NotImplementedException();
    }
}