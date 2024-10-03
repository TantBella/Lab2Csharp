using System;
using System.Collections.Generic;
using System.Linq;

namespace lab2
{
    public class ShoppingCart
    {
        public List<Product> ProductsInCart { get; private set; }

        public ShoppingCart()
        {
            ProductsInCart = new List<Product>();
        }

        public void AddToCart(Product product, int quantity)
        {
            Product existingProduct = ProductsInCart.FirstOrDefault(p => p.Name == product.Name);
            if (existingProduct == null)
            {
                ProductsInCart.Add(new Product
                {
                    Name = product.Name,
                    PricePerUnit = product.PricePerUnit,
                    Quantity = quantity
                });
            }
            else
            {
                existingProduct.Quantity += quantity;
            }
            Console.WriteLine($"{quantity} stycken {product.Name} har lagts till i kundvagnen.");
        }

        public void ShowCart()
        {
            if (ProductsInCart.Count == 0)
            {
                Console.WriteLine("Kundvagnen är tom.");
            }
            else
            {
                // För att hålla reda på den sammanlagda kostnaden
                int totalCost = 0;

                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine($"{"Produktnamn",-20} {"Styckpris",-10} {"Antal",-5} {"Totalpris",-10}");
                Console.WriteLine("--------------------------------------------------");

                foreach (var product in ProductsInCart)
                {
                    int productTotalPrice = product.PricePerUnit * product.Quantity;
                    totalCost += productTotalPrice;

                    Console.WriteLine($"{product.Name,-20} {product.PricePerUnit,-10} {product.Quantity,-5} {productTotalPrice,-10}");
                }

                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine($"{"Sammanlagd kostnad:",-20} {totalCost,-10}");
            }
        }

        public int GetTotalCost()
        {
            return ProductsInCart.Sum(p => p.PricePerUnit * p.Quantity);
        }

        public void ClearCart()
        {
            ProductsInCart.Clear();
            Console.WriteLine("Kundvagnen har tömts.");
        }
    }
}
