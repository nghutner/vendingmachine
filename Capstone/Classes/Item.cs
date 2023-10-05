using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public abstract class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; } = 5;

        public Item (string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}
