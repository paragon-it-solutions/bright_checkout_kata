using Bright.Checkout.Extensions;
using Bright.Checkout.Model;
using Xunit;

namespace Bright.Checkout.Tests.Unit.Extensions
{
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
                PricingRule = null,
            };
            var basketItem = new BasketItem(product, 3);

            // Act
            var result = basketItem.GetTotalPrice();

            // Assert
            Assert.Equal(30, result);
        }
    }
}
