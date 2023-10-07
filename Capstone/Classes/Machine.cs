using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Capstone.Classes
{
    public class Machine
    {
        const int MaxQuantity = 5;
        public const string InputFile = "vendingmachine.csv";

        public Dictionary<string, Item> VendingMachineItems { get; set; } = new Dictionary<string, Item>();
        public Dictionary<string, int> Inventory { get; set; } = new Dictionary<string, int>();
        public decimal CurrentMoneyProvided { get; set; } = 0.00M;
        public Dictionary<string, Item> ReadInventoryInput(string inputFile)
        {
            try
            {
                using (StreamReader sr = new StreamReader(inputFile))
                {
                    while (!sr.EndOfStream)
                    {
                        try
                        {
                            string line = sr.ReadLine();
                            string[] inventoryInfo = line.Split('|');
                            AddToDictionary(inventoryInfo);
                            
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }
            catch (IOException)
            {

            }
            catch (Exception)
            {

            }
            return VendingMachineItems;
        }

        public Dictionary<string, Item> AddToDictionary(string[] menuItemLine)
        {
            if (menuItemLine.Length != 4)
            {
                throw new InvalidArrayLengthException();
            }
            VendingMachineItems[menuItemLine[0]] = null;
            Inventory[menuItemLine[1]] = MaxQuantity;
            if (menuItemLine[menuItemLine.Length - 1] == "Chip")
            {
                Chip newChip = new Chip(menuItemLine[1], decimal.Parse(menuItemLine[2]));
                VendingMachineItems[menuItemLine[0]] = newChip;
            }
            else if (menuItemLine[menuItemLine.Length - 1] == "Candy")
            {
                Candy newCandy = new Candy(menuItemLine[1], decimal.Parse(menuItemLine[2]));
                VendingMachineItems[menuItemLine[0]] = newCandy;
            }
            else if (menuItemLine[menuItemLine.Length - 1] == "Gum")
            {
                Gum newGum = new Gum(menuItemLine[1], decimal.Parse(menuItemLine[2]));
                VendingMachineItems[menuItemLine[0]] = newGum;
            }
            else if (menuItemLine[menuItemLine.Length - 1] == "Drink")
            {
                Drink newDrink = new Drink(menuItemLine[1], decimal.Parse(menuItemLine[2]));
                VendingMachineItems[menuItemLine[0]] = newDrink;
            }
            return VendingMachineItems;
        }
        public string DisplayVendingMachineItems(string InputFile)
        {
            string allItems = "";
            try
            {
                using (StreamReader sr = new StreamReader(InputFile))
                {
                    while (!sr.EndOfStream)
                    {
                        try
                        {
                            string line = sr.ReadLine();
                            string[] lineArray = line.Split('|');
                            string displayLine = $"{line}|In Stock: {Inventory[lineArray[1]]} \n";
                            if (Inventory[lineArray[1]] == 0)
                            {
                                displayLine += "| SOLD OUT";
                            }
                            allItems += displayLine;
                        }
                        catch
                        {
                            Console.WriteLine("Something went wrong.");
                        }

                    }
                }
            }
            catch
            {

            }
            return allItems;
        }
    }
}
