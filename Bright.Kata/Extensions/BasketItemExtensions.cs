using Bright.Kata.Model;

namespace Bright.Checkout.Extensions;

/// <summary>
/// Provides extension methods for the BasketItem class.
/// </summary>
public static class BasketItemExtensions
{
    /// <summary>
    /// Sets the pricing rule for a product.
    /// </summary>
    /// <param name="item">The BasketItem to calculate total for.</param>
    public static int GetTotalPrice(this BasketItem item)
    {
    
        if (item.Product.PricingRule != null)
        {
            // Integer division will round down to the nearest whole number - this will give the number of valid multi-buy offers
            int multiBuyQuantityInBasket = item.Product.PricingRule.MultiBuyQuantity / item.Quantity;
            int multiBuyPrice = multiBuyQuantityInBasket * item.Product.PricingRule.MultiBuyPrice;
        }
        return item.Quantity * item.Product.StandardUnitPrice;
    }
}