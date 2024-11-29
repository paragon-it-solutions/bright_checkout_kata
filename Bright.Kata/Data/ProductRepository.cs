using Bright.Checkout.Contracts.Data;
using Bright.Checkout.Helpers;
using Bright.Checkout.Model;

namespace Bright.Checkout.Data;

/// <summary>
/// Represents a repository for managing product data.
/// </summary>
/// <param name="products">An optional dictionary of products to initialize the repository with. If null, an empty repository is created.</param>
public class ProductRepository(Dictionary<string, Product>? products = null) : IProductRepository
{
    // Initialize with default products if not provided, otherwise use the provided products.
    private Dictionary<string, Product> _currentProducts = products ?? DefaultProductHelper.GetDefaultProducts();

    /// <summary>
    /// Retrieves all available products.
    /// </summary>
    /// <returns>A dictionary of products where the key is the product ID and the value is the Product object.</returns>
    public Dictionary<string, Product> GetProducts()
    {
        return _currentProducts;
    }
}