using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System.Security.Cryptography;
using System.Runtime.Intrinsics.X86;
using System.IO;

namespace CapstoneTests.Tests
{
    [TestClass]
    public class MachineTests
    {
        [TestMethod]

        public void ReadInventoryInputHappyPaths()
        {
            // Arrange
            Machine sut1 = new Machine();
            Machine sut2 = new Machine();
            //string input1 = "vendingmachine.csv";
            //string input2 = "happypaths.txt";
            string path = Environment.CurrentDirectory;
            string input1 = Path.Combine(path, "classes\\managable.txt");
            string input2 = "classes\\manageable.txt";

            Dictionary<string, Item> expectedItemDict1 = new Dictionary<string, Item>();
            Dictionary<string, Item> expectedItemDict2 = new Dictionary<string, Item>();
            Dictionary<string, int> expectedInventoryDict1 = new Dictionary<string, int>();
            Dictionary<string, int> expectedInventoryDict2 = new Dictionary<string, int>();

            //            D2 | Little League Chew| 0.95 | Gum
            Gum expectedGum = new Gum("Little League Chew", 0.95M);
            expectedItemDict1["D2"] = expectedGum;
            expectedInventoryDict1["Little League Chew"] = 5;
            //A4 | Cloud Popcorn | 3.65 | Chip
            Chip expectedChip1 = new Chip("Cloud Popcorn", 3.65M);
            expectedItemDict1["A4"] = expectedChip1;
            expectedInventoryDict1["Cloud Popcorn"] = 5;
            //            A1 | Potato Crisps | 3.05 | Chip
            Chip expectedChip2 = new Chip("Potato Crisps", 3.05M);
            expectedItemDict2["A1"] = expectedChip2;
            expectedInventoryDict2["Potato Crisps"] = 5;
            //B2 | Cowtales | 1.50 | Candy
            Candy expectedCandy = new Candy("Cowtales", 1.50M);
            expectedItemDict2["B2"] = expectedCandy;
            expectedInventoryDict2["Cowtales"] = 5;

            //// Act
            sut1.ReadInventoryInput(input1);
            sut2.ReadInventoryInput(input2);

            //// Assert
            Assert.AreEqual(expectedItemDict1["D2"].Name, sut1.VendingMachineItems["D2"].Name);
            Assert.AreEqual(expectedItemDict1["D2"].Price, sut1.VendingMachineItems["D2"].Price);
            Assert.AreEqual(expectedItemDict1["A4"].Name, sut1.VendingMachineItems["A4"].Name);
            Assert.AreEqual(expectedItemDict1["A4"].Price, sut1.VendingMachineItems["A4"].Price);
            Assert.AreEqual(expectedItemDict2["A1"].Name, sut2.VendingMachineItems["A1"].Name);
            Assert.AreEqual(expectedItemDict2["A1"].Price, sut2.VendingMachineItems["A1"].Price);
            Assert.AreEqual(expectedItemDict2["B2"].Name, sut2.VendingMachineItems["B2"].Name);
            Assert.AreEqual(expectedItemDict2["B2"].Price, sut2.VendingMachineItems["B2"].Price);
            Assert.AreEqual(expectedInventoryDict1["Little League Chew"], sut1.Inventory["Little League Chew"]);
            Assert.AreEqual(expectedInventoryDict1["Cloud Popcorn"], sut1.Inventory["Cloud Popcorn"]);
            Assert.AreEqual(expectedInventoryDict2["Potato Crisps"], sut2.Inventory["Potato Crisps"]);
            Assert.AreEqual(expectedInventoryDict2["Cowtales"], sut2.Inventory["Cowtales"]);
        }

        [TestMethod]

        public void ReadInventoryInputEmptyFile()
        {
            // Arrange
            Machine sut = new Machine();
            string input1 = "emptyfile.txt";

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
            //string path = Environment.CurrentDirectory;
            string input = "oneitem.txt";

            Dictionary<string, Item> expectedItemDict = new Dictionary<string, Item>();
            Dictionary<string, int> expectedInventoryDict = new Dictionary<string, int>();

            Chip chipExpected = new Chip("Grain Waves", 2.75M);

            expectedItemDict["A3"] = chipExpected;

            expectedInventoryDict["Grain Waves"] = 5;

            // Act
            sut.ReadInventoryInput(input);

            // Assert
            Assert.AreEqual(expectedItemDict["A3"].Name, sut.VendingMachineItems["A3"].Name);
            Assert.AreEqual(expectedItemDict["A3"].Price, sut.VendingMachineItems["A3"].Price);
            Assert.AreEqual(expectedInventoryDict["Grain Waves"], sut.Inventory["Grain Waves"]);
        }

