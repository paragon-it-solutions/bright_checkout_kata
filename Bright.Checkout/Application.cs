using Bright.Checkout.Contracts.Core;
using Bright.Checkout.Contracts.Services;

namespace Bright.Checkout
{
    public class Application(
        ICustomProductHandler customProductHandler,
        IPricingRuleHandler pricingRuleHandler,
        ICheckoutHandler checkoutHandler)
    {
        public void Run()
        {
            Console.WriteLine("### Welcome to Bright Software Group - Checkout Kata! ###");
            Console.WriteLine("The program aims to simulate a simple checkout system that calculates the total cost based on optional multi-buy pricing rules\n");

            customProductHandler.HandleCustomProducts();
            pricingRuleHandler.HandleCustomPricingRules();
            checkoutHandler.ProcessCheckout();
        }
    }
}