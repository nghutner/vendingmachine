using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Chip : Item
    {
        public Chip(string name, decimal price) : base(name, price)
        {
        }

        public override string PrintMessage()
        {
            return "Crunch Crunch, Yum!";
        }
    }
}
