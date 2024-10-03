using System;
using System.Collections.Generic;

namespace lab2
{
    public class AccountMethods
    {
        private Dictionary<string, Customer> _customers;
        private ShoppingMethods _shoppingMethods;

        public AccountMethods(ShoppingMethods shoppingMethods, Dictionary<string, Customer> customers)
        {
            _customers = customers;
            _shoppingMethods = shoppingMethods;
        }

        public void Register()
        {
            Console.Clear();
            Console.WriteLine("Registrera nytt konto");

            string username;
            string password;

            while (true)
            {
                Console.Write("Ange användarnamn: ");
                username = Console.ReadLine();
                if (_customers.ContainsKey(username))
                {
                    Console.WriteLine("Användarnamnet är upptaget. Försök igen.");
                }
                else
                {
                    break;
                }
            }

            Console.Write("Ange lösenord: ");
            password = Console.ReadLine();

            _customers.Add(username, new Customer(username, password));
            Console.WriteLine("Konto skapat. Tryck på valfri knapp för att fortsätta.");
            Console.ReadKey();
        }

        public Customer Login()
        {
            Console.Clear();
            Console.WriteLine("Logga in");

            Console.Write("Ange användarnamn: ");
            string username = Console.ReadLine();

            if (!_customers.ContainsKey(username))
            {
                Console.WriteLine("Kunden finns inte. Vill du registrera en ny kund? (j/n)");
                if (Console.ReadLine().ToLower() == "j")
                {
                    Register();
                }
                else
                {
                    Console.WriteLine("Återgår till huvudmenyn. Tryck på valfri knapp.");
                    Console.ReadKey();
                    return null;
                }
            }
            else
            {
                var customer = _customers[username];

                for (int attempts = 0; attempts < 3; attempts++)
                {
                    Console.Write("Ange lösenord: ");
                    string password = Console.ReadLine();
                    if (customer.Password == password)
                    {
                        Customer.LoggedIn = true;
                        Customer.ActiveCustomer = customer;
                        Console.Clear();
                        if (customer.Member is "Gold" or "Silver" or "Bronze")
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Välkommen: " + customer.Name + "\nDittt medlemsskap är: " + customer.Member);
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else
                        {
                            Console.WriteLine($"Välkommen {customer.Name}!");
                            _shoppingMethods.LoggedinMenu(customer);                        
                        }
                        return customer;
                    }
                    else
                    {
                        Console.WriteLine("Fel lösenord. Försök igen.");
                    }
                }
                Console.WriteLine("För många försök. Återgår till huvudmenyn.");
                return null;
            }

            return null;
        }

        public void LogOut(Customer customer)
        {
            Console.Clear();
            Console.WriteLine("Vill du logga ut? (j/n)");
            if (Console.ReadLine().ToLower() == "j")
            {
                //Customer.ActiveCustomer.Clear();
                Customer.LoggedIn = false;
                Customer.ActiveCustomer = null;
                Console.Clear();
                Program.Menu();
            }
            else
            {
                Console.Clear();
                _shoppingMethods.LoggedinMenu(customer);
            }
        }
    }
}
