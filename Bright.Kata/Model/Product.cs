namespace Bright.Checkout.Model;

/// <summary>
/// Represents a product in the checkout system.
/// </summary>
public class Product
{
    /// <summary>
    /// The unique code identifying the product.
    /// </summary>
    public required string ProductCode { get; set; }

    /// <summary>
    /// The standard unit price of the product.
    /// </summary>
    public int StandardUnitPrice { get; set; }
    
    /// <summary>
    /// Represents a pricing rule for the product, if applicable.
    /// </summary>
    public PricingRule? PricingRule { get; set; }
}
