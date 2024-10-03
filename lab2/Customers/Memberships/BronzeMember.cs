//Brons: 5 % rabatt på hela köpet

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.Customers.Memberships
{
    public class BronzeMember : Customer
    {
        public override string Member { get; set; } = "Brons";
        public override double Discount { get; set; } = 5.0;
        public BronzeMember(string name, string password) : base(name, password) { }
    }
}
