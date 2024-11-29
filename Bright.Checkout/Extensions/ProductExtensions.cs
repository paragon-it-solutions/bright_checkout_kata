using Bright.Checkout.Model;

namespace Bright.Checkout.Extensions;

/// <summary>
///     Provides extension methods for the Product class.
/// </summary>
public static class ProductExtensions
{
    /// <summary>
    ///     Sets the pricing rule for a product.
    /// </summary>
    /// <param name="product">The product to update.</param>
    /// <param name="pricingRule">The pricing rule to set.</param>
    public static void SetPricingRule(this Product product, PricingRule pricingRule)
    {
        product.PricingRule = pricingRule;
    }
}
