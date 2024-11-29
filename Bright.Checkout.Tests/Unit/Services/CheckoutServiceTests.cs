using Bright.Checkout.Contracts.Data;
using Bright.Checkout.Contracts.Services;
using Bright.Checkout.Model;
using Bright.Checkout.Services;
using Moq;
using Xunit;

namespace Bright.Checkout.Tests.Unit.Services
{
    public class CheckoutServiceTests
    {
        private readonly CheckoutService _checkoutService;

        public CheckoutServiceTests()
        {
            Mock<IProductRepository> mockProductRepository = new();
            mockProductRepository
                .Setup(repo => repo.GetProducts())
                .Returns(new Dictionary<string, Product>());
            _checkoutService = new CheckoutService(mockProductRepository.Object);
        }

        [Fact]
        public void Scan_ValidProduct_AddsToBasketSuccessfully()
        {
            // Arrange
            var mockProductRepository = new Mock<IProductRepository>();
            var testProducts = new Dictionary<string, Product> { { "A", new Product
                {
                    ProductCode = "A",
                    StandardUnitPrice = 50
                }
            } };
            
            mockProductRepository.Setup(repo => repo.GetProducts()).Returns(testProducts);
            var checkoutService = new CheckoutService(mockProductRepository.Object);

            // Act
            bool result = checkoutService.Scan("A");

            // Assert
            Assert.True(result);
            var total = checkoutService.GetTotalPrice();
            Assert.Equal(50, total);
        }
    }
}
