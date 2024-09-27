//Skapa en lista med produkter.
//Visa produkterna i konsolen.
//Låt användaren välja vilka produkter de vill köpa genom att ange ett nummer eller produkt-ID.
//Uppdatera kundvagnen med de valda produkterna.

using System;
using System.Collections.Generic;

namespace lab2
{
    public class Product
    {
        public string Name { get; set; }
        public decimal PricePerUnit { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"{Name} (Pris: {PricePerUnit} kr, Antal: {Quantity})";
        }
    }

    public static class ProductList
    {
        public static List<Product> Products = new List<Product>
        {
            new Product { Name = "Laptop", PricePerUnit = 12000, Quantity = 0 },
            new Product { Name = "Skärm", PricePerUnit = 5000, Quantity = 0 },
            new Product { Name = "Datormus", PricePerUnit = 399, Quantity = 0 },
            new Product { Name = "Tangentbord", PricePerUnit = 650, Quantity = 0 }

        };
    }
}
