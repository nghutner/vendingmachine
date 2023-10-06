using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using System.Xml.Serialization;

namespace Capstone.Classes
{
    public class UI
    {
        public const string InputFile = "vendingmachine.csv";

        public const string MainMenu = "1. Display vending machine items \n2. Purchase \n3. Exit";
        public const string PurchaseMenu = "1. Feed Money \n2. Select Product \n3. Finish Transaction";
        public void Run()
        {
            Machine thisMachine = new Machine();
            thisMachine.ReadInventoryInput(InputFile);

            string choice = GetChoice(MainMenu);
            if (choice == "1")
            {
                Console.WriteLine(thisMachine.DisplayVendingMachineItems(InputFile));
            }
            else if (choice == "2")
            {
                Purchase(thisMachine);

            }
            else
            {
                // 
            }
        }

        //public string DisplayMenu()
        //{
        //    string choice = "";
        //    do
        //    {
        //        Console.WriteLine("Please select from the following:");
        //        Console.WriteLine(MainMenu);
        //        choice = Console.ReadLine();
        //    } while (choice != "1" && choice != "2" && choice != "3");
        //    return choice;
        //}

        public void Purchase(Machine machine)
        {
            Console.WriteLine($"Current money provided: {machine.CurrentMoneyProvided}");
            string purchaseChoice = GetChoice(PurchaseMenu);

            if (purchaseChoice == "1")
            {
                GetMoney(machine);
               
            }
            else if (purchaseChoice == "2")
            {
                SelectProduct(machine);
            }
            else
            {
                //FINISH TRANSACTION METHOD:
                // check how much is in CMP
                // do math to find out how much change to leave
                int change = (int)(machine.CurrentMoneyProvided * 100);
                int quarters = change / 25;
                change = change % 25;
                int dimes = change / 10;
                change = change % 10;
                int nickels = change % 5;
                Console.WriteLine($"Your change is {quarters} quarters, {dimes} dimes, and {nickels} nickels");
                machine.CurrentMoneyProvided = 0.00M;
                //DisplayMenu();
                GetChoice(MainMenu);
            }
        }

        public decimal GetMoney(Machine machine)
        {
            string choice = "";
            int moneyFedInt = 0;
            decimal moneyFedDecimal = 0.00M;
            do
            {

                try
                {
                    Console.WriteLine("Enter whole dollar amounts.");
                    string moneyFed = Console.ReadLine();
                    moneyFedInt = int.Parse(moneyFed);
                }
                catch
                {

                }
                moneyFedDecimal = (decimal)moneyFedInt;
                machine.CurrentMoneyProvided += moneyFedDecimal;
                Console.WriteLine($"Current money provided: {machine.CurrentMoneyProvided}");
                choice = GetChoice(PurchaseMenu);
            }
            while (choice == "1");
            if (choice == "2")
            {
                SelectProduct(machine);
            }
            if(choice == "3")
            {
                //call finishTransaction method
            }
            return moneyFedDecimal;

        }

        public string GetChoice(string menu)
        {
            Console.WriteLine("Please select from the following:");
            Console.WriteLine(menu);
            string choice = "";
            do
            {
                choice = Console.ReadLine();
                if (choice != "1" && choice != "2" && choice != "3")
                {
                    Console.WriteLine("Invalid input. Please enter 1, 2, or 3.");
                }
            }
            while (choice != "1" && choice != "2" && choice != "3");
            return choice;
        }

        public void SelectProduct(Machine machine)
        {
            machine.ReadInventoryInput(InputFile);
            if (machine.CurrentMoneyProvided <= 0.00M)
            {
                Console.WriteLine("Current balance is $0.00. Please add more money.");
                GetMoney(machine);
            }
            machine.ReadInventoryInput(InputFile);
            string selection = GetItemCode(machine);
            //string itemName = machine.VendingMachineItems[selection].Name;
            Dispense(machine, selection);
            Purchase(machine);
        }

        public string GetItemCode(Machine machine)
        {
            Console.WriteLine("Please enter a code to select an item");
            string selection = Console.ReadLine();
            string itemName = machine.VendingMachineItems[selection].Name;
            do
            {
                if (!machine.VendingMachineItems.ContainsKey(selection))
                {
                    Console.WriteLine("Invalid input. Try again.");
                }
                else if (machine.Inventory[itemName] == 0)
                {
                    Console.WriteLine("That item is sold out. Please select a different item.");
                }
            }
            while (!machine.VendingMachineItems.ContainsKey(selection) || machine.Inventory[itemName] == 0);
            return selection;
        }

        public bool Dispense(Machine machine, string itemCode)
        {
            bool isDispensed = false;
            string itemName = machine.VendingMachineItems[itemCode].Name;
            decimal cost = machine.VendingMachineItems[itemCode].Price;
            machine.CurrentMoneyProvided -= cost;
            machine.Inventory[itemName] -= 1;
            Console.WriteLine(machine.Inventory[itemName]);
            string messageToCustomer = $"Item: " + itemName + "\nPrice: " + cost + "\nMoney remaining: " + machine.CurrentMoneyProvided + 
                "\n" + machine.VendingMachineItems[itemCode].PrintMessage();
            Console.WriteLine(messageToCustomer);
            isDispensed = true;
            return isDispensed;
        }

    }
}
