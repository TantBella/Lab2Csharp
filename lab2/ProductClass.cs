namespace lab2
{
    public class Product
    {
        public string ProductName { get; }
        public decimal PricePerUnit { get; }
        public int Quantity { get; set; }

        public Product(string productName, decimal pricePerUnit, int quantity)
        {
            ProductName = productName;
            PricePerUnit = pricePerUnit;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"{ProductName} (Pris: {PricePerUnit} kr, Antal: {Quantity})";
        }
    }
}
