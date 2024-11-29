namespace Bright.Kata.Model;

/// <summary>
/// Represents a pricing rule for products.
/// </summary>
public class PricingRule
{
    /// <summary>
    /// The quantity required for each multi-buy offer, if applicable.
    /// </summary>
    public int? MultiBuyQuantity { get; set; }

    /// <summary>
    /// The discounted price for a multi-buy offer, if applicable.
    /// </summary>
    public int? MultiBuyPrice { get; set; }
}