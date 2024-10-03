using System;
using System.Collections.Generic;
using lab2.Customers;

namespace lab2.Shopping
{
    public class ShoppingMethods
    {
        private AccountMethods accountMethods;
        private List<Product> _products;
        private string currentCurrency = "SEK";
        private double exchangeRate = 1.0;

        public ShoppingMethods(AccountMethods accountMethods, List<Product> products)
        {
            this.accountMethods = accountMethods;
            _products = products;
        }

        public void Shop(Customer customer)
        {
            Console.Clear();

            Console.WriteLine("Välj produkter att lägga i din kundvagn.\nEventuella rabatter tillkommer i kassan. \n");
            Console.WriteLine($"{"Produktnamn: ",-20} {"Styckpris: "} ");
            List<Product> products = ProductList.Products;
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine($"{i + 1}. {products[i].Name,-20}  {products[i].PricePerUnit} :- ");
            }

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("\nAnge produktnummer för att lägga till i kundvagnen (0 för att avsluta):");

            while (true)
            {
                int choice = int.Parse(Console.ReadLine());
                if (choice == 0) break;
                if (choice > 0 && choice <= products.Count)
                {
                    Console.WriteLine("Ange antal:");
                    int quantity = int.Parse(Console.ReadLine());
                    customer.ShoppingCart.AddToCart(products[choice - 1], quantity);
                    LoggedinMenu(customer);
                }
                else
                {
                    Console.WriteLine("Ogiltigt val. Försök igen.");
                }
            }
        }

        public void Cart(Customer customer)
        {
            Console.Clear();
            Console.WriteLine("Din kundvagn:");
            customer.ShoppingCart.ShowCart();
            Console.ReadKey();
            LoggedinMenu(customer);
        }

        public void ChangeCurrency()
        {
            Console.Clear();
            Console.WriteLine("Välj valuta: \n1. SEK \n2. USD \n3. EUR");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    currentCurrency = "SEK";
                    exchangeRate = 1.0;
                    break;
                case "2":
                    currentCurrency = "USD";
                    exchangeRate = 0.10;
                    break;
                case "3":
                    currentCurrency = "EUR";
                    exchangeRate = 0.11;
                    break;
                default:
                    Console.WriteLine("Ogiltigt val. Standardvaluta SEK används.");
                    currentCurrency = "SEK";
                    exchangeRate = 1.0;
                    break;
            }

            ProductList.UpdatePrices(exchangeRate);

            Console.WriteLine($"Valutan har ändrats till {currentCurrency}.");
            Console.ReadKey();
            LoggedinMenu(Customer.ActiveCustomer);
        }

        public void CheckOut(Customer customer)
        {
            Console.Clear();
            Console.WriteLine("Din kundvagn: ");

            foreach (var product in customer.ShoppingCart.ProductsInCart)
            {
                Console.WriteLine($"{product.Quantity,-5} stycken {product.Name}");
            }

            double totalCost = customer.ShoppingCart.GetTotalCost();
            double discountAmount = totalCost * (customer.Discount / 100);

            if (discountAmount > 0)
            {
                Console.WriteLine($"Din medlemsnivå ger dig en rabatt på {customer.Discount}%. \n");
            }

            Console.WriteLine($"Total kostnadt: {totalCost} kr\nTryck på valfri tangent för att betala.");
            Console.ReadKey();

            customer.ShoppingCart.ClearCart();
            Console.WriteLine("Tack för ditt köp! Välkommen åter.\n");
            Console.ReadKey();
            LoggedinMenu(customer);
        }
        public void LogOut(Customer customer)
        {
            Console.Clear();

            Customer.LoggedIn = false;
            Console.WriteLine("Du är utloggad");
            Console.ReadLine();
        }

        public void LoggedinMenu(Customer customer)
        {
            Console.WriteLine("Vad vill du göra? \n1. Handla \n2. Se kundvagn \n3. Ändra valuta \n4. Gå till kassan \n5. Logga ut");

            switch (Console.ReadLine())
            {
                case "1":
                    Shop(customer);
                    break;
                case "2":
                    Cart(customer);
                    break;
                case "3":
                    ChangeCurrency();
                    break;
                case "4":
                    CheckOut(customer);
                    break;
                case "5":
                    LogOut(customer);
                    break;
                default:
                    Console.WriteLine("Ogiltigt val. Försök igen.");
                    LoggedinMenu(customer);
                    break;
            }
        }
    }
}