        //[TestMethod]

        //public void ReadInventoryInputZero()
        //{
        //    // Arrange
        //    Machine sut = new Machine();
        //    string input = "zerodollaritem.txt";

        //    Dictionary<string, Item> expectedItemDict = new Dictionary<string, Item>();
        //    Dictionary<string, int> expectedInventoryDict = new Dictionary<string, int>();

        //    Chip chipExpected = new Chip("Cloud Popcorn", 3.65M);
        //    Candy candyExpected = new Candy("Wonka Bar", 0.00M);

        //    expectedItemDict1["A4"] = chipExpected1;
        //    expectedItemDict1["B3"] = candyExpected1;

        //    expectedItemDict2["A1"] = chipExpected2;
        //    expectedItemDict2["B4"] = candyExpected2;
        //    expectedItemDict2["C4"] = drinkExpected2;
        //    expectedItemDict2["D1"] = gumExpected2;

        //    expectedInventoryDict1["Cloud Popcorn"] = 5;
        //    expectedInventoryDict1["Wonka Bar"] = 5;
        //    expectedInventoryDict1["Mountain Melter"] = 5;
        //    expectedInventoryDict1["Triplemint"] = 5;

        //    expectedInventoryDict1["Potato Crisps"] = 5;
        //    expectedInventoryDict1["Crunchie"] = 5;
        //    expectedInventoryDict1["Heavy"] = 5;
        //    expectedInventoryDict1["U-Chews"] = 5;

        //    // Act
        //    sut.ReadInventoryInput(input1);
        //    sut.ReadInventoryInput(input2);

        //    // Assert
        //    CollectionAssert.AreEquivalent(expectedItemDict1, sut.VendingMachineItems);
        //    CollectionAssert.AreEquivalent(expectedItemDict2, sut.VendingMachineItems);
        //    CollectionAssert.AreEquivalent(expectedInventoryDict1, sut.Inventory);
        //    CollectionAssert.AreEquivalent(expectedInventoryDict2, sut.Inventory);
        //}

        //[TestMethod]

        //public void ReadInventoryInputLarge()
        //{
        //    // Arrange
        //    Machine sut = new Machine();
        //    string input = "A4|Cloud Popcorn|823.65|Chip \nB3|Wonka Bar|1000.00|Candy \nC3|Mountain Melter|181.50|Drink \nD4|Triplemint|5_000_230.75|Gum";

        //    Dictionary<string, Item> expectedItemDict = new Dictionary<string, Item>();
        //    Dictionary<string, int> expectedInventoryDict = new Dictionary<string, int>();

        //    Chip chipExpected = new Chip("Cloud Popcorn", 823.65M);
        //    Candy candyExpected = new Candy("Wonka Bar", 1000.00M);
        //    Drink drinkExpected = new Drink("Mountain Melter", 181.50M);
        //    Gum gumExpected = new Gum("Triplemint", 5_000_230.75M);

        //    expectedItemDict["A4"] = chipExpected;
        //    expectedItemDict["B3"] = candyExpected;
        //    expectedItemDict["C3"] = drinkExpected;
        //    expectedItemDict["D4"] = gumExpected;

        //    expectedInventoryDict["Cloud Popcorn"] = 5;
        //    expectedInventoryDict["Wonka Bar"] = 5;
        //    expectedInventoryDict["Mountain Melter"] = 5;
        //    expectedInventoryDict["Triplemint"] = 5;

        //    // Act
        //    sut.ReadInventoryInput(input);

        //    // Assert
        //    CollectionAssert.AreEquivalent(expectedItemDict, sut.VendingMachineItems);
        //    CollectionAssert.AreEquivalent(expectedInventoryDict, sut.Inventory);
        //}

        //[TestMethod]

        //public void ReadInventoryInputExtraItem()
        //{
        //    // Arrange
        //    Machine sut = new Machine();
        //    string input = "A4|Cloud Popcorn|3.65|Chip \nB3|Wonka Bar|1.50|Candy \nC3|Mountain Melter|1.50|Drink|DISCONTINUED \nD4|Triplemint|0.75|Gum";

        //    Dictionary<string, Item> expectedItemDict = new Dictionary<string, Item>();
        //    Dictionary<string, int> expectedInventoryDict = new Dictionary<string, int>();

