using Fawry_Internship_Challenge.Interfaces;
using Fawry_Internship_Challenge.Models;

namespace Fawry_Internship_Challenge.Services;

public class ShippingService
{
    public void Ship(List<IShippable> items)
    {
        Console.WriteLine($"\nShipping {items.Count} items....\n");
    }
}