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
List<string> Products = new List<string> { "Korv", "Dricka", "Äpple", "Bröd", "Pasta" };
// En lista med kunder
 List<Customer> Customers = new List<Customer>();
// En lista för kundens kundvagn
 List<string> CustomerCart = new List<string>();
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

    Console.Write("Ange användarnamn: ");
    string username = Console.ReadLine();

    Console.Write("Ange lösenord: ");
    string password = Console.ReadLine();
    foreach (var customer in Customers)
    {
        if (customer.Name == username)
        {
            Console.WriteLine("Användarnamnet är upptaget.");
            Console.ReadKey();
             Register(); 
        }
    }
    Customers.Add(new Customer(username, password));
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

    var customer = Customers.FirstOrDefault(c => c.Name == username); 
    if (customer == null) 
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
        }
        return; 
    }

    for (int attempts = 0; attempts < 3; attempts++)
    {
        Console.Write("Ange lösenord: ");
        string password = Console.ReadLine();

        if (customer.Password == password) 
        {
            Console.WriteLine("Inloggning lyckades! Tryck på valfri knapp för att fortsätta.");
            Console.ReadKey();
            LoggedinMenu();
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

//Andra menyn (när man är inloggas)
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
    Console.WriteLine("Handla");
    return;
}
//Kundvagnsmetod
void Cart()
{
    Console.WriteLine("Kundvagn");
    return;
}
//Kassan meotd
void CheckOut()
{
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
    public override string ToString()
    {
        string cartContents = _customerCart.Count > 0 ? string.Join(", ", _customerCart) : "Kundvagnen är tom";
        return $"Kund: {Name}\nLösenord: {Password}\nKundvagn: {cartContents}";
    }
}
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