        //    Chip chipExpected = new Chip("Cloud Popcorn", 3.65M);
        //    Candy candyExpected = new Candy("Wonka Bar", 1.50M);
        //    Gum gumExpected = new Gum("Triplemint", 0.75M);

        //    expectedItemDict["A4"] = chipExpected;
        //    expectedItemDict["B3"] = candyExpected;
        //    expectedItemDict["D4"] = gumExpected;

        //    expectedInventoryDict["Cloud Popcorn"] = 5;
        //    expectedInventoryDict["Wonka Bar"] = 5;
        //    expectedInventoryDict["Triplemint"] = 5;

        //    // Act
        //    sut.ReadInventoryInput(input);

        //    // Assert
        //    CollectionAssert.AreEquivalent(expectedItemDict, sut.VendingMachineItems);
        //    CollectionAssert.AreEquivalent(expectedInventoryDict, sut.Inventory);
        //}

        //[TestMethod]

        //public void ReadInventoryInputMissingItem()
        //{
        //    // Arrange
        //    Machine sut = new Machine();
        //    string input = "A4|Cloud Popcorn|3.65|Chip \nB3|Wonka Bar|1.50| \nC3|Mountain Melter|1.50|Drink \nD4|Triplemint|0.75|Gum";

        //    Dictionary<string, Item> expectedItemDict = new Dictionary<string, Item>();
        //    Dictionary<string, int> expectedInventoryDict = new Dictionary<string, int>();

        //    Chip chipExpected = new Chip("Cloud Popcorn", 3.65M);
        //    Drink drinkExpected = new Drink("Mountain Melter", 1.50M);
        //    Gum gumExpected = new Gum("Triplemint", 0.75M);

        //    expectedItemDict["A4"] = chipExpected;
        //    expectedItemDict["C3"] = drinkExpected;
        //    expectedItemDict["D4"] = gumExpected;

        //    expectedInventoryDict["Cloud Popcorn"] = 5;
        //    expectedInventoryDict["Wonka Bar"] = 5;
        //    expectedInventoryDict["Triplemint"] = 5;

        //    // Act
        //    sut.ReadInventoryInput(input);

        //    // Assert
        //    CollectionAssert.AreEquivalent(expectedItemDict, sut.VendingMachineItems);
        //    CollectionAssert.AreEquivalent(expectedInventoryDict, sut.Inventory);
        //}

        //[TestMethod]

        //public void ReadInventoryInputNegativeValue()
        //{
        //    Machine sut = new Machine();
        //    string input = "A4|Cloud Popcorn|3.65|Chip \nB3|Wonka Bar|1.50|Candy \nC3|Mountain Melter|-1.50|Drink \nD4|Triplemint|0.75|Gum";

        //    Dictionary<string, Item> expectedItemDict = new Dictionary<string, Item>();
        //    Dictionary<string, int> expectedInventoryDict = new Dictionary<string, int>();

        //    Chip chipExpected = new Chip("Cloud Popcorn", 3.65M);
        //    Candy candyExpected = new Candy("Wonka Bar", 1.50M);
        //    Gum gumExpected = new Gum("Triplemint", 0.75M);

        //    expectedItemDict["A4"] = chipExpected;
        //    expectedItemDict["B3"] = candyExpected;
        //    expectedItemDict["D4"] = gumExpected;

        //    expectedInventoryDict["Cloud Popcorn"] = 5;
        //    expectedInventoryDict["Wonka Bar"] = 5;
        //    expectedInventoryDict["Triplemint"] = 5;

        //    // Act
        //    sut.ReadInventoryInput(input);

        //    // Assert
        //    CollectionAssert.AreEquivalent(expectedItemDict, sut.VendingMachineItems);
        //    CollectionAssert.AreEquivalent(expectedInventoryDict, sut.Inventory);
        //}

        //[TestMethod]

        //public void ReadInventoryInputLowerCaseItemCode()
        //{
        //    // Arrange
        //    Machine sut = new Machine();
        //    string input1 = "a4|Cloud Popcorn|3.65|Chip \nb3|Wonka Bar|1.50|Candy \nc3|Mountain Melter|1.50|Drink \nd4|Triplemint|0.75|Gum";
        //    string input2 = "a1|Potato Crisps|3.05|Chip \nb4|Crunchie|1.75|Candy \nc4|Heavy|1.50|Drink \nd1|U-Chews|0.85|Gum";

