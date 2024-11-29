namespace Bright.Kata.Model;

/// <summary>
/// Represents products in the basket.
/// </summary>
public class BasketItem
{
    /// <summary>
    /// The product in the basket.
    /// </summary>
    public required Product Product { get; set; }

    /// <summary>
    /// The quantity of the product.
    /// </summary>
    public required int Quantity { get; set; }
}