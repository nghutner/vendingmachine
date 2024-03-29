﻿using System;
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

        public Dictionary<string, Item> VendingMachineItems { get; private set; } = new Dictionary<string, Item>();
        public Dictionary<string, int> Inventory { get; private set; } = new Dictionary<string, int>();
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
                            string line = sr.ReadLine().Trim();
                            string[] inventoryInfo = line.Split('|');
                            if (
                                inventoryInfo != null &&
                                inventoryInfo.Length == 4 &&
                                !inventoryInfo.Contains("") &&
                                !inventoryInfo.Contains(null))
                            {
                                AddToDictionary(inventoryInfo);
                            }
                        }
                        catch (Exception)
                        {
                            Log.LogAnError("Unable to process input line");
                        }
                    }
                }
            }
            catch (IOException)
            {
                Log.LogAnError("IOException, Unable to read file.");
            }
            catch (Exception)
            {
                Log.LogAnError("Non-IOException, unable to read file.");
            }
            return VendingMachineItems;
        }

        public Dictionary<string, Item> AddToDictionary(string[] menuItemLine)
        {
            try
            {
                if (
                menuItemLine != null &&
                menuItemLine.Length == 4 &&
                !menuItemLine.Contains("") &&
                !menuItemLine.Contains(null))
                {
                    string itemCodeCorrectCase = menuItemLine[0].ToUpper();
                    VendingMachineItems[itemCodeCorrectCase] = null;
                    try
                    {
                        decimal price = decimal.Parse(menuItemLine[2]);
                        if (price < 0.00M)
                        {

                        }
                        else
                        {
                            Inventory[menuItemLine[1]] = MaxQuantity;
                            if (menuItemLine[menuItemLine.Length - 1] == "Chip")
                            {
                                Chip newChip = new Chip(menuItemLine[1], price);
                                VendingMachineItems[itemCodeCorrectCase] = newChip;
                            }
                            else if (menuItemLine[menuItemLine.Length - 1] == "Candy")
                            {
                                Candy newCandy = new Candy(menuItemLine[1], price);
                                VendingMachineItems[itemCodeCorrectCase] = newCandy;
                            }
                            else if (menuItemLine[menuItemLine.Length - 1] == "Gum")
                            {
                                Gum newGum = new Gum(menuItemLine[1], price);
                                VendingMachineItems[itemCodeCorrectCase] = newGum;
                            }
                            else if (menuItemLine[menuItemLine.Length - 1] == "Drink")
                            {
                                Drink newDrink = new Drink(menuItemLine[1], price);
                                VendingMachineItems[itemCodeCorrectCase] = newDrink;
                            }
                        }
                            
                    }
                    catch (Exception)
                    {
                        Log.LogAnError("Unable to parse input");
                    }
                }
            }
            catch (NullReferenceException)
            {
                Log.LogAnError("null item in array");
            }
            catch (Exception)
            {
                Log.LogAnError("non-NullReference exception");
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
                                displayLine = $"{line}|In Stock: {Inventory[lineArray[1]]}| SOLD OUT \n";
                            }
                            allItems += displayLine;
                        }
                        catch
                        {
                            Console.WriteLine("Something went wrong.");
                            Log.LogAnError("Error processing DisplayVendingMachineItems data");
                        }

                    }
                }
            }
            catch
            {
                Log.LogAnError("Unable to read file");
            }
            return allItems;
        }
    }
}
