using Bright.Kata.Contracts.Data;
using Bright.Kata.Helpers;
using Bright.Kata.Model;

namespace Bright.Kata.Data;

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