        //    Dictionary<string, Item> expectedItemDict1 = new Dictionary<string, Item>();
        //    Dictionary<string, Item> expectedItemDict2 = new Dictionary<string, Item>();
        //    Dictionary<string, int> expectedInventoryDict1 = new Dictionary<string, int>();
        //    Dictionary<string, int> expectedInventoryDict2 = new Dictionary<string, int>();

        //    Chip chipExpected1 = new Chip("Cloud Popcorn", 3.65M);
        //    Candy candyExpected1 = new Candy("Wonka Bar", 1.50M);
        //    Drink drinkExpected1 = new Drink("Mountain Melter", 1.50M);
        //    Gum gumExpected1 = new Gum("Triplemint", 0.75M);

        //    Chip chipExpected2 = new Chip("Potato Crisps", 3.65M);
        //    Candy candyExpected2 = new Candy("Crunchie", 1.75M);
        //    Drink drinkExpected2 = new Drink("Heavy", 1.50M);
        //    Gum gumExpected2 = new Gum("U-Chews", 0.85M);

        //    expectedItemDict1["A4"] = chipExpected1;
        //    expectedItemDict1["B3"] = candyExpected1;
        //    expectedItemDict1["C3"] = drinkExpected1;
        //    expectedItemDict1["D4"] = gumExpected1;

        //    expectedItemDict2["A1"] = chipExpected2;
        //    expectedItemDict2["B4"] = candyExpected2;
        //    expectedItemDict2["C4"] = drinkExpected2;
        //    expectedItemDict2["D1"] = gumExpected2;

        //    expectedInventoryDict1["Cloud Popcorn"] = 5;
        //    expectedInventoryDict1["Wonka Bar"] = 5;
        //    expectedInventoryDict1["Mountain Melter"] = 5;
        //    expectedInventoryDict1["Triplemint"] = 5;

        //    expectedInventoryDict1["Potato Crisps"] = 5;
        //    expectedInventoryDict1["Crunchie"] = 5;
        //    expectedInventoryDict1["Heavy"] = 5;
        //    expectedInventoryDict1["U-Chews"] = 5;

        //    // Act
        //    sut.ReadInventoryInput(input1);
        //    sut.ReadInventoryInput(input2);

        //    // Assert
        //    CollectionAssert.AreEquivalent(expectedItemDict1, sut.VendingMachineItems);
        //    CollectionAssert.AreEquivalent(expectedItemDict2, sut.VendingMachineItems);
        //    CollectionAssert.AreEquivalent(expectedInventoryDict1, sut.Inventory);
        //    CollectionAssert.AreEquivalent(expectedInventoryDict2, sut.Inventory);

        //}

        [TestMethod]

        public void AddToDictionaryHappyPaths()
        {
            // Arrange
            Machine sut = new Machine();
            string[] input1 = { "A1", "Potato Crisps", "3.05", "Chip" };
            string[] input2 = { "B4", "Crunchy", "1.75", "Candy" };
            string[] input3 = { "C1", "Cola", "1.25", "Drink" };
            string[] input4 = { "D4", "Triplemint", "0.75", "Gum" };

            Dictionary<string, Item> expectedItemDict = new Dictionary<string, Item>();
            Dictionary<string, int> expectedInventoryDict = new Dictionary<string, int>();

            Chip chipExpected = new Chip("Potato Crisps", 3.05M);
            Candy candyExpected = new Candy("Crunchy", 1.75M);
            Drink drinkExpected = new Drink("Cola", 1.25M);
            Gum gumExpected = new Gum("Triplemint", 0.75M);

            expectedItemDict["A1"] = chipExpected;
            expectedItemDict["B4"] = candyExpected;
            expectedItemDict["C1"] = drinkExpected;
            expectedItemDict["D4"] = gumExpected;

            expectedInventoryDict["Potato Crisps"] = 5;
            expectedInventoryDict["Crunchy"] = 5;
            expectedInventoryDict["Cola"] = 5;
            expectedInventoryDict["Triplemint"] = 5;

            // Act
            sut.AddToDictionary(input1);
            sut.AddToDictionary(input2);
            sut.AddToDictionary(input3);
            sut.AddToDictionary(input4);

            // Assert
            Assert.AreEqual(expectedItemDict["A1"].Name, sut.VendingMachineItems["A1"].Name);
            Assert.AreEqual(expectedItemDict["B4"].Name, sut.VendingMachineItems["B4"].Name);
            Assert.AreEqual(expectedItemDict["C1"].Name, sut.VendingMachineItems["C1"].Name);
            Assert.AreEqual(expectedItemDict["D4"].Name, sut.VendingMachineItems["D4"].Name);
            CollectionAssert.AreEquivalent(expectedInventoryDict, sut.Inventory);
        }

