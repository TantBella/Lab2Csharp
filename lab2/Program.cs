// Del 1: Skapa en huvudmeny där man kan registrera ny kund och logga in -switch? cHHECK

//Del 2: Skapa en kund klass med properties namn (kan inte ändras), lösen, Kundvagn 
//(en lista av produkter) CHECK

//Del 3: Skapa en produkt klass med produktnamn, pris perstyck, antal i kundvagn CHECK
//3a: sammanlagd summa äär PricePerUnit * Quantity, gör en metod som returmerar detta

//Del 4: REgistera ny kund ska vara ett menyval, begär användarnan och lösen och 
//lägg sen användaren i en kundlista, kontorllera att kundnamnet är unikt CHECK

//Del 5: Logga in, be om namn och lösen, kontorllera om allt finns och sätmmer,
//om fel lösen ges visa felmeddleande och försök igen CHECK

//Del 6: När man loggat in så ska en ny meny visas med följande val: handla, visa
//kundvagn, gå till kassan CHECK

//Del 7: Handla, visa minst 3 produkter, låt användaren välja proukter, gör en
//metod som lägger till produkter ochupdaterar antal om samma produkt redan finns

//DEl 8: Visa kundvagn. Skapa en funktion som visar alla produkter i kundvagen,
//styckpris, antal, totalpris, total kostand för allt

//Del 9: Gå till kassan, visa en sammanfattning av kundvagn och totalpriset för allt,
//töm kundvagn efter betalning

//Del 10: skapa en ToString() metod i kund klassen som skriver ut namn, lösen,
//innehållet i kundvagn på snyggt sätt,
//med namn, pris och total kostnad


// Produkter som finns att köpa
Dictionary<string, double> products = new Dictionary<string, double>();
products["Ett paket mjölk"] = 19.90;
products["Krossade tomater"] = 16.89;
products["Prinskorv"] = 46;
products["1 kg Äpplen"] = 33;
products["Pågen limpa"] = 28.99;

//foreach (KeyValuePair<string, double> product in products)
//{
//    Console.WriteLine(product.Key + ": " + product.Value.ToString());
//}


// En lista med kunder
Dictionary<string, Customer> customers = new Dictionary<string, Customer>()
    {
        { "Kund1", new Customer("Knatte", "123") },
        { "Kund2", new Customer("Fnatte", "321") },
        { "Kund3", new Customer("Tjatte", "213") }
};

// En lista för kundens kundvagn
List<string> customerCart = new List<string>();

//starta programmet
Menu();

//Startmenyn
void Menu()
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
            Menu();
            break;
    }
}
//REgistera ny kund
 void Register()
{
    Console.Clear();
    Console.WriteLine("Registrera ny kund");

    string username;
    string password;

    while (true)
    {
        Console.Write("Ange användarnamn: ");
        username = Console.ReadLine();
        if (customers.ContainsKey(username))
        {
            Console.WriteLine("Användarnamnet är upptaget. Försök igen.");
        }
        else
        {
            break;
        }
    }

    Console.Write("Ange lösenord: ");
    password = Console.ReadLine();

    customers.Add(username, new Customer(username, password));
    Console.WriteLine("Konto skapat. Tryck på valfri knapp för att fortsätta.");
    Console.ReadKey();
    Login();
}

//Logga in 
void Login()
{
    Console.Clear();
    Console.WriteLine("Logga in");

    Console.Write("Ange användarnamn: ");
    string username = Console.ReadLine();

    if (!customers.ContainsKey(username))
    {
        Console.WriteLine("Kunden finns inte. Vill du registrera en ny kund? (j/n)");
        if (Console.ReadLine().ToLower() == "j")
        {
            Register();
        }
        else
        {
            Console.WriteLine("Återgår till huvudmenyn. Tryck på valfri knapp.");
            Console.ReadKey();
            Menu();
        }
        return;
    }

    var customer = customers[username]; 

    // Ge användaren 3 försök att ange rätt lösenord
    for (int attempts = 0; attempts < 3; attempts++)
    {
        Console.Write("Ange lösenord: ");
        string password = Console.ReadLine();

        if (customer.Password == password)
        {
            Console.WriteLine("Inloggning lyckades! Tryck på valfri knapp för att fortsätta.");
            Console.ReadKey();
            LoggedinMenu(); 
            return;
        }
        else
        {
            Console.WriteLine("Fel lösenord. Försök igen.");
        }
    }

    Console.WriteLine("För många försök. Återgår till huvudmenyn.");
    Console.ReadKey();
    Menu(); 
}


//Andra menyn (när man är inloggad)
void LoggedinMenu()
{
    //Console.WriteLine("Välkommen " + customer.username);
    Console.WriteLine("Välj ett av följande menyval:");
    Console.WriteLine("1. Handla");
    Console.WriteLine("2. Se kundvagn");
    Console.WriteLine("3. Gå till kassan");

    switch (Console.ReadLine())
    {
        case "1":
            Shop();
            break;
        case "2":
            Cart();
            break;
        case "3":
            CheckOut();
            break;
        default:
            Console.WriteLine("Ogiltigt val. Försök igen.");
            LoggedinMenu();
            break;
    }
}

//Handla metod
void Shop() {
    Console.Clear();
    Console.WriteLine("Handla");
    return;
}
//Kundvagnsmetod
void Cart()
{
    Console.Clear();
    Console.WriteLine("Kundvagn");
    return;
}
//Kassan meotd
void CheckOut()
{
    Console.Clear();
    Console.WriteLine("Gå till kassan");
    return;
}
//Kundklass
public class Customer
{
    public string Name { get; private set; }
    public string Password { get; private set; }
    private List<Product> _customerCart;
    public List<Product> CustomerCart { get { return _customerCart; } }

    public Customer(string username, string password)
    {
        Name = username;
        Password = password;
        _customerCart = new List<Product>();
    }
}

//public override string ToString()
//    {
//        string cartContents = _customerCart.Count > 0 ? string.Join(", ", _customerCart) : "Kundvagnen är tom";
//        return $"Kund: {Name}\nLösenord: {Password}\nKundvagn: {cartContents}";
//    }
//}
//Produktklass
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


