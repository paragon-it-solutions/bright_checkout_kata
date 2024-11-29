using Bright.Checkout.Contracts.Data;
using Bright.Checkout.Extensions;
using Bright.Checkout.Helpers;
using Bright.Checkout.Model;

namespace Bright.Checkout.Data;

/// <summary>
///     Represents a repository for managing product data.
/// </summary>
public class ProductRepository : IProductRepository
{
    // Initialize with default products.
    private Dictionary<string, Product> _currentProducts = DefaultProductHelper.GetDefaultProducts();

    /// <summary>
    ///     Retrieves all available products.
    /// </summary>
    /// <returns>A dictionary of products where the key is the product ID and the value is the Product object.</returns>
    public Dictionary<string, Product> GetProducts()
    {
        return _currentProducts;
    }

    /// <summary>
    ///     Sets the current products in the repository.
    /// </summary>
    /// <param name="products">A dictionary of products to replace the existing products.</param>
    /// <returns>
    ///     A boolean value indicating whether the operation was successful.
    ///     Returns true if the products were successfully set, false if an error occurred during the process.
    /// </returns>
    public bool SetProducts(Dictionary<string, Product> products)
    {
        try
        {
            _currentProducts = products;
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error updating products: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    ///     Updates the pricing rule for a specific product.
    /// </summary>
    /// <param name="productCode">The unique identifier (SKU) of the product to update.</param>
    /// <param name="pricingRule">The new pricing rule to be applied to the product.</param>
    /// <exception cref="KeyNotFoundException">Thrown when the specified product code is not found in the current products.</exception>
    /// <returns>
    ///     A boolean value indicating whether the operation was successful.
    ///     Returns true if the products were successfully set, false if an error occurred during the process.
    /// </returns>
    public bool UpdateProductPricingRule(string productCode, PricingRule pricingRule)
    {
        try
        {
            if (_currentProducts.ContainsKey(productCode))
            {
                _currentProducts[productCode].SetPricingRule(pricingRule);
                return true;
            }
        }
        catch (KeyNotFoundException ex)
        {
            Console.WriteLine($"Product SKU '{productCode}' not found!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating pricing rule for {productCode}: {ex.Message}");
        }

        return false;
    }
}