        [TestMethod]

        public void AddToDictionaryEmptyArray()
        {
            // Arrange
            Machine sut = new Machine();
            string[] input1 = { "A1", "Potato Crisps", "3.05", "Chip" };
            string[] input2 = { };
            string[] input3 = { "C1", "Cola", "1.25", "Drink" };
            string[] input4 = { "D4", "Triplemint", "0.75", "Gum" };

            Dictionary<string, Item> expectedItemDict = new Dictionary<string, Item>();
            Dictionary<string, int> expectedInventoryDict = new Dictionary<string, int>();

            Chip chipExpected = new Chip("Potato Crisps", 3.05M);
            Drink drinkExpected = new Drink("Cola", 1.25M);
            Gum gumExpected = new Gum("Triplemint", 0.75M);

            expectedItemDict["A1"] = chipExpected;
            expectedItemDict["C1"] = drinkExpected;
            expectedItemDict["D4"] = gumExpected;

            expectedInventoryDict["Potato Crisps"] = 5;
            expectedInventoryDict["Cola"] = 5;
            expectedInventoryDict["Triplemint"] = 5;

            // Act
            sut.AddToDictionary(input1);
            sut.AddToDictionary(input2);
            sut.AddToDictionary(input3);
            sut.AddToDictionary(input4);

            // Assert
            Assert.AreEqual(expectedItemDict["A1"].Name, sut.VendingMachineItems["A1"].Name);
            Assert.AreEqual(expectedItemDict["C1"].Name, sut.VendingMachineItems["C1"].Name);
            Assert.AreEqual(expectedItemDict["D4"].Name, sut.VendingMachineItems["D4"].Name);
            CollectionAssert.AreEquivalent(expectedInventoryDict, sut.Inventory);
        }

        [TestMethod]

        public void AddToDictionaryOneItem()
        {
            // Arrange
            Machine sut = new Machine();
            string[] input = { "A1", "Potato Crisps", "3.05", "Chip" };

            Dictionary<string, Item> expectedItemDict = new Dictionary<string, Item>();
            Dictionary<string, int> expectedInventoryDict = new Dictionary<string, int>();

            Chip chipExpected = new Chip("Potato Crisps", 3.05M);

            expectedItemDict["A1"] = chipExpected;

            expectedInventoryDict["Potato Crisps"] = 5;

            // Act
            sut.AddToDictionary(input);

            // Assert
            CollectionAssert.AreEquivalent(expectedItemDict, sut.VendingMachineItems);
            CollectionAssert.AreEquivalent(expectedInventoryDict, sut.Inventory);
        }

        [TestMethod]

        public void AddToDictionaryNullArray()
        {
            // Arrange
            Machine sut = new Machine();
            string[] input1 = null;
            string[] input2 = { "B4", "Crunchy", "1.75", "Candy" };
            string[] input3 = { "C1", "Cola", "1.25", "Drink" };
            string[] input4 = { "D4", "Triplemint", "0.75", "Gum" };

            Dictionary<string, Item> expectedItemDict = new Dictionary<string, Item>();
            Dictionary<string, int> expectedInventoryDict = new Dictionary<string, int>();

            Candy candyExpected = new Candy("Crunchy", 1.75M);
            Drink drinkExpected = new Drink("Cola", 1.25M);
            Gum gumExpected = new Gum("Triplemint", 0.75M);

            expectedItemDict["B4"] = candyExpected;
            expectedItemDict["C1"] = drinkExpected;
            expectedItemDict["D4"] = gumExpected;

            expectedInventoryDict["Crunchy"] = 5;
            expectedInventoryDict["Cola"] = 5;
            expectedInventoryDict["Triplemint"] = 5;

            // Act
            sut.AddToDictionary(input1);
            sut.AddToDictionary(input2);
            sut.AddToDictionary(input3);
            sut.AddToDictionary(input4);

            // Assert
            Assert.AreEqual(expectedItemDict["A1"].Name, sut.VendingMachineItems["A1"].Name);
            CollectionAssert.AreEquivalent(expectedInventoryDict, sut.Inventory);
        }

        [TestMethod]

