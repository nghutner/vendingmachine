using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Gum : Item
    {
        public Gum(string name, decimal price) : base(name, price)
        {
        }

        public override string PrintMessage()
        {
            return "Chew Chew, Yum!";
        }
    }
}
