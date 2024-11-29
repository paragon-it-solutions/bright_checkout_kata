using Bright.Kata.Model;

namespace Bright.Kata.Contracts.Data;

public interface IProductRepository
{
    public Dictionary<string, Product> GetProducts();
}