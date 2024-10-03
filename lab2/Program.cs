//Del 12: VG uppgifterna:
//Medlemssystem med rabatt
// Valuta kurser
//Spara nya kunder
//Kolla så inga fel finns
//Städa upp koden så den blir CLEAN/DRY
//Frivilligt om tid funns: styling med färg 
using System;

namespace lab2
{
    class Program
    {
        static AccountMethods accountMethods;
        static ShoppingMethods shoppingMethods;

        static void Main(string[] args)
        {
            List<Product> products = ProductList.Products;

            shoppingMethods = new ShoppingMethods(null, products);
            accountMethods = new AccountMethods(shoppingMethods, CustomerClass.customers);

            shoppingMethods = new ShoppingMethods(accountMethods, products);

            Menu();
        }

        public static void Menu()
        {
            Console.Clear();
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
            Customer LoggedIn = accountMethods.Login();
            if (Customer.LoggedIn == true)
            {
                shoppingMethods.LoggedinMenu(LoggedIn);
            }
            else         
            {
                Customer.LoggedIn = false;
                Customer.ActiveCustomer = null;
                Menu();
            }
        }
    }
}
