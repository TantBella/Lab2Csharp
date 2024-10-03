﻿using System;
using System.Collections.Generic;

namespace lab2
{
    public class ShoppingMethods
    {
        private AccountMethods accountMethods;

        public ShoppingMethods(AccountMethods accountMethods)
        {
            this.accountMethods = accountMethods;
        }

        public void Shop(Customer customer)
        {
            Console.Clear();
            Console.WriteLine("Välj produkter att lägga i din kundvagn:\n");
            Console.WriteLine($"{"Produktnamn: ",-20} {"Styckpris: "} ");
            List<Product> products = ProductList.Products;
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine($"{i + 1}. {products[i].Name,-20}  {products[i].PricePerUnit} kr/st ");
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

        public void CheckOut(Customer customer)
        {
            Console.Clear();
            Console.WriteLine("Du vill köpa:");

            // Hämta produkterna från kundvagnen
            List<CartItem> productsInCart = customer.ShoppingCart.GetItems();

            // Kontrollera om kundvagnen är tom
            if (productsInCart.Count == 0)
            {
                Console.WriteLine("Din kundvagn är tom.");
                Console.ReadKey();
                LoggedinMenu(customer);
                return;
            }

            // Visa produkterna i kundvagnen
            foreach (var product in productsInCart)
            {
                Console.WriteLine($"{product.Quantity,-5} stycken {product.Product.Name}");
            }

            Console.WriteLine("--------------------------------------------------");

            // Beräkna och visa total kostnad
            int totalCost = customer.ShoppingCart.GetTotalCost();
            Console.WriteLine($"{"Sammanlagd kostnad:",-20} {totalCost} kr");

            // Uppmana användaren att betala
            Console.WriteLine($"Total kostnad: {totalCost} kr\nTryck på valfri tangent för att betala.");
            Console.ReadKey();

            // Töm kundvagnen efter betalning
            customer.ShoppingCart.ClearCart();
            Console.WriteLine("Tack för ditt köp! Välkommen åter.");
            Console.ReadKey();
            LoggedinMenu(customer);
        }

        //public void CheckOut(Customer customer)
        //{
        //    Console.Clear();
        //    Console.WriteLine("Du vill köpa:");

        //    foreach (var product in ProductsInCart)
        //    {

        //        Console.WriteLine($"{product.Quantity,-5} stycken {product.Name,-20}");
        //    }

        //    Console.WriteLine("--------------------------------------------------");
        //    Console.WriteLine($"{"Sammanlagd kostnad:",-20} {totalCost,-10}");
        //}
        //int totalCost = customer.ShoppingCart.GetTotalCost();
        //    Console.WriteLine($"Total kostnad: {totalCost} kr\nTryck på valfri tangent för att betala.");
        //    Console.ReadKey();
        //    customer.ShoppingCart.ClearCart();
        //    Console.WriteLine("Tack för ditt köp! Välkommen åter.");
        //    Console.ReadKey();
        //    LoggedinMenu(customer);
        //}

        public void LoggedinMenu(Customer customer)
        {
            Console.WriteLine("Vad vill du göra?");
            Console.WriteLine("1. Handla");
            Console.WriteLine("2. Se kundvagn");
            Console.WriteLine("3. Gå till kassan");
            Console.WriteLine("4. Logga ut");

            switch (Console.ReadLine())
            {
                case "1":
                    Shop(customer);
                    break;
                case "2":
                    Cart(customer);
                    break;
                case "3":
                    CheckOut(customer);
                    break;
                case "4":
                    accountMethods.LogOut(customer);
                    break;
                default:
                    Console.WriteLine("Ogiltigt val. Försök igen.");
                    LoggedinMenu(customer);
                    break;
            }
        }
    }
}