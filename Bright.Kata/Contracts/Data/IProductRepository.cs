using Bright.Checkout.Model;

namespace Bright.Checkout.Contracts.Data;

public interface IProductRepository
{
    public Dictionary<string, Product> GetProducts();
}