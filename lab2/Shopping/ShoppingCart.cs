//Visa produkterna i konsolen.
//Låt användaren välja vilka produkter de vill
//köpa genom att ange ett nummer.
//Uppdatera kundvagnen med de valda produkterna.
//Justera priser efter rätt valuta

using System;
using System.Collections.Generic;
using System.Linq;
using lab2.Customers;

namespace lab2.Shopping
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


        public void ShowCart(double exchangeRate)
        {
            if (ProductsInCart.Count == 0)
            {
                Console.WriteLine("Kundvagnen är tom.");
            }
            else
            {
                // För att hålla reda på den sammanlagda kostnaden
                double totalCost = 0;

                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine($"{"Produktnamn",-20} {"Styckpris",-10} {"Antal",-5} {"Totalpris",-10}");
                Console.WriteLine("--------------------------------------------------");

                foreach (var product in ProductsInCart)
                {
                    double convertedPrice = product.PricePerUnit * exchangeRate;
                    double productTotalPrice = convertedPrice * product.Quantity;

                    totalCost += productTotalPrice;

                    Console.WriteLine($"{product.Name,-20} {convertedPrice,-10:F2} {product.Quantity,-5} {productTotalPrice,-10:F2}");
                }

                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine($"{"Sammanlagd kostnad:",-20} {totalCost:F2}");
            }
        }


        public double GetTotalCost(string currentCurrency, double exchangeRate)
        {
            double totalCost = 0;
            foreach (var product in ProductsInCart)
            {
                double convertedPrice = product.PricePerUnit * exchangeRate;
                totalCost += convertedPrice * product.Quantity;
            }

            if (Customer.ActiveCustomer != null)
            {
                double discountAmount = totalCost * (Customer.ActiveCustomer.Discount / 100);
                totalCost -= discountAmount;
            }
            return totalCost;
        }


        public void ClearCart()
        {
            ProductsInCart.Clear();
            Console.WriteLine("Kundvagnen har tömts.");
        }
    }
}
