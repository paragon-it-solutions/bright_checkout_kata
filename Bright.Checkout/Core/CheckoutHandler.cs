using Bright.Checkout.Contracts.Services;

namespace Bright.Checkout.Core
{
    public class CheckoutHandler(ICheckoutService checkoutService)
    {
        public bool ProcessCheckout()
        {
        }
    }
}