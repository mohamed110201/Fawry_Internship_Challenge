using Fawry_Internship_Challenge.Models;

namespace Fawry_Internship_Challenge.Services;

public class CheckoutService
{
    private readonly Printer _printer;
    private readonly ShippingService _shippingService;

    public CheckoutService(Printer printer, ShippingService shippingService)
    {
        _printer = printer;
        _shippingService = shippingService;
    }

    public void Checkout(Customer customer)
    {
        if (!customer.Cart.HasItems())
            throw new Exception("Cart is empty.");

        var expiredProducts = customer.Cart.GetExpiredItems();
        if (expiredProducts.Any())
        {
            var message = "Expired products:\n" +
                          string.Join("\n", expiredProducts.Select(e =>
                              $"- {e.Name}, expired on {e.ExpirableBehavior!.ExpiryDate:yyyy-MM-dd}"));
            throw new Exception(message);
        }

        var subtotal = customer.Cart.CalculateSubtotal();
        var shipping = customer.Cart.CalculateShippingFee();
        var total = subtotal + shipping;

        if (customer.Balance < total)
            throw new Exception("Insufficient balance.");

        customer.ReduceBalance(total);
        
        _printer.PrintCheckoutSummary(customer.Cart.Items, subtotal, shipping, total);

        var toShip = customer.Cart.GetShippableItems();
        _shippingService.Ship(toShip);

    }
}