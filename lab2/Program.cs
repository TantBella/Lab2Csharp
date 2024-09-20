﻿// Del 1: Skapa en huvudmeny där man kan registrera ny kund och logga in -switch? cHHECK

//Del 2: Skapa en kund klass med properties namn (kan inte ändras), lösen, Kundvagn 
//(en lista av produkter) CHECK

//Del 3: Skapa en produkt klass med produktnamn, pris perstyck, antal i kundvagn

//Del 4: REgistera ny kund ska vara ett menyval, begär användarnan och lösen och 
//lägg sen användaren i en kundlista, kontorllera att kundnamnet är unikt

//Del 5: Logga in, be om namn och lösen, kontorllera om allt finns och sätmmer,
//om fel lösen ges visa felmeddleande och försök igen

//Del 6: När man loggat in så ska en ny meny visas med följande val: handla, visa
//kundvagn, gå till kassan

//Del 7: Handla, visa minst 3 produkter, låt användaren välja proukter, gör en
//metod som lägger till produkter ochupdaterar antal om samma produkt redan finns

//DEl 8: Visa kundvagn. Skapa en funktion som visar alla produkter i kundvagen,
//styckpris, antal, totalpris, total kostand för allt

//Del 9: Gå till kassan, visa en sammanfattning av kundvagn och totalpriset för allt,
//töm kundvagn efter betalning

//Del 10: skapa en ToString() metod i kund klassen som skriver ut namn, lösen,
//innehållet i kundvagn på snyggt sätt,
//med namn, pris och total kostnad


//static List<Customer> customers = new List<Customer>();

static void Menu()
{
    Console.WriteLine("Välkommen, välj ett av följande menyval:");
    Console.WriteLine("1. Registrera ny kund");
    Console.WriteLine("2. Logga in");

    switch (Console.ReadLine())
    {
        case "1":
            Register();
            break;
        case "2":
            Login();
            break;
        default:
            Console.WriteLine("Ogiltigt val. Försök igen.");
            break;
    }
}

public class Customer
{
    public string Name;
    public string Password;
    public List<Product> Cart { get; }
    public Customer(string name, string password)
    {
        Name = name;  
        Password = password;
        Cart = new List<Product>(); 
    }
}

class Product
{
    public string ProductName;
    public decimal PricePerUnit;
    public int Quantity;

    public Product(string productName, decimal pricePerUnit, int quantity)
    {
        ProductName = productName;
        PricePerUnit = pricePerUnit;
        Quantity = quantity;
    }
}

