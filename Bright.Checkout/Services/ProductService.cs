using Bright.Checkout.Contracts.Data;
using Bright.Checkout.Contracts.Services;
using Bright.Checkout.Model;

namespace Bright.Checkout.Services;

/// <summary>
/// Provides services for managing products in repository.
/// </summary>
public class ProductService(IProductRepository productRepository) : IProductService
{
    /// <summary>
    /// Retrieves all products from the repository.
    /// </summary>
    /// <returns>A dictionary containing product codes as keys and Product objects as values.</returns>
    public Dictionary<string, Product> GetProducts()
    {
        return productRepository.GetProducts();
    }

    /// <summary>
    /// Sets the entire collection of products in the repository.
    /// </summary>
    /// <param name="products">A dictionary containing product codes as keys and Product objects as values.</param>
    /// <returns>True if the operation was successful, false otherwise.</returns>
    public bool SetProducts(Dictionary<string, Product> products)
    {
        return productRepository.SetProducts(products);
    }

    /// <summary>
    /// Updates the pricing rule for a specific product.
    /// </summary>
    /// <param name="productCode">The unique code identifying the product.</param>
    /// <param name="pricingRule">The new pricing rule to be applied to the product.</param>
    /// <returns>True if the update was successful, false otherwise.</returns>
    public bool UpdateProductPricingRule(string productCode, PricingRule pricingRule)
    {
        return productRepository.UpdateProductPricingRule(productCode, pricingRule);
    }
}