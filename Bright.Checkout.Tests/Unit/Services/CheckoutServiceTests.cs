using Bright.Checkout.Contracts.Services;
using Bright.Checkout.Model;
using Bright.Checkout.Services;
using Moq;

namespace Bright.Checkout.Tests.Unit.Services;

public class CheckoutServiceTests
{
    private readonly CheckoutService _checkoutService;

    public CheckoutServiceTests()
    {
        Mock<IProductService> mockProductService = new();
        mockProductService
            .Setup(repo => repo.GetProducts())
            .Returns(new Dictionary<string, Product>());
        _checkoutService = new CheckoutService(mockProductService.Object);
    }

    [Fact]
    public void Scan_ValidProduct_AddsToBasketSuccessfully()
    {
        // Arrange
        var mockProductService = new Mock<IProductService>();
        var testProducts = new Dictionary<string, Product>
        {
            {
                "A",
                new Product { ProductCode = "A", StandardUnitPrice = 50 }
            }
        };

        mockProductService.Setup(repo => repo.GetProducts())
            .Returns(testProducts);
        var checkoutService = new CheckoutService(mockProductService.Object);

        // Act
        bool result = checkoutService.Scan("A");

        // Assert
        Assert.True(result);
        int total = checkoutService.CalculateTotalPrice();
        Assert.Equal(50, total);
    }

    [Fact]
    public void Scan_NonExistentProduct_ReturnsFalse()
    {
        // Arrange
        var mockProductService = new Mock<IProductService>();
        mockProductService
            .Setup(repo => repo.GetProducts())
            .Returns(new Dictionary<string, Product>());
        var checkoutService = new CheckoutService(mockProductService.Object);

        // Act
        bool result = checkoutService.Scan("NonExistentProduct");

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void GetTotalPrice_MultipleItemsInBasket_CalculatesCorrectTotal()
    {
        // Arrange
        var mockProductRepository = new Mock<IProductService>();
        var testProducts = new Dictionary<string, Product>
        {
            {
                "A",
                new Product { ProductCode = "A", StandardUnitPrice = 50 }
            },
            {
                "B",
                new Product { ProductCode = "B", StandardUnitPrice = 30 }
            },
            {
                "C",
                new Product { ProductCode = "C", StandardUnitPrice = 20 }
            }
        };

        mockProductRepository.Setup(repo => repo.GetProducts())
            .Returns(testProducts);
        var checkoutService = new CheckoutService(mockProductRepository.Object);

        // Act
        checkoutService.Scan("A");
        checkoutService.Scan("B");
        checkoutService.Scan("C");
        checkoutService.Scan("A");

        int totalPrice = checkoutService.CalculateTotalPrice();

        // Assert
        Assert.Equal(150, totalPrice);
    }

    [Fact]
    public void GetTotalPrice_EmptyBasket_ReturnsZero()
    {
        // Arrange
        var mockProductService = new Mock<IProductService>();
        mockProductService
            .Setup(repo => repo.GetProducts())
            .Returns(new Dictionary<string, Product>());
        var checkoutService = new CheckoutService(mockProductService.Object);

        // Act
        int totalPrice = checkoutService.CalculateTotalPrice();

        // Assert
        Assert.Equal(0, totalPrice);
    }
}