        public void AddToDictionaryExtraItem()
        {
            // Arrange
            Machine sut = new Machine();
            string[] input1 = { "A1", "Potato Crisps", "3.05", "Chip", "SOLD OUT" };
            string[] input2 = { "B4", "Crunchy", "1.75", "Candy" };
            string[] input3 = { "C1", "Cola", "1.25", "Drink" };
            string[] input4 = { "D4", "Triplemint", "0.75", "Gum" };

            Dictionary<string, Item> expectedItemDict = new Dictionary<string, Item>();
            Dictionary<string, int> expectedInventoryDict = new Dictionary<string, int>();

            Candy candyExpected = new Candy("Crunchy", 1.75M);
            Drink drinkExpected = new Drink("Cola", 1.25M);
            Gum gumExpected = new Gum("Triplemint", 0.75M);

            expectedItemDict["B4"] = candyExpected;
            expectedItemDict["C1"] = drinkExpected;
            expectedItemDict["D4"] = gumExpected;

            expectedInventoryDict["Crunchy"] = 5;
            expectedInventoryDict["Cola"] = 5;
            expectedInventoryDict["Triplemint"] = 5;

            // Act
            sut.AddToDictionary(input1);
            sut.AddToDictionary(input2);
            sut.AddToDictionary(input3);
            sut.AddToDictionary(input4);

            // Assert
            Assert.AreEqual(expectedItemDict["B4"].Name, sut.VendingMachineItems["B4"].Name);
            Assert.AreEqual(expectedItemDict["C1"].Name, sut.VendingMachineItems["C1"].Name);
            Assert.AreEqual(expectedItemDict["D4"].Name, sut.VendingMachineItems["D4"].Name);
            CollectionAssert.AreEquivalent(expectedInventoryDict, sut.Inventory);
        }

        [TestMethod]

        public void AddToDictionaryMissingItem()
        {
            // Arrange
            Machine sut = new Machine();
            string[] input1 = { "A1", "Potato Crisps", "3.05", "Chip" };
            string[] input2 = { "B4", "Crunchy", "1.75", "Candy" };
            string[] input3 = { "C1", "Cola", "1.25", "Drink" };
            string[] input4 = { "Triplemint", "0.75", "Gum" };

            Dictionary<string, Item> expectedItemDict = new Dictionary<string, Item>();
            Dictionary<string, int> expectedInventoryDict = new Dictionary<string, int>();

            Chip chipExpected = new Chip("Potato Crisps", 3.05M);
            Candy candyExpected = new Candy("Crunchy", 1.75M);
            Drink drinkExpected = new Drink("Cola", 1.25M);

            expectedItemDict["A1"] = chipExpected;
            expectedItemDict["B4"] = candyExpected;
            expectedItemDict["C1"] = drinkExpected;

            expectedInventoryDict["Potato Crisps"] = 5;
            expectedInventoryDict["Crunchy"] = 5;
            expectedInventoryDict["Cola"] = 5;

            // Act
            sut.AddToDictionary(input1);
            sut.AddToDictionary(input2);
            sut.AddToDictionary(input3);
            sut.AddToDictionary(input4);

            // Assert
            Assert.AreEqual(expectedItemDict["A1"].Name, sut.VendingMachineItems["A1"].Name);
            Assert.AreEqual(expectedItemDict["B4"].Name, sut.VendingMachineItems["B4"].Name);
            Assert.AreEqual(expectedItemDict["C1"].Name, sut.VendingMachineItems["C1"].Name);
            CollectionAssert.AreEquivalent(expectedInventoryDict, sut.Inventory);
        }

        [TestMethod]

        public void AddToDictionaryEmptyString()
        {
            // Arrange
            Machine sut = new Machine();
            string[] input1 = { "A1", "Potato Crisps", "", "Chip" };
            string[] input2 = { "B4", "Crunchy", "1.75", "Candy" };
            string[] input3 = { "C1", "Cola", "1.25", "Drink" };
            string[] input4 = { "D4", "Triplemint", "0.75", "Gum" };

            Dictionary<string, Item> expectedItemDict = new Dictionary<string, Item>();
            Dictionary<string, int> expectedInventoryDict = new Dictionary<string, int>();

            Candy candyExpected = new Candy("Crunchy", 1.75M);
            Drink drinkExpected = new Drink("Cola", 1.25M);
            Gum gumExpected = new Gum("Triplemint", 0.75M);

            expectedItemDict["B4"] = candyExpected;
            expectedItemDict["C1"] = drinkExpected;
            expectedItemDict["D4"] = gumExpected;

            expectedInventoryDict["Crunchy"] = 5;
            expectedInventoryDict["Cola"] = 5;
            expectedInventoryDict["Triplemint"] = 5;

            // Act
            sut.AddToDictionary(input1);
            sut.AddToDictionary(input2);
            sut.AddToDictionary(input3);
            sut.AddToDictionary(input4);

            // Assert
            Assert.AreEqual(expectedItemDict["B4"].Name, sut.VendingMachineItems["B4"].Name);
            Assert.AreEqual(expectedItemDict["C1"].Name, sut.VendingMachineItems["C1"].Name);
            Assert.AreEqual(expectedItemDict["D4"].Name, sut.VendingMachineItems["D4"].Name);
            CollectionAssert.AreEquivalent(expectedInventoryDict, sut.Inventory);
        }

