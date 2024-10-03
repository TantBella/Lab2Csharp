using System;
using System.Collections.Generic;

namespace lab2
{
    public class ShoppingMethods
    {
        private AccountMethods _accountMethods;
        private List<Product> _products;

        public ShoppingMethods(AccountMethods accountMethods, List<Product> products)
        {
            _accountMethods = accountMethods;
            _products = products;
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
                Console.WriteLine(customer.Name + "s kundvagn: ");
                foreach (var product in customer.ShoppingCart.ProductsInCart)
                {
                    Console.WriteLine($"{product.Quantity,-5} stycken {product.Name}");
                }
            double totalCost = customer.ShoppingCart.GetTotalCost();
                double discountAmount = totalCost * (customer.Discount / 100);
                double totalAfterDiscount = totalCost - discountAmount;
                Console.WriteLine($"Total kostnad: {totalCost} kr\n--------------------------------------------------\nTryck på valfri tangent för att betala.");
                Console.ReadKey();
                customer.ShoppingCart.ClearCart();
                Console.WriteLine("Tack för ditt köp! Välkommen åter.\n");
                Console.ReadKey();
                LoggedinMenu(customer);
            }

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
                    _accountMethods.LogOut(customer);
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val. Försök igen.");
                        LoggedinMenu(customer);
                        break;
                }
            }
        
    }
}