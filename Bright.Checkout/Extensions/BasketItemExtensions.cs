using Bright.Checkout.Model;

namespace Bright.Checkout.Extensions;

/// <summary>
///     Provides extension methods for the BasketItem class.
/// </summary>
public static class BasketItemExtensions
{
    /// <summary>
    ///     Calculates the total price for a basket item, taking into account any applicable pricing rules.
    /// </summary>
    /// <param name="item">The basket item for which to calculate the total price.</param>
    /// <returns>
    ///     The total price of the basket item. If a pricing rule is applied, it calculates the price
    ///     based on multi-buy offers and remaining items. If no pricing rule is present, it returns
    ///     the standard unit price multiplied by the quantity.
    /// </returns>
    public static int GetTotalPrice(this BasketItem item)
    {
        if (item.Product.PricingRule != null)
        {
            // Calculate price for multi-buy offers
            // Integer division will round down to the nearest whole number - this will give the number of valid multi-buy offers
            int multiBuyQuantityInBasket = item.Product.PricingRule.MultiBuyQuantity / item.Quantity;
            int multiBuyTotal = multiBuyQuantityInBasket * item.Product.PricingRule.MultiBuyPrice;

            // Calculate price for remaining items
            int standardQuantityInBasket = item.Quantity - multiBuyQuantityInBasket;
            int standardTotal = standardQuantityInBasket * item.Product.PricingRule.MultiBuyPrice;

            return multiBuyTotal + standardTotal;
        }

        return item.Quantity * item.Product.StandardUnitPrice;
    }
}