        [TestMethod]

        public void AddToDictionaryNullString()
        {
            // Arrange
            Machine sut = new Machine();
            string[] input1 = { "A1", "Potato Crisps", "3.05", "Chip" };
            string[] input2 = { "B4", "Crunchy", "1.75", "Candy" };
            string[] input3 = { "C1", "Cola", "1.25", "Drink" };
            string[] input4 = { null, "Triplemint", "0.75", "Gum" };

            Dictionary<string, Item> expectedItemDict = new Dictionary<string, Item>();
            Dictionary<string, int> expectedInventoryDict = new Dictionary<string, int>();

            Chip chipExpected = new Chip("Potato Crisps", 3.05M);
            Candy candyExpected = new Candy("Crunchy", 1.75M);
            Drink drinkExpected = new Drink("Cola", 1.25M);

            expectedItemDict["A1"] = chipExpected;
            expectedItemDict["B4"] = candyExpected;
            expectedItemDict["C1"] = drinkExpected;

            expectedInventoryDict["Potato Crisps"] = 5;
            expectedInventoryDict["Crunchy"] = 5;
            expectedInventoryDict["Cola"] = 5;

            // Act
            sut.AddToDictionary(input1);
            sut.AddToDictionary(input2);
            sut.AddToDictionary(input3);
            sut.AddToDictionary(input4);

            // Assert
            Assert.AreEqual(expectedItemDict["A1"].Name, sut.VendingMachineItems["A1"].Name);
            Assert.AreEqual(expectedItemDict["B4"].Name, sut.VendingMachineItems["B4"].Name);
            Assert.AreEqual(expectedItemDict["C1"].Name, sut.VendingMachineItems["C1"].Name);
            CollectionAssert.AreEquivalent(expectedInventoryDict, sut.Inventory);
        }

        [TestMethod]

        public void AddToDictionaryZeroValue()
        {
            Machine sut = new Machine();
            string[] input1 = { "A1", "Potato Crisps", "3.05", "Chip" };
            string[] input2 = { "B4", "Crunchy", "1.75", "Candy" };
            string[] input3 = { "C1", "Cola", "0.00", "Drink" };
            string[] input4 = { "D4", "Triplemint", "0.75", "Gum" };

            Dictionary<string, Item> expectedItemDict = new Dictionary<string, Item>();
            Dictionary<string, int> expectedInventoryDict = new Dictionary<string, int>();

            Chip chipExpected = new Chip("Potato Crisps", 3.05M);
            Candy candyExpected = new Candy("Crunchy", 1.75M);
            Drink drinkExpected = new Drink("Cola", 0.00M);
            Gum gumExpected = new Gum("Triplemint", 0.75M);

            expectedItemDict["A1"] = chipExpected;
            expectedItemDict["B4"] = candyExpected;
            expectedItemDict["C1"] = drinkExpected;
            expectedItemDict["D4"] = gumExpected;

            expectedInventoryDict["Potato Crisps"] = 5;
            expectedInventoryDict["Crunchy"] = 5;
            expectedInventoryDict["Cola"] = 5;
            expectedInventoryDict["Triplemint"] = 5;

            // Act
            sut.AddToDictionary(input1);
            sut.AddToDictionary(input2);
            sut.AddToDictionary(input3);
            sut.AddToDictionary(input4);
        }

        [TestMethod]

