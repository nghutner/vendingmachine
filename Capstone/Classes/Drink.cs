using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;

namespace Capstone.Classes
{
    public class Drink : Item
    {
        public Drink(string name, decimal price) : base(name, price)
        {
        }

        public override string PrintMessage()
        {
            return "Glug Glug, Yum!";
        }
    }
}
