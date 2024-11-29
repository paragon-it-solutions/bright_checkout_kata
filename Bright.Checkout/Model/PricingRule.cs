namespace Bright.Checkout.Model;

/// <summary>
///     Represents a pricing rule for products.
/// </summary>
public class PricingRule
{
    /// <summary>
    ///     The quantity required for each multi-buy offer, if applicable.
    /// </summary>
    public required int MultiBuyQuantity { get; set; }

    /// <summary>
    ///     The discounted price for a multi-buy offer, if applicable.
    /// </summary>
    public required int MultiBuyPrice { get; set; }
}