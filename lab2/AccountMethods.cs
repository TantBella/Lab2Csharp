using System;
using System.Collections.Generic;

namespace lab2
{
    internal class AccountMethods
    {
        private Dictionary<string, Customer> _customers;

        public AccountMethods(Dictionary<string, Customer> customers)
        {
            _customers = customers;
        }

        // Registrera ny kund
        public void Register()
        {
            Console.Clear();
            Console.WriteLine("Registrera ny kund");

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

            // Skapa och lägg till ny kund
            _customers.Add(username, new Customer(username, password));
            Console.WriteLine("Konto skapat. Tryck på valfri knapp för att fortsätta.");
            Console.ReadKey();
        }

        // Logga in
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
                    return null; // Återgår till menyn
                }
            }
            else
            {
                var customer = _customers[username];

                // Ger användaren 3 försök att ange rätt lösenord
                for (int attempts = 0; attempts < 3; attempts++)
                {
                    Console.Write("Ange lösenord: ");
                    string password = Console.ReadLine();

                    if (customer.Password == password)
                    {
                        Console.WriteLine("Inloggning lyckades! Tryck på valfri knapp för att fortsätta.");
                        Console.ReadKey();
                        return customer; // Returnera den inloggade kunden
                    }
                    else
                    {
                        Console.WriteLine("Fel lösenord. Försök igen.");
                    }
                }

                Console.WriteLine("För många försök. Återgår till huvudmenyn.");
                return null; // Återgår till menyn
            }

            return null; // Om inget returneras
        }
    }
}
