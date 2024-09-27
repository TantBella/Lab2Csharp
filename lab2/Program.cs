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
using System;

namespace lab2
{
    class Program
    {
        static AccountMethods accountMethods;

        static void Main(string[] args)
        {
            accountMethods = new AccountMethods(CustomerClass.Customers); // Använd den statiska kundlistan
            // Starta programmet
            Menu();
        }

        // Startmenyn
        static void Menu()
        {
            Console.WriteLine("Välkommen, välj ett av följande menyval:");
            Console.WriteLine("1. Registrera ny kund");
            Console.WriteLine("2. Logga in");

            switch (Console.ReadLine())
            {
                case "1":
                    accountMethods.Register(); // Anropa Register-metoden
                    Login();
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

        // Logga in 
        static void Login()
        {
            Customer loggedInCustomer = accountMethods.Login(); // Anropa Login-metoden
            if (loggedInCustomer != null)
            {
                LoggedinMenu(loggedInCustomer);
            }
            else
            {
                Menu(); // Återgå till menyn om inloggningen misslyckades
            }
        }

        // Andra menyn (när man är inloggad)
        static void LoggedinMenu(Customer customer)
        {
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

        // Handla metod
        static void Shop()
        {
            Console.Clear();
            Console.WriteLine("Handla");
            // Logik för att handla
            Console.ReadKey();
        }

        // Kundvagnsmetod
        static void Cart(Customer customer)
        {
            Console.Clear();
            Console.WriteLine("Kundvagn");
            // Logik för att visa kundvagn
            Console.ReadKey();
        }

        // Kassan metod
        static void CheckOut(Customer customer)
        {
            Console.Clear();
            Console.WriteLine("Gå till kassan");
            // Logik för kassan
            Console.ReadKey();
        }
    }
}
