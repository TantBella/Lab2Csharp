using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public class BronzeMember : Customer
    {
        public override string Member { get; set; } = "Brons";
        public override double Discount { get; set; } = 5.0;
        public BronzeMember(string name, string password) : base(name, password) { }
    }
}


//Guld: 15 % rabatt på hela köpet
//Silver: 10 % rabatt på hela köpet
//Brons: 5 % rabatt på hela köpet
//Nivåerna skall implementeras med hjälp av arv av basklassen Kund