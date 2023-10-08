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
            string input1 = "A4|Cloud Popcorn|3.65|Chip \nB3|Wonka Bar|1.50|Candy \nC3|Mountain Melter|1.50|Drink \nD4|Triplemint|0.75|Gum";
            string input2 = "A1|Potato Crisps|3.05|Chip \nB4|Crunchie|1.75|Candy \nC4|Heavy|1.50|Drink \nD1|U-Chews|0.85|Gum";

            Dictionary<string, Item> expectedItemDict1 = new Dictionary<string, Item>();
            Dictionary<string, Item> expectedItemDict2 = new Dictionary<string, Item>();
            Dictionary<string, int> expectedInventoryDict1 = new Dictionary<string, int>();
            Dictionary<string, int> expectedInventoryDict2 = new Dictionary<string, int>();

            Chip chipExpected1 = new Chip("Cloud Popcorn", 3.65M);
            Candy candyExpected1 = new Candy("Wonka Bar", 1.50M);
            Drink drinkExpected1 = new Drink("Mountain Melter", 1.50M);
            Gum gumExpected1 = new Gum("Triplemint", 0.75M);

            Chip chipExpected2 = new Chip("Potato Crisps", 3.65M);
            Candy candyExpected2 = new Candy("Crunchie", 1.75M);
            Drink drinkExpected2 = new Drink("Heavy", 1.50M);
            Gum gumExpected2 = new Gum("U-Chews", 0.85M);

            expectedItemDict1["A4"] = chipExpected1;
            expectedItemDict1["B3"] = candyExpected1;
            expectedItemDict1["C3"] = drinkExpected1;
            expectedItemDict1["D4"] = gumExpected1;

            expectedItemDict2["A1"] = chipExpected2;
            expectedItemDict2["B4"] = candyExpected2;
            expectedItemDict2["C4"] = drinkExpected2;
            expectedItemDict2["D1"] = gumExpected2;

            expectedInventoryDict1["Cloud Popcorn"] = 5;
            expectedInventoryDict1["Wonka Bar"] = 5;
            expectedInventoryDict1["Mountain Melter"] = 5;
            expectedInventoryDict1["Triplemint"] = 5;

            expectedInventoryDict1["Potato Crisps"] = 5;
            expectedInventoryDict1["Crunchie"] = 5;
            expectedInventoryDict1["Heavy"] = 5;
            expectedInventoryDict1["U-Chews"] = 5;

            // Act
            sut.ReadInventoryInput(input1);
            sut.ReadInventoryInput(input2);

            // Assert
            CollectionAssert.AreEquivalent(expectedItemDict1, sut.VendingMachineItems);
            CollectionAssert.AreEquivalent(expectedItemDict2, sut.VendingMachineItems);
            CollectionAssert.AreEquivalent(expectedInventoryDict1, sut.Inventory);
            CollectionAssert.AreEquivalent(expectedInventoryDict2, sut.Inventory);
        }

        [TestMethod]

        public void ReadInventoryInputEmptyString()
        {
            // Arrange
            Machine sut = new Machine();
            string input1 = "";

            Dictionary<string, Item> expectedItemDict = new Dictionary<string, Item>();
            Dictionary<string, int> expectedInventoryDict = new Dictionary<string, int>();

            // Act
            sut.ReadInventoryInput(input1);

            // Assert
            CollectionAssert.AreEquivalent(expectedItemDict, sut.VendingMachineItems);
            CollectionAssert.AreEquivalent(expectedInventoryDict, sut.Inventory);
        }

        [TestMethod]

        public void ReadInventoryInputNull()
        {
            // Arrange
            Machine sut = new Machine();
            string input1 = null;

            Dictionary<string, Item> expectedItemDict = new Dictionary<string, Item>();
            Dictionary<string, int> expectedInventoryDict = new Dictionary<string, int>();

            // Act
            sut.ReadInventoryInput(input1);

            // Assert
            CollectionAssert.AreEquivalent(expectedItemDict, sut.VendingMachineItems);
            CollectionAssert.AreEquivalent(expectedInventoryDict, sut.Inventory);
        }

        [TestMethod]

        public void ReadInventoryInputOneItem()
        {
            Machine sut = new Machine();
            string input = "A3|Grain Waves|2.75|Chip";

            Dictionary<string, Item> expectedItemDict = new Dictionary<string, Item>();
            Dictionary<string, int> expectedInventoryDict = new Dictionary<string, int>();

            Chip chipExpected = new Chip("Grain Waves", 2.75M);

            expectedItemDict["A3"] = chipExpected;

            expectedInventoryDict["Grain Waves"] = 5;

            // Act
            sut.ReadInventoryInput(input);

            // Assert
            CollectionAssert.AreEquivalent(expectedItemDict, sut.VendingMachineItems);
            CollectionAssert.AreEquivalent(expectedItemDict, sut.VendingMachineItems);
        }

        [TestMethod]

        public void ReadInventoryInputZero()
        {
            // Arrange
            Machine sut = new Machine();
            string input1 = "A4|Cloud Popcorn|3.65|Chip \nB3|Wonka Bar|0.00|Candy \nC3|Mountain Melter|1.50|Drink \nD4|Triplemint|0.75|Gum";
            string input2 = "A1|Potato Crisps|3.05|Chip \nB4|Crunchie|1.75|Candy \nC4|Heavy|1.50|Drink \nD1|U-Chews|0.00|Gum";

            Dictionary<string, Item> expectedItemDict1 = new Dictionary<string, Item>();
            Dictionary<string, Item> expectedItemDict2 = new Dictionary<string, Item>();
            Dictionary<string, int> expectedInventoryDict1 = new Dictionary<string, int>();
            Dictionary<string, int> expectedInventoryDict2 = new Dictionary<string, int>();

            Chip chipExpected1 = new Chip("Cloud Popcorn", 3.65M);
            Candy candyExpected1 = new Candy("Wonka Bar", 0.00M);
            Drink drinkExpected1 = new Drink("Mountain Melter", 1.50M);
            Gum gumExpected1 = new Gum("Triplemint", 0.75M);

            Chip chipExpected2 = new Chip("Potato Crisps", 3.65M);
            Candy candyExpected2 = new Candy("Crunchie", 1.75M);
            Drink drinkExpected2 = new Drink("Heavy", 1.50M);
            Gum gumExpected2 = new Gum("U-Chews", 0.00M);

            expectedItemDict1["A4"] = chipExpected1;
            expectedItemDict1["B3"] = candyExpected1;
            expectedItemDict1["C3"] = drinkExpected1;
            expectedItemDict1["D4"] = gumExpected1;

            expectedItemDict2["A1"] = chipExpected2;
            expectedItemDict2["B4"] = candyExpected2;
            expectedItemDict2["C4"] = drinkExpected2;
            expectedItemDict2["D1"] = gumExpected2;

            expectedInventoryDict1["Cloud Popcorn"] = 5;
            expectedInventoryDict1["Wonka Bar"] = 5;
            expectedInventoryDict1["Mountain Melter"] = 5;
            expectedInventoryDict1["Triplemint"] = 5;

            expectedInventoryDict1["Potato Crisps"] = 5;
            expectedInventoryDict1["Crunchie"] = 5;
            expectedInventoryDict1["Heavy"] = 5;
            expectedInventoryDict1["U-Chews"] = 5;

            // Act
            sut.ReadInventoryInput(input1);
            sut.ReadInventoryInput(input2);

            // Assert
            CollectionAssert.AreEquivalent(expectedItemDict1, sut.VendingMachineItems);
            CollectionAssert.AreEquivalent(expectedItemDict2, sut.VendingMachineItems);
            CollectionAssert.AreEquivalent(expectedInventoryDict1, sut.Inventory);
            CollectionAssert.AreEquivalent(expectedInventoryDict2, sut.Inventory);
        }

        [TestMethod]

        public void ReadInventoryInputLarge()
        {
            // Arrange
            Machine sut = new Machine();
            string input = "A4|Cloud Popcorn|823.65|Chip \nB3|Wonka Bar|1000.00|Candy \nC3|Mountain Melter|181.50|Drink \nD4|Triplemint|5_000_230.75|Gum";

            Dictionary<string, Item> expectedItemDict = new Dictionary<string, Item>();
            Dictionary<string, int> expectedInventoryDict = new Dictionary<string, int>();

            Chip chipExpected = new Chip("Cloud Popcorn", 823.65M);
            Candy candyExpected = new Candy("Wonka Bar", 1000.00M);
            Drink drinkExpected = new Drink("Mountain Melter", 181.50M);
            Gum gumExpected = new Gum("Triplemint", 5_000_230.75M);

            expectedItemDict["A4"] = chipExpected;
            expectedItemDict["B3"] = candyExpected;
            expectedItemDict["C3"] = drinkExpected;
            expectedItemDict["D4"] = gumExpected;

            expectedInventoryDict["Cloud Popcorn"] = 5;
            expectedInventoryDict["Wonka Bar"] = 5;
            expectedInventoryDict["Mountain Melter"] = 5;
            expectedInventoryDict["Triplemint"] = 5;

            // Act
            sut.ReadInventoryInput(input);

            // Assert
            CollectionAssert.AreEquivalent(expectedItemDict, sut.VendingMachineItems);
            CollectionAssert.AreEquivalent(expectedInventoryDict, sut.Inventory);
        }

        [TestMethod]

        public void ReadInventoryInputExtraItem()
        {
            // Arrange
            Machine sut = new Machine();
            string input = "A4|Cloud Popcorn|3.65|Chip \nB3|Wonka Bar|1.50|Candy \nC3|Mountain Melter|1.50|Drink|DISCONTINUED \nD4|Triplemint|0.75|Gum";

            Dictionary<string, Item> expectedItemDict = new Dictionary<string, Item>();
            Dictionary<string, int> expectedInventoryDict = new Dictionary<string, int>();

            Chip chipExpected = new Chip("Cloud Popcorn", 3.65M);
            Candy candyExpected = new Candy("Wonka Bar", 1.50M);
            Gum gumExpected = new Gum("Triplemint", 0.75M);

            expectedItemDict["A4"] = chipExpected;
            expectedItemDict["B3"] = candyExpected;
            expectedItemDict["D4"] = gumExpected;

            expectedInventoryDict["Cloud Popcorn"] = 5;
            expectedInventoryDict["Wonka Bar"] = 5;
            expectedInventoryDict["Triplemint"] = 5;

            // Act
            sut.ReadInventoryInput(input);

            // Assert
            CollectionAssert.AreEquivalent(expectedItemDict, sut.VendingMachineItems);
            CollectionAssert.AreEquivalent(expectedInventoryDict, sut.Inventory);
        }

        [TestMethod]

        public void ReadInventoryInputMissingItem()
        {
            // Arrange
            Machine sut = new Machine();
            string input = "A4|Cloud Popcorn|3.65|Chip \nB3|Wonka Bar|1.50| \nC3|Mountain Melter|1.50|Drink \nD4|Triplemint|0.75|Gum";

            Dictionary<string, Item> expectedItemDict = new Dictionary<string, Item>();
            Dictionary<string, int> expectedInventoryDict = new Dictionary<string, int>();

            Chip chipExpected = new Chip("Cloud Popcorn", 3.65M);
            Drink drinkExpected = new Drink("Mountain Melter", 1.50M);
            Gum gumExpected = new Gum("Triplemint", 0.75M);

            expectedItemDict["A4"] = chipExpected;
            expectedItemDict["B3"] = drinkExpected;
            expectedItemDict["D4"] = gumExpected;

            expectedInventoryDict["Cloud Popcorn"] = 5;
            expectedInventoryDict["Wonka Bar"] = 5;
            expectedInventoryDict["Triplemint"] = 5;

            // Act
            sut.ReadInventoryInput(input);

            // Assert
            CollectionAssert.AreEquivalent(expectedItemDict, sut.VendingMachineItems);
            CollectionAssert.AreEquivalent(expectedInventoryDict, sut.Inventory);

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
