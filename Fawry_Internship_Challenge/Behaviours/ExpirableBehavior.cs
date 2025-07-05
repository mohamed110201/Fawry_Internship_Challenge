using Fawry_Internship_Challenge.Interfaces;

namespace Fawry_Internship_Challenge.Behaviours;

public class ExpirableBehavior : IExpirable
{
    public DateTime ExpiryDate { get; set; }
    public ExpirableBehavior(DateTime expiryDate)
    {
        ExpiryDate = expiryDate;
    }

    public bool IsExpired() => DateTime.Now > ExpiryDate;
}