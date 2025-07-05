using Fawry_Internship_Challenge.Interfaces;

namespace Fawry_Internship_Challenge.Models;

public class Product
{
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public IExpirable? ExpirableBehavior { get; set; }
    public IShippable? ShippableBehavior { get; set; }
    
}