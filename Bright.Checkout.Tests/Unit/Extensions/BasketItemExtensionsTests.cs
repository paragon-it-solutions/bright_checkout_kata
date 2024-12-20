using Bright.Checkout.Extensions;
using Bright.Checkout.Model;

namespace Bright.Checkout.Tests.Unit.Extensions;

public class BasketItemExtensionsTests
{
    [Fact]
    public void GetTotalPrice_WithNoPricingRule_ShouldReturnStandardUnitPriceMultipliedByQuantity()
    {
        // Arrange
        var product = new Product
        {
            ProductCode = "A",
            StandardUnitPrice = 10,
            PricingRule = null
        };
        var basketItem = new BasketItem(product, 3);

        // Act
        int result = basketItem.GetTotalPrice();

        // Assert
        Assert.Equal(30, result);
    }

    [Fact]
    public void GetTotalPrice_WithPricingRuleAndQuantityMatchingOffer_ShouldReturnMultiBuyPrice()
    {
        // Arrange
        var product = new Product
        {
            ProductCode = "B",
            StandardUnitPrice = 15,
            PricingRule = new PricingRule { MultiBuyQuantity = 5, MultiBuyPrice = 45 }
        };
        var basketItem = new BasketItem(product, 5);

        // Act
        int result = basketItem.GetTotalPrice();

        // Assert
        Assert.Equal(45, result);
    }

    [Fact]
    public void
        GetTotalPrice_WithPricingRuleAndQuantityLessThanOffer_ShouldReturnStandardUnitPriceMultipliedByQuantity()
    {
        // Arrange
        var product = new Product
        {
            ProductCode = "C",
            StandardUnitPrice = 20,
            PricingRule = new PricingRule { MultiBuyQuantity = 3, MultiBuyPrice = 50 }
        };
        var basketItem = new BasketItem(product, 2);

        // Act
        int result = basketItem.GetTotalPrice();

        // Assert
        Assert.Equal(40, result);
    }

    [Fact]
    public void GetTotalPrice_WithPricingRuleAndQuantityMultipleOfOffer_ShouldReturnCorrectMultiBuyPrice()
    {
        // Arrange
        var product = new Product
        {
            ProductCode = "D",
            StandardUnitPrice = 25,
            PricingRule = new PricingRule { MultiBuyQuantity = 3, MultiBuyPrice = 60 }
        };
        var basketItem = new BasketItem(product, 6);

        // Act
        int result = basketItem.GetTotalPrice();

        // Assert
        Assert.Equal(120, result);
    }

    [Fact]
    public void GetTotalPrice_WithPricingRuleAndQuantityMoreThanOfferButNotMultiple_ShouldReturnCorrectPrice()
    {
        // Arrange
        var product = new Product
        {
            ProductCode = "D",
            StandardUnitPrice = 25,
            PricingRule = new PricingRule { MultiBuyQuantity = 3, MultiBuyPrice = 60 }
        };
        var basketItem = new BasketItem(product, 4);

        // Act
        int result = basketItem.GetTotalPrice();

        // Assert
        Assert.Equal(85, result); // 60 for the multi-buy offer (3 items) + 25 for the remaining item
    }
}