        public void AddToDictionaryNegativeValue()
        {
            // Arrange
            Machine sut = new Machine();
            string[] input1 = { "A1", "Potato Crisps", "3.05", "Chip" };
            string[] input2 = { "B4", "Crunchy", "1.75", "Candy" };
            string[] input3 = { "C1", "Cola", "-1.25", "Drink" };
            string[] input4 = { "D4", "Triplemint", "0.75", "Gum" };

            Dictionary<string, Item> expectedItemDict = new Dictionary<string, Item>();
            Dictionary<string, int> expectedInventoryDict = new Dictionary<string, int>();

            Chip chipExpected = new Chip("Potato Crisps", 3.05M);
            Candy candyExpected = new Candy("Crunchy", 1.75M);
            Gum gumExpected = new Gum("Triplemint", 0.75M);

            expectedItemDict["A1"] = chipExpected;
            expectedItemDict["B4"] = candyExpected;
            expectedItemDict["D4"] = gumExpected;

            expectedInventoryDict["Potato Crisps"] = 5;
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

        public void AddToDictionaryLargeValues()
        {
            // Arrange
            Machine sut = new Machine();
            string[] input1 = { "A1", "Potato Crisps", "2303.05", "Chip" };
            string[] input2 = { "B4", "Crunchy", "3_223_101.75", "Candy" };
            string[] input3 = { "C1", "Cola", "11.25", "Drink" };
            string[] input4 = { "D4", "Triplemint", "100.75", "Gum" };

            Dictionary<string, Item> expectedItemDict = new Dictionary<string, Item>();
            Dictionary<string, int> expectedInventoryDict = new Dictionary<string, int>();

            Chip chipExpected = new Chip("Potato Crisps", 2303.05M);
            Candy candyExpected = new Candy("Crunchy", 3_223_101.75M);
            Drink drinkExpected = new Drink("Cola", 11.25M);
            Gum gumExpected = new Gum("Triplemint", 100.75M);

            expectedItemDict["A1"] = chipExpected;
            expectedItemDict["B4"] = candyExpected;
            expectedItemDict["C1"] = drinkExpected;
            expectedItemDict["D4"] = gumExpected;

            expectedInventoryDict["Potato Crisps"] = 5;
            expectedInventoryDict["Crunchy"] = 5;
            expectedInventoryDict["Cola"] = 5;
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

        public void AddToDictionaryLowercaseItemCode()
        {
            // Arrange
            Machine sut = new Machine();
            string[] input1 = { "a1", "Potato Crisps", "3.05", "Chip" };
            string[] input2 = { "b4", "Crunchy", "1.75", "Candy" };
            string[] input3 = { "c1", "Cola", "1.25", "Drink" };
            string[] input4 = { "d4", "Triplemint", "0.75", "Gum" };

            Dictionary<string, Item> expectedItemDict = new Dictionary<string, Item>();
            Dictionary<string, int> expectedInventoryDict = new Dictionary<string, int>();

            Chip chipExpected = new Chip("Potato Crisps", 3.05M);
            Candy candyExpected = new Candy("Crunchy", 1.75M);
            Drink drinkExpected = new Drink("Cola", 1.25M);
            Gum gumExpected = new Gum("Triplemint", 0.75M);

            expectedItemDict["A1"] = chipExpected;
            expectedItemDict["B4"] = candyExpected;
            expectedItemDict["C1"] = drinkExpected;
            expectedItemDict["D4"] = gumExpected;

            expectedInventoryDict["Potato Crisps"] = 5;
            expectedInventoryDict["Crunchy"] = 5;
            expectedInventoryDict["Cola"] = 5;
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

        public void DisplayVendingMachineItemsHappyPaths()
        {
            // Arrange
            Machine sut1 = new Machine();
            Machine sut2 = new Machine();
            string input1 = "managable.txt";
            string input2 = "manageable.txt";

            string expected1 = "D2|Little League Chew|0.95|Gum\r\nA4|Cloud Popcorn|3.65|Chip";
            string expected2 = "A1|Potato Crisps|3.05|Chip\r\nB2|Cowtales|1.50|Candy";

            Dictionary<string, int> expectedDict1 = new Dictionary<string, int>();
            Dictionary<string, int> expectedDict2 = new Dictionary<string, int>();

            Assert.AreEqual(expectedDict1["Little League Chew"], sut1.Inventory["Little League Chew"]);
            Assert.AreEqual(expectedDict1["Cloud Popcorn"], sut1.Inventory["Cloud Popcorn"]);
            Assert.AreEqual(expectedDict2["Potato Crisps"], sut2.Inventory["Potato Crisps"]);
            Assert.AreEqual(expectedDict2["Cowtales"], sut2.Inventory["Cowtales"]);

            // Act
            string actual1 = sut1.DisplayVendingMachineItems(input1);
            string actual2 = sut2.DisplayVendingMachineItems(input2);

            // Assert
            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
        }

        [TestMethod]

        public void DisplayVendingMachineItemsEmptyFile()
        {
            // Arrange
            Machine sut = new Machine();
            string input = "emtpyfile.txt";
            string expected = "";

            // Act
            string actual = sut.DisplayVendingMachineItems(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
