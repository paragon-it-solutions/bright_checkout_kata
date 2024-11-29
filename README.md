# Bright.Checkout

Bright.Checkout is a flexible and extensible supermarket checkout system implemented in C#. It handles product pricing, including special offers, and provides a simple command-line interface for scanning items and calculating totals.

Troughout development, notes on thought process and design decisions were included in BrightCheckout\Notes.txt

## Features

- Product management with individual and multi-buy pricing
- Flexible pricing rules that can be updated for each checkout transaction
- Scanning of items in any order
- Support for multiple special offers on the same product
- Separation of concerns with distinct services for checkout and product management

## Getting Started

1. Clone the repository
2. Open the solution in your IDE
3. Restore nuget packages (dotnet restore)
4. Build the solution
5. Run the tests to ensure everything is working correctly
6. Run solution in console

## Project Structure

- `Bright.Checkout/`: Main project directory
  - `Contracts/`: Interfaces for core functionality and services
  - `Core/`: Core business logic handlers
  - `Data/`: Data access layer
  - `Extensions/`: Extension methods for various classes
  - `Helpers/`: Helper classes for common operations
  - `Model/`: Data models
  - `Services/`: Service implementations
- `Bright.Checkout.Tests/`: Test project directory
  - `Unit/`: Unit tests for various components

  ## Full Project Tree:
```
├─ Bright.Checkout
│  ├─ Contracts
│  │  ├─ Core
│  │  │  ├─ ICheckoutHandler.cs
│  │  │  ├─ ICustomProductHandler.cs
│  │  │  ├─ IPricingRuleHandler.cs
│  │  ├─ Data
│  │  │  ├─ IProductRepository.cs
│  │  ├─ Services
│  │  │  ├─ ICheckoutService.cs
│  │  │  ├─ IProductService.cs
│  ├─ Core
│  │  ├─ CheckoutHandler.cs
│  │  ├─ CustomProductHandler.cs
│  │  ├─ PricingRuleHandler.cs
│  ├─ Data
│  │  ├─ ProductRepository.cs
│  ├─ Extensions
│  │  ├─ BasketItemExtensions.cs
│  │  ├─ ConsoleExtensions.cs
│  │  ├─ ProductExtensions.cs
│  ├─ Helpers
│  │  ├─ DefaultProductHelper.cs
│  │  ├─ PricingRuleHelper.cs
│  │  ├─ ProductHelper.cs
│  ├─ Model
│  │  ├─ BasketItem.cs
│  │  ├─ PricingRule.cs
│  │  ├─ Product.cs
│  ├─ Services
│  │  ├─ CheckoutService.cs
│  │  ├─ ProductService.cs
│  ├─ Application.cs
│  ├─ Dockerfile
│  ├─ Program.cs
├─ Bright.Checkout.Tests
│  ├─ Unit
│  │  ├─ Data
│  │  │  ├─ ProductRepositoryTests.cs
│  │  ├─ Extensions
│  │  │  ├─ BasketItemExtensionsTests.cs
│  │  ├─ Helpers
│  │  │  ├─ PricingRuleHelperTests.cs
│  │  │  ├─ ProductHelperTests.cs
│  │  ├─ Services
│  │  │  ├─ CheckoutServiceTests.cs
```
