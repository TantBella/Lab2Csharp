using System;
using System.Collections.Generic;

namespace lab2
{
    internal class ShoppingMethods
    {
        public void Shop(Customer customer)
        {
            Console.Clear();
            Console.WriteLine("Välj produkter att lägga i din kundvagn:");

            List<Product> products = ProductList.Products;
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {products[i].Name} - {products[i].PricePerUnit} kr/st");
            }
            Console.WriteLine("Ange produktnummer för att lägga till i kundvagnen (0 för att avsluta):");

            while (true)
            {
                int choice = int.Parse(Console.ReadLine());
                if (choice == 0) break;
                if (choice > 0 && choice <= products.Count)
                {
                    Console.WriteLine("Ange antal:");
                    int quantity = int.Parse(Console.ReadLine());
                    customer.ShoppingCart.AddToCart(products[choice - 1], quantity);
                }
                else
                {
                    Console.WriteLine("Ogiltigt val. Försök igen.");
                }
            }
            Console.WriteLine("Tillbaka till menyn.");
        }

        public void Cart(Customer customer)
        {
            Console.Clear();
            Console.WriteLine("Din kundvagn:");
            customer.ShoppingCart.ShowCart();
            Console.ReadKey();
        }

        public void CheckOut(Customer customer)
        {
            Console.Clear();
            Console.WriteLine("Gå till kassan:");
            decimal totalCost = customer.ShoppingCart.GetTotalCost();
            Console.WriteLine($"Total kostnad: {totalCost} kr");

            customer.ShoppingCart.ClearCart(); // Tömmer kundvagnen efter betalning
            Console.ReadKey();
        }
    }
}
