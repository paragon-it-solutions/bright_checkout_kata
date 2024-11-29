namespace Bright.Checkout.Contracts.Services;

public interface ICheckoutService
{
    public bool Scan(string productCode);
    public int CalculateTotalPrice();
}