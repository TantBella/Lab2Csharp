using System;
using System.Collections.Generic;

namespace lab2
{
    public class Customer
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public ShoppingCart ShoppingCart { get; set; }

        public Customer(string name, string password)
        {
            Name = name;
            Password = password;
            ShoppingCart = new ShoppingCart();
        }

        public override string ToString()
        {
            return $"Kund: {Name}, Antal produkter i kundvagn: {ShoppingCart.ProductsInCart.Count}";
        }
    }


    public class CustomerClass
    {
        public static Dictionary<string, Customer> customers { get; set; } = new Dictionary<string, Customer>();
        static CustomerClass()
        {
            customers.Add("Knatte", new Customer("Knatte", "123"));
            customers.Add("Fnatte", new Customer("Fnatte", "321"));
            customers.Add("Tjatte", new Customer("Tjatte", "213"));
        }

    }

}
