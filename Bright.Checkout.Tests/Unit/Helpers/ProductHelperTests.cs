using Bright.Checkout.Helpers;
using Bright.Checkout.Model;

namespace Bright.Checkout.Tests.Unit.Helpers;

public class ProductHelperTests
{
    [Fact]
    public void GenerateProductFromString_WithTwoValidInputs_ShouldCreateProductWithStandardPricing()
    {
        // Arrange
        string productString = "A 50";

        // Act
        Product? result = ProductHelper.GenerateProductFromString(productString);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("A", result.ProductCode);
        Assert.Equal(50, result.StandardUnitPrice);
        Assert.Null(result.PricingRule);
    }

    [Fact]
    public void GenerateProductFromString_WithFourValidInputs_ShouldCreateProductWithMultiBuyPricing()
    {
        // Arrange
        string productString = "B 30 2 45";

        // Act
        Product? result = ProductHelper.GenerateProductFromString(productString);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("B", result.ProductCode);
        Assert.Equal(30, result.StandardUnitPrice);
        Assert.NotNull(result.PricingRule);
        Assert.Equal(2, result.PricingRule.MultiBuyQuantity);
        Assert.Equal(45, result.PricingRule.MultiBuyPrice);
    }

    [Fact]
    public void GenerateProductFromString_WithInvalidMultiBuyQuantityAndPrice_ShouldReturnNull()
    {
        // Arrange
        string productString = "C 40 abc xyz";

        // Act
        Product? result = ProductHelper.GenerateProductFromString(productString);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GenerateProductFromString_WithInvalidStandardPrice_ShouldReturnNull()
    {
        // Arrange
        string productString = "D abc";

        // Act
        Product? result = ProductHelper.GenerateProductFromString(productString);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GenerateProductFromString_WithOnlyOneInput_ShouldReturnNull()
    {
        // Arrange
        string productString = "A";

        // Act
        Product? result = ProductHelper.GenerateProductFromString(productString);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GenerateProductFromString_WithMoreThanFourInputs_ShouldReturnNull()
    {
        // Arrange
        string productString = "E 60 3 150 extra input";

        // Act
        Product? result = ProductHelper.GenerateProductFromString(productString);

        // Assert
        Assert.Null(result);
    }
}