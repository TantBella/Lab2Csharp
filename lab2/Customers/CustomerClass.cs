//Skapa nya kunder
//Hårdkoda 3 kunder som har olika medlemsnivå

using lab2.Shopping;
using lab2.Customers.Memberships;

namespace lab2.Customers
{
    public class Customer
    {
        public static bool LoggedIn { get; set; }
        //Active customer ska kunna vara null
        public static Customer? ActiveCustomer { get; set; }
        private string name;
        public string Name
        {
            get { return name; }
        }
        public string Password { get; private set; }
        public ShoppingCart ShoppingCart { get; set; }
        //Ingen medlemsnivå som standard
        public virtual string Member { get; set; } = "Ej medlem";
        public virtual double Discount { get; set; }

        public Customer(string name, string password)
        {
            this.name = name;
            Password = password;
            ShoppingCart = new ShoppingCart();
        }

        public override string ToString()
        {
            var output = string.Empty;
            output += "Kund: " + Name + "\n";
            output += "Lösenord: " + Password + "\n";
            output += "Medlemsskap: " + Member + "\n";
            output += "Medlemsrabatt: " + Discount + "%\n";

            return output;
        }
   

    public static void SaveNewCustomer(Customer customer, string CustomerList)
    {
        string customerData = $"{customer.Name};{customer.Password}";
        File.AppendAllText(CustomerList, customerData + Environment.NewLine);
    }

    public static Dictionary<string, Customer> FetchNewCustomer(string CustomerList)
    {
        var customerList = new Dictionary<string, Customer>();

        if (File.Exists(CustomerList))
        {
            var lines = File.ReadAllLines(CustomerList);

            foreach (var line in lines)
            {
                var data = line.Split(';');
                if (data.Length == 2)
                {
                    var customer = new Customer(data[0], data[1]);
                    customerList.Add(data[0], customer);
                }
            }
        }
        return customerList;
    }
    }


    public class CustomerClass
    {
        public static Dictionary<string, Customer> Customers { get; set; } = new Dictionary<string, Customer>
        {
               { "David", new PlatinumMember("David", "MVG") },
            { "Knatte", new BronzeMember("Knatte", "123") },
            { "Fnatte", new SilverMember("Fnatte", "321") },
            { "Tjatte", new GoldMember("Tjatte", "213") }
        };
    }
}
