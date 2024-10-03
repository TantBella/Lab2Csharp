//fixa så inte programmet kraschar när man försöker logga ut. Möjligen behöv logga ut läggas i shoppingmethods
//Fråga david om hjälp, varför den kraschar vid utloggning
//Om man ändrar valutan efter man lagt nåt i kundvagnen hur justeras priset då
using System;
using System.Collections.Generic;
using lab2.Customers;
using lab2.Shopping;

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
                        if (customer.Member is "Guld" or "Silver" or "Brons")
                        {
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("Välkommen: " + customer.Name + "\nDu är på medlemsskapsnivån: " + customer.Member);
                            Console.ResetColor();
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
    }
}
