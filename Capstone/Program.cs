using System;
using System.Collections.Generic;
using System.Transactions;
using Capstone.Classes;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            UI ui = new UI();
            ui.Run();
            //Machine test = new Machine();
            //test.ReadInventoryInput("happypath.txt");
            //foreach(KeyValuePair<string, Item> kvp in test.VendingMachineItems)
            //{
            //    Console.WriteLine($"{ kvp.Key}: {kvp.Value.Name}");
            //}
        }
    }
}
