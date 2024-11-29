namespace Bright.Checkout.Model;

/// <summary>
/// Represents products in the basket.
/// </summary>
public class BasketItem(Product product)
{
    /// <summary>
    /// The product in the basket.
    /// </summary>
    public Product Product { get; set; } = product;

    /// <summary>
    /// The quantity of the product. Defaults to 0.
    /// </summary>
    public int Quantity { get; set; } = 0;
}