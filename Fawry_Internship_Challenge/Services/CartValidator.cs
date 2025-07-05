using Fawry_Internship_Challenge.Models;

namespace Fawry_Internship_Challenge.Services;

public class CartValidator
{
    public void ValidateAddToCart(Product product, int quantity, int existingQuantity)
    {
        if (quantity + existingQuantity > product.Quantity)
            throw new InvalidOperationException($"Cannot add {quantity}. Total exceeds stock of {product.Name}: {product.Quantity} available.");
    }
}