using Bright.Checkout.Contracts.Data;
using Bright.Checkout.Model;

namespace Bright.Checkout.Data;

/// <summary>
/// Represents a repository for managing product data.
/// </summary>
/// <param name="Products">An optional dictionary of products to initialize the repository with..</param>
public class ProductRepository(Dictionary<string, Product>? Products = null) : IProductRepository
{
    /// <summary>
    /// Retrieves all available products.
    /// </summary>
    /// <returns>A dictionary of products where the key is the product ID and the value is the Product object.</returns>
    public Dictionary<string, Product> GetProducts()
    {
        throw new NotImplementedException();
    }
}