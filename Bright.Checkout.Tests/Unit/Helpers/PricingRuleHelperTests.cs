using Bright.Checkout.Helpers;
using Bright.Checkout.Model;

namespace Bright.Checkout.Tests.Unit.Helpers;

public class PricingRuleHelperTests
{
    [Fact]
    public void PricingRuleFromString_ValidInput_ReturnsPricingRule()
    {
        // Arrange
        string input = "3 10";

        // Act
        PricingRule? result = PricingRuleHelper.PricingRuleFromString(input);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.MultiBuyQuantity);
        Assert.Equal(10, result.MultiBuyPrice);
    }

    [Fact]
    public void PricingRuleFromString_MoreThanTwoParts_ReturnsNull()
    {
        // Arrange
        string input = "3 10 15";

        // Act
        PricingRule? result = PricingRuleHelper.PricingRuleFromString(input);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void PricingRuleFromString_LessThanTwoParts_ReturnsNull()
    {
        // Arrange
        string input = "10";

        // Act
        PricingRule? result = PricingRuleHelper.PricingRuleFromString(input);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void PricingRuleFromString_EmptyString_ReturnsNull()
    {
        // Arrange
        string input = "";

        // Act
        PricingRule? result = PricingRuleHelper.PricingRuleFromString(input);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void PricingRuleFromString_NonIntegerValues_ReturnsNull()
    {
        // Arrange
        string input = "three ten";

        // Act
        PricingRule? result = PricingRuleHelper.PricingRuleFromString(input);

        // Assert
        Assert.Null(result);
    }
}
