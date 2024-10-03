//Silver: 10 % rabatt på hela köpet

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.Customers.Memberships
{
    public class SilverMember : Customer
    {
        public override string Member { get; set; } = "Silver";
        public override double Discount { get; set; } = 10.0;
        public SilverMember(string name, string password) : base(name, password) { }
    }
}
