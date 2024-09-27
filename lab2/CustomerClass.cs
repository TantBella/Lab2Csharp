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
        public static Dictionary<string, Customer> customers { get; set; } = new Dictionary<string, Customer>();
        static CustomerClass()
        {
            customers.Add("Knatte", new Customer("Knatte", "123"));
            customers.Add("Fnatte", new Customer("Knatte", "321"));
            customers.Add("Tjatte", new Customer("Knatte", "213"));
        }

    }
}
