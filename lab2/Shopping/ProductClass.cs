//Skapa en lista med produkter.

using System;
using System.Collections.Generic;

namespace lab2.Shopping
{
    public class Product
    {
        public string Name { get; set; }
        public int SekPricePerUnit { get; set; }
        public int PricePerUnit { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"{Name} (Pris: {PricePerUnit} kr, Antal: {Quantity})";
        }
        public void UpdatePrice(double exchangeRate)
        {
            PricePerUnit = (int)(SekPricePerUnit * exchangeRate);
        }
    }

    public static class ProductList
    {
        public static List<Product> Products = new List<Product>
        {
            new Product { Name = "Laptop", SekPricePerUnit = 12000, PricePerUnit = 12000, Quantity = 0 },
            new Product { Name = "Skärm", SekPricePerUnit = 5000, PricePerUnit = 5000, Quantity = 0 },
            new Product { Name = "Datormus", SekPricePerUnit = 399, PricePerUnit = 399, Quantity = 0 },
            new Product { Name = "Tangentbord", SekPricePerUnit = 650, PricePerUnit = 650, Quantity = 0 }

        };
        public static void UpdatePrices(double exchangeRate)
        {
            foreach (var product in Products)
            {
                product.UpdatePrice(exchangeRate);
            }
        }
    }
}
