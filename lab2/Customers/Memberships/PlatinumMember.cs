//Platinum 50% rabatt på hela köpet

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.Customers.Memberships
{
    public class PlatinumMember : Customer
    {
        public override string Member { get; set; } = "Platina";
        public override double Discount { get; set; } = 50.0;
        public PlatinumMember(string name, string password) : base(name, password) { }
    }
}
