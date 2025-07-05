using Fawry_Internship_Challenge.Interfaces;

namespace Fawry_Internship_Challenge.Behaviours;

public class ShippableBehavior : IShippable
{
    
    public double Weight { get; set; }
    public string Name { get; set; }

    public ShippableBehavior(string name, double weight)
    {
        Name = name;
        Weight = weight;
    }

    public string GetName() => Name;
    public double GetWeight() => Weight;
}