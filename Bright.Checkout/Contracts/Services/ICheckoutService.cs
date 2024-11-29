namespace Bright.Kata.Contracts.Services;

public interface ICheckoutService
{
    public void Scan(string productCode);
    public int GetTotalPrice();
}