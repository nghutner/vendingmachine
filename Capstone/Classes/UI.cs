using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using System.Xml.Serialization;

namespace Capstone.Classes
{
    public class UI
    {
        public const string MainMenu = "1. Display vending machine items \n2. Purchase \n3. Exit";
        public const string PurchaseMenu = "1. Feed Money \n2. Select Product \n3. Finish Transaction";
        public void Run()
        {
            Machine thisMachine = new Machine();
            thisMachine.ReadInventoryInput("vendingmachine.csv");
            string choice = DisplayMenu();
            if (choice == "1")
            {
                Console.WriteLine(thisMachine.DisplayVendingMachineItems("vendingmachine.csv"));
            }
            else if (choice == "2")
            {

            }
            else
            {
                // 
            }
        }

        public string DisplayMenu()
        {
            string choice = "";
            do
            {
                Console.WriteLine("Please select from the following:");
                Console.WriteLine(MainMenu);
                choice = Console.ReadLine();
            } while (choice != "1" && choice != "2" && choice != "3");
            return choice;
        }

        public void Purchase(Machine machine)
        {
            string purchaseChoice = "";
            Console.WriteLine($"Current money provided: {machine.CurrentMoneyProvided} \n {PurchaseMenu}");
            if (purchaseChoice == "1")
            {
                //do
                //{
                //    Console.WriteLine("Enter the amount of money you want to feed in in whole dollars");
                //    string moneyFed = Console.ReadLine();
                //    //    try
                //    //    {
                //    //        // check that amount is positive
                //    //        // check that it's in whole dollars
                //    //        // check that it's a number
                //    //    }
                //    //    decimal moneyFed = decimal.Parse(Console.ReadLine());
                //} while ( < 0.00M);
            }
            else if (purchaseChoice == "2")
            {
                // call ReadInventoryInput to print the menu of items
                // prompt to enter code
                // look for code
            }
            else
            {
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
                DisplayMenu();
            }
        }

}
}
