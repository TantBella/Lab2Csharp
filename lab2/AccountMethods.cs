//Registrera ny kund
//Logga in med existerande konto

using lab2.Customers;
using lab2.Shopping;

namespace lab2
{
    public class AccountMethods
    {
        //private readonly string userFile = @"C:\Users\User\OneDrive\Skrivbord\ITHS 24-26\C#\Labb2\Lab2Csharp\lab2\CustomerList.txt";
        private readonly string userFile = "CustomerList.txt";
        private readonly string filePath;
        private readonly Dictionary<string, Customer> _customers;
        private readonly ShoppingMethods _shoppingMethods;

        public AccountMethods(ShoppingMethods shoppingMethods, Dictionary<string, Customer> customers)
        {
            _customers = customers;
            _shoppingMethods = shoppingMethods;

            filePath = Path.Combine(Environment.CurrentDirectory, userFile);

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            var registeredCustomers = Customer.FetchNewCustomer(filePath);

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
            Customer.SaveNewCustomer(newCustomer, filePath);

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
                        if (customer.Member is "Platina" or "Guld" or "Silver" or "Brons")
                        {
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Välkommen: " + customer.Name + "     \nDu är på medlemsskapsnivån: " + customer.Member + " ");
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
