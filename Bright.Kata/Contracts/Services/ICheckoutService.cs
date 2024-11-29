namespace Bright.Kata.Contracts.Services;

public interface ICheckoutService
{
    public void Scan(string itemCode);
    public int GetTotalPrice();
}