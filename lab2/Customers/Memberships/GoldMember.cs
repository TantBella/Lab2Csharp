//Guld: 15 % rabatt på hela köpet

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.Customers.Memberships
{
    public class GoldMember : Customer
    {
        public override string Member { get; set; } = "Guld";
        public override double Discount { get; set; } = 15.0;

        public GoldMember(string name, string password) : base(name, password) { }
    }
}
