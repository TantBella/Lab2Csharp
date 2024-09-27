using System;
using System.Collections.Generic;

namespace lab2
{
    public class Customer
    {
        public string Name { get; private set; }
        public string Password { get; private set; }

        public Customer(string username, string password)
        {
            Name = username;
            Password = password;
        }
    }

    public class CustomerClass
    {
        public static Dictionary<string, Customer> Customers { get; private set; } = new Dictionary<string, Customer>()
        {
            { "Kund1", new Customer("Knatte", "123") },
            { "Kund2", new Customer("Fnatte", "321") },
            { "Kund3", new Customer("Tjatte", "213") }
        };
    }
}
