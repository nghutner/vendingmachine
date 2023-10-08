using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
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
                Purchase(thisMachine);
            }
            else if (choice == "2")
            {
                Purchase(thisMachine);
            }
            else
            {
                Exit();
            }
        }

        public string Purchase(Machine machine)
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
                GiveChange(machine);
            }

            return purchaseChoice;
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
                catch (FormatException) 
                {
                }
                catch (Exception)
                {
                    Console.WriteLine("Sorry, an error occurred."); 
                }
                if(moneyFedInt <= 0)   //negative or no valid input- go back to the top of the loop
                {
                    Console.WriteLine("Invalid input.");
                    choice = "1";
                }
                else   //valid money input
                {
                    moneyFedDecimal = (decimal)moneyFedInt;
                    machine.CurrentMoneyProvided += moneyFedDecimal;
                    decimal amountAfter = machine.CurrentMoneyProvided;
                    string logEntry = $"FEED MONEY: {moneyFedDecimal} {amountAfter}";
                    Log.WriteLog(logEntry);
                    Console.WriteLine($"Current money provided: {machine.CurrentMoneyProvided}");
                    choice = GetChoice(PurchaseMenu);
                }
                
            }
            while (choice == "1");
            if (choice == "2")
            {
                SelectProduct(machine);
            }
            if (choice == "3")
            {
                GiveChange(machine);
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

        public string SelectProduct(Machine machine)
        {
            Console.WriteLine(machine.DisplayVendingMachineItems(InputFile));
            if (machine.CurrentMoneyProvided <= 0.00M)
            {
                Console.WriteLine("Current balance is $0.00. Please add more money.");
                GetMoney(machine);
            }
            machine.DisplayVendingMachineItems(InputFile);
            string selection = GetItemCode(machine);
            Dispense(machine, selection);
            Purchase(machine);
            return selection;
        }

        public string GetItemCode(Machine machine)
        {
            Console.WriteLine("Please enter a code to select an item");
            string selection = Console.ReadLine();
            string itemName = "";
            try
            {
                selection = selection.Substring(0, 1).ToUpper() + selection.Substring(1); //for case insensitivity
                itemName = machine.VendingMachineItems[selection].Name;
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Invalid input. Try again.");
                SelectProduct(machine);
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong. Please try again");
                SelectProduct(machine);
            }
            do
            {
                if (machine.Inventory[itemName] == 0)
                {
                    Console.WriteLine("That item is sold out. Please select a different item.");
                    SelectProduct(machine);
                }
            }
            while (!machine.VendingMachineItems.ContainsKey(selection) || machine.Inventory[itemName] == 0);
            return selection;
        }

        public string Dispense(Machine machine, string itemCode)
        {
            string itemName = machine.VendingMachineItems[itemCode].Name;
            decimal cost = machine.VendingMachineItems[itemCode].Price;
            if (machine.CurrentMoneyProvided < cost)
            {
                Console.WriteLine("You do not have enough money to purchase this item.");
                GetMoney(machine);
            }
            machine.CurrentMoneyProvided -= cost;
            machine.Inventory[itemName] -= 1;
            decimal amountAfter = machine.CurrentMoneyProvided;
            string logEntry = $"{itemName} {itemCode} {cost} {amountAfter}";
            Log.WriteLog(logEntry);
            string messageToCustomer = $"Item: " + itemName + "\nPrice: " + cost + "\nMoney remaining: " + machine.CurrentMoneyProvided +
                "\n" + machine.VendingMachineItems[itemCode].PrintMessage();
            Console.WriteLine(messageToCustomer);
            return messageToCustomer;
        }

        public void GiveChange(Machine machine)
        {
            decimal amountBefore = machine.CurrentMoneyProvided;
            int change = (int)(machine.CurrentMoneyProvided * 100);
            int quarters = change / 25;
            change = change % 25;
            int dimes = change / 10;
            change = change % 10;
            int nickels = change % 5;
            string changeMessage = $"Your change is {quarters} quarters, {dimes} dimes, and {nickels} nickels";
            Console.WriteLine(changeMessage);
            machine.CurrentMoneyProvided = 0.00M;
            decimal amountAfter = machine.CurrentMoneyProvided;
            string logEntry = $"GIVE CHANGE {amountBefore} {amountAfter}";
            Log.WriteLog(logEntry);
            Exit();
        }

        public void Exit()
        {
            return;
        }

    }
}
