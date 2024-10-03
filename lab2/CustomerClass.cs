using System;
using System.Collections.Generic;

namespace lab2
{
    public class Customer
    {
        public static bool LoggedIn { get; set; }
        public static Customer ActiveCustomer { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public virtual string Member { get; set; }
        public virtual double Discount { get; set; }

        public Customer(string name, string password)
        {
            Name = name;
            Password = password;
            ShoppingCart = new ShoppingCart();
        }

        public override string ToString()
        {
            var output = string.Empty;
            output += ("Kund: " + Name + "\n");
            output += ("Lösenord: " + Password + "\n");
            output += ("Medlemsskap: " + Member + "\n");
            output += ("Medlemsrabatt: " + Discount + "%\n");
          
            return output;
        }
    }

    public class CustomerClass
    {
        public static Dictionary<string, Customer> customers { get; set; } = new Dictionary<string, Customer>();
        static CustomerClass()
        {
            customers.Add("Knatte", new BronzeMember("Knatte", "123"));
            customers.Add("Fnatte", new SilverMember("Fnatte", "321"));
            customers.Add("Tjatte", new GoldMember("Tjatte", "213"));
        }

    }

}
