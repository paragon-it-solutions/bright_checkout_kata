using Bright.Checkout;
using Bright.Checkout.Contracts.Core;
using Bright.Checkout.Contracts.Data;
using Bright.Checkout.Contracts.Services;
using Bright.Checkout.Core;
using Bright.Checkout.Data;
using Bright.Checkout.Services;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

// Register Repositories
services.AddSingleton<IProductRepository, ProductRepository>();

// Register Core Components
services.AddTransient<ICustomProductHandler, CustomProductHandler>();
services.AddTransient<IPricingRuleHandler, PricingRuleHandler>();
services.AddTransient<ICheckoutHandler, CheckoutHandler>();

// Register Services
services.AddTransient<ICheckoutService, CheckoutService>();
services.AddTransient<IProductService, ProductService>();

// Register Application
services.AddTransient<Application>();

// Build Services Provider
ServiceProvider serviceProvider = services.BuildServiceProvider();

// Run Application
var app = serviceProvider.GetService<Application>();
app.Run();