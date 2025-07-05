namespace Fawry_Internship_Challenge.Interfaces;

public interface IShippable
{
    public double Weight { get; set; }
    public string Name { get; set; }

    string GetName();
    double GetWeight();
}