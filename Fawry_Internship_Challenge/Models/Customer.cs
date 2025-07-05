using Fawry_Internship_Challenge.Services;

namespace Fawry_Internship_Challenge.Models;

public class Customer
{
    public string Name { get; set; }
    public decimal Balance { get; private set; }
    public Cart Cart { get; set; }

    public Customer(string name, decimal balance, CartValidator validator)
    {
        Name = name;
        Balance = balance;
        Cart = new Cart(validator);
    }

    public void ReduceBalance(decimal amount)
    {
        Balance -= amount;
    }
}