using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;


namespace CapstoneTests.Tests
{
    [TestClass]
    public class MachineTests
    {
        [TestMethod]

        public void ReadInventoryInputHappyPaths()
        {
            // Arrange
            Machine sut = new Machine();
            string inputFile = "A1|Potato Crisps|3.05|Chip\r\nA2|Stackers|1.45|Chip\r\nA3|Grain Waves|2.75|Chip\r\nA4|Cloud Popcorn|3.65|Chip\r\nB1|Moonpie|1.80|Candy\r\nB2|Cowtales|1.50|Candy\r\nB3|Wonka Bar|1.50|Candy\r\nB4|Crunchie|1.75|Candy\r\nC1|Cola|1.25|Drink\r\nC2|Dr. Salt|1.50|Drink\r\nC3|Mountain Melter|1.50|Drink\r\nC4|Heavy|1.50|Drink\r\nD1|U-Chews|0.85|Gum\r\nD2|Little League Chew|0.95|Gum\r\nD3|Chiclets|0.75|Gum\r\nD4|Triplemint|0.75|Gum\r\n";
            Dictionary<string, Item> expected vendingMachineDict = { };

        }

        [TestMethod]

        public void AddToDictionaryHappyPaths()
        {

            // Arrange
            Machine sut = new Machine();
            string[] input1 = { "A1", "Potato Crisps", "3.05", "Chip" };
            string[] input2 = { "C1", "Cola", "1.25", "Drink" };
            string[] input3 = { "B4", "Crunchy", "1.75", "Candy" };
            string[] input4 = { "D4", "Triplemint", "0.75", "Gum" };

            Dictionary<string, Item> expectedItemDict = new Dictionary<string, Item>();
            Dictionary<string, int> expectedInventoryDict = new Dictionary<string, int>();

            Chip chipExpected = new Chip("Potato Crisps", 3.05M);
            Drink drinkExpected = new Drink("Cola", 1.25M);
            Candy candyExpected = new Candy("Crunchy", 1.75M);
            Gum gumExpected = new Gum("Triplemint", 0.75M);

            expectedItemDict["A1"] = chipExpected;
            expectedItemDict["C1"] = drinkExpected;
            expectedItemDict["B4"] = candyExpected;
            expectedItemDict["D4"] = gumExpected;

            expectedInventoryDict["Potato Crisps"] = 5;
            expectedInventoryDict["Cola"] = 5;
            expectedInventoryDict["Crunchy"] = 5;
            expectedInventoryDict["Triplemint"] = 5;

            // Act
            sut.AddToDictionary(input1);
            sut.AddToDictionary(input2);
            sut.AddToDictionary(input3);
            sut.AddToDictionary(input4);

            // Assert
            CollectionAssert.AreEquivalent(expectedItemDict, sut.VendingMachineItems);
            CollectionAssert.AreEquivalent(expectedInventoryDict, sut.Inventory);
        }

        [TestMethod]

        public void AddToDictionaryEmptyArray()
        {
            // Arrange
            Machine sut = new Machine();
            string[] input1 = { "A1", "Potato Crisps", "3.05", "Chip" };
            string[] input2 = {  };
            string[] input3 = { "B4", "Crunchy", "1.75", "Candy" };
            string[] input4 = { "D4", "Triplemint", "0.75", "Gum" };

            Dictionary<string, Item> expectedItemDict = new Dictionary<string, Item>();
            Dictionary<string, int> expectedInventoryDict = new Dictionary<string, int>();

            Chip chipExpected = new Chip("Potato Crisps", 3.05M);
            Drink drinkExpected = new Drink("Cola", 1.25M);
            Candy candyExpected = new Candy("Crunchy", 1.75M);
            Gum gumExpected = new Gum("Triplemint", 0.75M);

            expectedItemDict["A1"] = chipExpected;
            expectedItemDict["C1"] = drinkExpected;
            expectedItemDict["B4"] = candyExpected;
            expectedItemDict["D4"] = gumExpected;

            expectedInventoryDict["Potato Crisps"] = 5;
            expectedInventoryDict["Cola"] = 5;
            expectedInventoryDict["Crunchy"] = 5;
            expectedInventoryDict["Triplemint"] = 5;

            // Act
            sut.AddToDictionary(input1);
            sut.AddToDictionary(input2);
            sut.AddToDictionary(input3);
            sut.AddToDictionary(input4);

            // Assert
            CollectionAssert.AreEquivalent(expectedItemDict, sut.VendingMachineItems);
            CollectionAssert.AreEquivalent(expectedInventoryDict, sut.Inventory);

        }
    }
}
