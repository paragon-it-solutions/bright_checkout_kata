namespace Bright.Checkout.Contracts.Services;

public interface ICheckoutService
{
    public void Scan(string itemCode);
    public int GetTotalPrice();
}