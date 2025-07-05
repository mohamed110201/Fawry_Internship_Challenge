namespace Fawry_Internship_Challenge.Interfaces;

public interface IExpirable
{
    public DateTime ExpiryDate { get; set; }
    bool IsExpired();
}