using Bright.Checkout.Model;

namespace Bright.Checkout.Contracts.Services;

public interface IProductService
{
    public Dictionary<string, Product> GetProducts();
    public bool SetProducts(Dictionary<string, Product> products);
    public bool UpdateProductPricingRule(string productCode, PricingRule pricingRule);
}