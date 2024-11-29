namespace Bright.Checkout.Contracts.Services;

public interface ICheckoutService
{
    public void Scan(string productCode);
    public int GetTotalPrice();
}