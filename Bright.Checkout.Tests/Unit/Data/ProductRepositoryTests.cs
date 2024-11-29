using Bright.Checkout.Data;
using Bright.Checkout.Helpers;
using Bright.Checkout.Model;

namespace Bright.Checkout.Tests.Unit.Data;

public class ProductRepositoryTests
{
    private readonly ProductRepository _productRepository = new();

    [Fact]
    public void GetProducts_ReturnsAllDefaultProducts()
    {
        // Arrange
        var expectedProducts = DefaultProductHelper.GetDefaultProducts();

        // Act
        var result = _productRepository.GetProducts();

        // Assert
        Assert.Equal(expectedProducts.Count, result.Count);
        Assert.Equal(expectedProducts.Keys, result.Keys);
        foreach (string key in expectedProducts.Keys)
        {
            // Verifies product details match
            Assert.Equal(expectedProducts[key].ProductCode, result[key].ProductCode);
            Assert.Equal(expectedProducts[key].StandardUnitPrice, result[key].StandardUnitPrice);

            // Verifies pricing rules match
            Assert.Equal(
                expectedProducts[key].PricingRule?.MultiBuyQuantity,
                result[key].PricingRule?.MultiBuyQuantity
            );
            Assert.Equal(
                expectedProducts[key].PricingRule?.MultiBuyPrice,
                result[key]?.PricingRule?.MultiBuyPrice
            );
        }
    }

    [Fact]
    public void SetProducts_WithValidInput_ShouldSuccessfullySetNewProducts()
    {
        // Arrange
        var newProducts = new Dictionary<string, Product>
        {
            {
                "TEST1",
                new Product { ProductCode = "TEST1", StandardUnitPrice = 10 }
            },
            {
                "TEST2",
                new Product
                {
                    ProductCode = "TEST2",
                    StandardUnitPrice = 20,
                    PricingRule = new PricingRule { MultiBuyQuantity = 5, MultiBuyPrice = 45 }
                }
            }
        };

        // Act
        bool result = _productRepository.SetProducts(newProducts);

        // Assert
        Assert.True(result);

        var updatedProducts = _productRepository.GetProducts();

        Assert.Equal(newProducts.Count, updatedProducts.Count);
        Assert.Equal(newProducts.Keys, updatedProducts.Keys);

        foreach (string key in newProducts.Keys)
        {
            Assert.Equal(newProducts[key].ProductCode, updatedProducts[key].ProductCode);
            Assert.Equal(
                newProducts[key].StandardUnitPrice,
                updatedProducts[key].StandardUnitPrice
            );
            Assert.Equal(
                newProducts[key].PricingRule?.MultiBuyQuantity,
                updatedProducts[key].PricingRule?.MultiBuyQuantity
            );
            Assert.Equal(
                newProducts[key].PricingRule?.MultiBuyPrice,
                updatedProducts[key].PricingRule?.MultiBuyPrice
            );
        }
    }

    [Fact]
    public void UpdateProductPricingRule_WithValidInput_ShouldSuccessfullyUpdatePricingRule()
    {
        // Arrange
        var productRepository = new ProductRepository();
        string productCode = "A";
        var newPricingRule = new PricingRule { MultiBuyQuantity = 5, MultiBuyPrice = 45 };

        // Act
        bool result = productRepository.UpdateProductPricingRule(productCode, newPricingRule);

        // Assert
        Assert.True(result);

        var updatedProducts = productRepository.GetProducts();

        Assert.NotNull(updatedProducts[productCode].PricingRule);
        Assert.Equal(
            newPricingRule.MultiBuyQuantity,
            updatedProducts[productCode].PricingRule?.MultiBuyQuantity
        );
        Assert.Equal(
            newPricingRule.MultiBuyPrice,
            updatedProducts[productCode].PricingRule?.MultiBuyPrice
        );
    }

    [Fact]
    public void UpdateProductPricingRule_WithNonExistentProductCode_ShouldReturnFalse()
    {
        // Arrange
        var productRepository = new ProductRepository();
        string nonExistentProductCode = "NONEXISTENT";
        var newPricingRule = new PricingRule { MultiBuyQuantity = 5, MultiBuyPrice = 45 };

        // Act
        bool result = productRepository.UpdateProductPricingRule(
            nonExistentProductCode,
            newPricingRule
        );

        // Assert
        Assert.False(result);
    }
}