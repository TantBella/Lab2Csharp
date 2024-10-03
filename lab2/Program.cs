//Del 12: VG uppgifterna
using System;

namespace lab2
{
    class Program
    {
        static AccountMethods accountMethods;
        static ShoppingMethods shoppingMethods;

        static void Main(string[] args)
        {
            accountMethods = new AccountMethods(CustomerClass.customers);
            shoppingMethods = new ShoppingMethods(accountMethods);
            Menu();
        }

        public static void Menu()
        {
            Console.WriteLine("Välkommen, välj ett av följande menyval:");
            Console.WriteLine("1. Registrera ny kund");
            Console.WriteLine("2. Logga in");
            Console.WriteLine("3. Avsluta");

            switch (Console.ReadLine())
            {
                case "1":
                    accountMethods.Register();
                    Login();
                    break;
                case "2":
                    Login();
                    break;
                case "3":
                    break;
                default:
                    Console.WriteLine("Ogiltigt val. Försök igen.");
                    Menu();
                    break;
            }
        }

        public static void Login()
        {
            Customer loggedInCustomer = accountMethods.Login();
            if (loggedInCustomer != null)
            {
                shoppingMethods.LoggedinMenu(loggedInCustomer);
            }
            else
            {
                Menu();
            }
        }
    }
}
