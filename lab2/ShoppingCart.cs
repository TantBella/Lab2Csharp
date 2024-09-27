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
            Console.WriteLine($"{quantity} {product.Name} har lagts till i kundvagnen.");
        }
        public void ShowCart()
        {
            if (ProductsInCart.Count == 0)
            {
                Console.WriteLine("Kundvagnen är tom.");
            }
            else
            {
                foreach (var product in ProductsInCart)
                {
                    Console.WriteLine(product.ToString());
                }
            }
        }

        public decimal GetTotalCost()
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
