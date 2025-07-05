using Fawry_Internship_Challenge.Interfaces;
using Fawry_Internship_Challenge.Services;

namespace Fawry_Internship_Challenge.Models;

public class Cart
{
    public List<CartItem> Items { get; set; } = new();
    private readonly CartValidator _validator;

    public Cart(CartValidator validator)
    {
        _validator = validator;
    }

    public void AddItem(Product product, int quantity)
    {
        var existing = Items.FirstOrDefault(i => i.Product == product);
        int existingQuantity = existing?.Quantity ?? 0;

        _validator.ValidateAddToCart(product, quantity, existingQuantity);

        if (existing != null)
            existing.Quantity += quantity;
        else
            Items.Add(new CartItem { Product = product, Quantity = quantity });
    }

    public void RemoveItem(Product product)
    {
        Items.RemoveAll(i => i.Product == product);
    }

    public List<Product> GetExpiredItems()
    {
        return Items
            .Where(i => i.Product.ExpirableBehavior?.IsExpired() == true)
            .Select(i => i.Product)
            .ToList();
    }

    public List<IShippable> GetShippableItems()
    {
        return Items
            .Where(i => i.Product.ShippableBehavior != null)
            .Select(i => i.Product.ShippableBehavior!)
            .ToList();
    }

    public decimal CalculateSubtotal() =>
        Items.Sum(i => i.TotalPrice);

    public decimal CalculateShippingFee()
    {
        return (decimal) GetTotalWeight() * 0.05m;
    }

    public double GetTotalWeight() =>
        Items.Where(i => i.Product.ShippableBehavior != null)
            .Sum(i => i.Product.ShippableBehavior!.GetWeight() * i.Quantity);

    public bool HasItems() => Items.Any();
}