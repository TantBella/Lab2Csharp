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
                    LoggedinMenu(customer);
                }
                else
                {
                    Console.WriteLine("Ogiltigt val. Försök igen.");
                }
            }
            LoggedinMenu(customer); 
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
            Console.WriteLine("Gå till kassan:");
            decimal totalCost = customer.ShoppingCart.GetTotalCost();
            Console.WriteLine($"Total kostnad: {totalCost} kr");

            customer.ShoppingCart.ClearCart(); // Tömmer kundvagnen efter betalning
            Console.ReadKey();
            LoggedinMenu(customer); 
        }

        public void LoggedinMenu(Customer customer)
        {
            Console.WriteLine("Vad vill du göra? ");
            Console.WriteLine("1. Handla");
            Console.WriteLine("2. Se kundvagn");
            Console.WriteLine("3. Gå till kassan");

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
                default:
                    Console.WriteLine("Ogiltigt val. Försök igen.");
                    LoggedinMenu(customer);
                    break;
            }
        }
    }
}