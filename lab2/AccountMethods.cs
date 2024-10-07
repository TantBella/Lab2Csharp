//fixa så inte programmet kraschar när man försöker logga ut. Möjligen behöv logga ut läggas i shoppingmethods
//Fråga david om hjälp, varför den kraschar vid utloggning
//Om man ändrar valutan efter man lagt nåt i kundvagnen hur justeras priset då
//behöver jag ha quantity redan när jag deklararer producten i listna?
//det står inget i customerlist fast  användaren är registrerad
//ska bara de förprogrammerade ha medlemsnivå eller nya användare också?

using System;
using System.Collections.Generic;
using lab2.Customers;
using lab2.Shopping;

namespace lab2
{
    public class AccountMethods
    {
        private readonly Dictionary<string, Customer> _customers;
        private readonly ShoppingMethods _shoppingMethods;

        public AccountMethods(ShoppingMethods shoppingMethods, Dictionary<string, Customer> customers)
        {
            _customers = customers;
            _shoppingMethods = shoppingMethods;

            var registeredCustomers = Customer.FetchNewCustomer("CustomerList.txt");
            foreach (var customer in registeredCustomers)
            {
                _customers.Add(customer.Key, customer.Value);
            }
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

            var newCustomer = new Customer(username, password);
            _customers.Add(username, newCustomer);
            Customer.SaveNewCustomer(newCustomer, "CustomerList.txt");

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
                Console.WriteLine("Användarnamnet finns inte. Vill du registrera en ny kund? (j/n)");
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
                        Console.WriteLine($"Lösenordet för {customer.Name} stämmer inte.. Försök igen.");
                    }
                }
                Console.WriteLine("För många lösenords försök. Återgår till huvudmenyn.");
                return null;
            }
        return null;
        }
    }
}
