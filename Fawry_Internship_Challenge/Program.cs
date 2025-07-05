using Fawry_Internship_Challenge.Behaviours;
using Fawry_Internship_Challenge.Models;
using Fawry_Internship_Challenge.Services;

namespace Fawry_Internship_Challenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n{E-Commerce System}\n");
            var validator = new CartValidator();
            var printer = new Printer();
            var shipping = new ShippingService();
            var checkoutService = new CheckoutService(printer, shipping);

            var examples = GetSampleProducts();
            // Happy Path
            Example01(examples, checkoutService,validator);
            
            // Expired Item Case
            //Example02(examples, checkoutService,validator);
            
            //Out Of Stock Case
            //Example03(examples, checkoutService,validator);
            
            //Not Enough balance Case
            //Example04(examples, checkoutService,validator);
            
        }
        public static Dictionary<string, Product> GetSampleProducts()
        {
            var expiredMilk = new Product
            {
                Name = "Milk",
                Price = 30,
                Quantity = 10,
                ExpirableBehavior = new ExpirableBehavior(DateTime.Now.AddDays(-1))
            };

            var tv = new Product
            {
                Name = "TV",
                Price = 2000,
                Quantity = 1,
                ShippableBehavior = new ShippableBehavior("TV", 2000)
            };

            var expensiveTv = new Product
            {
                Name = "Big TV",
                Price = 10000,
                Quantity = 1,
                ShippableBehavior = new ShippableBehavior("Big TV", 3000)
            };

            var cheese = new Product
            {
                Name = "Cheese",
                Price = 100,
                Quantity = 10,
                ExpirableBehavior = new ExpirableBehavior(DateTime.Now.AddDays(7)),
                ShippableBehavior = new ShippableBehavior("Cheese", 200)
            };

            var biscuits = new Product
            {
                Name = "Biscuits",
                Price = 150,
                Quantity = 5,
                ExpirableBehavior = new ExpirableBehavior(DateTime.Now.AddDays(3)),
                ShippableBehavior = new ShippableBehavior("Biscuits", 350)
            };

            var scratchCard = new Product
            {
                Name = "Mobile Scratch Card",
                Price = 50,
                Quantity = 100
            };

            return new Dictionary<string, Product>
            {
                { expiredMilk.Name, expiredMilk },
                { tv.Name, tv },
                { expensiveTv.Name, expensiveTv },
                { cheese.Name, cheese },
                { biscuits.Name, biscuits },
                { scratchCard.Name, scratchCard }
            };
        }

        public static void Example01(Dictionary<string, Product> products , CheckoutService checkoutService ,CartValidator validator)
        {
            var customer = new Customer("Magdy", 2000, validator);
            customer.Cart.AddItem(products["Cheese"], 2);        
            customer.Cart.AddItem(products["Biscuits"], 1);      
            customer.Cart.AddItem(products["Mobile Scratch Card"], 3);  

            checkoutService.Checkout(customer);
        }
        public static void Example02(Dictionary<string, Product> products , CheckoutService checkoutService ,CartValidator validator)
        {
            try
            {
                var customer = new Customer("Magdy", 2000, validator);
                customer.Cart.AddItem(products["Milk"], 2);        
                customer.Cart.AddItem(products["Biscuits"], 1);      
                customer.Cart.AddItem(products["Mobile Scratch Card"], 3);  

                checkoutService.Checkout(customer);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
           
        }

        public static void Example03(Dictionary<string, Product> products , CheckoutService checkoutService ,CartValidator validator)
        {
            try
            {
                var customer = new Customer("Magdy", 2000, validator);
                customer.Cart.AddItem(products["TV"], 2);        
                customer.Cart.AddItem(products["Biscuits"], 1);      
                customer.Cart.AddItem(products["Mobile Scratch Card"], 3);  

                checkoutService.Checkout(customer);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
           
        }
        public static void Example04(Dictionary<string, Product> products , CheckoutService checkoutService ,CartValidator validator)
        {
            try
            {
                var customer = new Customer("Magdy", 2000, validator);
                customer.Cart.AddItem(products["Big TV"], 1);        
                customer.Cart.AddItem(products["Biscuits"], 1);      
                customer.Cart.AddItem(products["Mobile Scratch Card"], 3);  

                checkoutService.Checkout(customer);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
           
        }

    }
}

