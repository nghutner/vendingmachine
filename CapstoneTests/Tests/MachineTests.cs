using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System.Security.Cryptography;
using System.Runtime.Intrinsics.X86;


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
            string input1 = "vendingmachine.csv";
            string input2 = "happypaths.txt";

            Dictionary<string, Item> expectedItemDict1 = new Dictionary<string, Item>();
            Dictionary<string, Item> expectedItemDict2 = new Dictionary<string, Item>();
            Dictionary<string, int> expectedInventoryDict1 = new Dictionary<string, int>();
            Dictionary<string, int> expectedInventoryDict2 = new Dictionary<string, int>();

            //            A1 | Potato Crisps | 3.05 | Chip
            Chip expectedChip1 = new Chip("Potato Crisps", 3.05M);
            expectedItemDict1["A1"] = expectedChip1;
            expectedInventoryDict1["Potato Crisps"] = 5;
            //A2 | Stackers | 1.45 | Chip
            Chip expectedChip2 = new Chip("Stackers", 1.45M);
            expectedItemDict1["A2"] = expectedChip2;
            expectedInventoryDict1["Stackers"] = 5;
            //A3 | Grain Waves | 2.75 | Chip
            Chip expectedChip3 = new Chip("Grain Waves", 2.75M);
            expectedItemDict1["A3"] = expectedChip3;
            expectedInventoryDict1["Grain Waves"] = 5;
            //A4 | Cloud Popcorn | 3.65 | Chip
            Chip expectedChip4 = new Chip("Cloud Popcorn", 3.65M);
            expectedItemDict1["A4"] = expectedChip4;
            expectedInventoryDict1["Cloud Popcorn"] = 5;
            //B1 | Moonpie | 1.80 | Candy
            Candy expectedCandy1 = new Candy("Moonpie", 1.80M);
            expectedItemDict1["B1"] = expectedCandy1;
            expectedInventoryDict1["Moonpie"] = 5;
            //B2 | Cowtales | 1.50 | Candy
            Candy expectedCandy2 = new Candy("Cowtales", 1.50M);
            expectedItemDict1["B2"] = expectedCandy2;
            expectedInventoryDict1["Cowtales"] = 5;
            //B3 | Wonka Bar | 1.50 | Candy
            Candy expectedCandy3 = new Candy("Wonka Bar", 1.50M);
            expectedItemDict1["B3"] = expectedCandy3;
            expectedInventoryDict1["Wonka Bar"] = 5;
            //B4 | Crunchie | 1.75 | Candy
            Candy expectedCandy4 = new Candy("Crunchie", 1.75M);
            expectedItemDict1["B4"] = expectedCandy4;
            expectedInventoryDict1["Crunchie"] = 5;
            //C1 | Cola | 1.25 | Drink
            Drink expectedDrink1 = new Drink("Cola", 1.25M);
            expectedItemDict1["C1"] = expectedDrink1;
            expectedInventoryDict1["Cola"] = 5;
            //C2 | Dr.Salt | 1.50 | Drink
            Drink expectedDrink2 = new Drink("Dr. Salt", 1.50M);
            expectedItemDict1["C2"] = expectedDrink2;
            expectedInventoryDict1["Dr. Salt"] = 5;
            //C3 | Mountain Melter | 1.50 | Drink
            Drink expectedDrink3 = new Drink("Mountain Melter", 1.50M);
            expectedItemDict1["C3"] = expectedDrink3;
            expectedInventoryDict1["Mountain Melter"] = 5;
            //C4 | Heavy | 1.50 | Drink
            Drink expectedDrink4 = new Drink("Heavy", 1.50M);
            expectedItemDict1["C4"] = expectedDrink4;
            expectedInventoryDict1["Heavy"] = 5;
            //D1 | U - Chews | 0.85 | Gum
            Gum expectedGum1 = new Gum("U-Chews", 0.85M);
            expectedItemDict1["D1"] = expectedGum1;
            expectedInventoryDict1["U-Chews"] = 5;
            //D2 | Little League Chew| 0.95 | Gum
            Gum expectedGum2 = new Gum("Little League Chew", 0.95M);
            expectedItemDict1["D2"] = expectedGum2;
            expectedInventoryDict1["Little League Chew"] = 5;
            //D3 | Chiclets | 0.75 | Gum
            Gum expectedGum3 = new Gum("Chiclets", 0.75M);
            expectedItemDict1["D3"] = expectedGum3;
            expectedInventoryDict1["Chiclets"] = 5;
            //D4 | Triplemint | 0.75 | Gum
            Gum expectedGum4 = new Gum("Triplemint", 0.75M);
            expectedItemDict1["D4"] = expectedGum4;
            expectedInventoryDict1["Triplemint"] = 5;

            //            A1 | Pirates | 3.45 | Gum
            Gum ExpectedGumPirates = new Gum("Pirates", 3.45M);
            expectedItemDict2["A1"] = ExpectedGumPirates;
            expectedInventoryDict2["Pirates"] = 5;
            //A2 | Penguins | 1.30 | Gum
            Gum ExpectedGumPenguins = new Gum("Penguins", 1.30M);
            expectedItemDict2["A2"] = ExpectedGumPenguins;
            expectedInventoryDict2["Penguins"] = 5;
            //A3 | Steelers | 3.70 | Chip
            Chip ExpectedChipSteelers = new Chip("Steelers", 3.70M);
            expectedItemDict2["A3"] = ExpectedChipSteelers;
            expectedInventoryDict2["Steelers"] = 5;
            //A4 | Andy Warhol | 1.70 | Gum
            Gum ExpectedGumWarhol = new Gum("Andy Warhol", 1.70M);
            expectedItemDict2["A4"] = ExpectedGumWarhol;
            expectedInventoryDict2["Andy Warhol"] = 5;
            //B1 | Mac Miller | 1.10 | Candy
            Candy ExpectedCandyMiller = new Candy("Mac Miller", 1.10M);
            expectedItemDict2["B1"] = ExpectedCandyMiller;
            expectedInventoryDict2["Mac Miller"] = 5;
            //B2 | Wiz Khalifa | 3.15 | Candy
            Candy ExpectedCandyWiz = new Candy("Wiz Khalifa", 3.15M);
            expectedItemDict2["B2"] = ExpectedCandyWiz;
            expectedInventoryDict2["Wiz Khalifa"] = 5;
            //B3 | Gillian Jacobs | 1.20 | Chip
            Chip ExpectedChipGillian = new Chip("Gillian Jacobs", 1.20M);
            expectedItemDict2["B3"] = ExpectedChipGillian;
            expectedInventoryDict2["Chip"] = 5;
            //B4 | Mary Lou Williams| 2.85 | Gum
            Gum ExpectedGumMaryLou = new Gum("Mary Lou Williams", 2.85M);
            expectedItemDict2["B4"] = ExpectedGumMaryLou;
            expectedInventoryDict2["Mary Lou Williams"] = 5;
            //C1 | George Benson | 1.95 | Chip
            Chip ExpectedChipGeorge = new Chip("George Benson", 1.95M);
            expectedItemDict2["C1"] = ExpectedChipGeorge;
            expectedInventoryDict2["George Benson"] = 5;
            //C2 | Art Blakey | 2.10 | Drink
            Drink ExpectedDrinkBlakey = new Drink("Art Blakey", 2.10M);
            expectedItemDict2["C2"] = ExpectedDrinkBlakey;
            expectedInventoryDict2["Art Blakey"] = 5;
            //C3 | Ahmad Jamal | 2.85 | Candy
            Candy ExpectedCandyAhmad = new Candy("Ahmad Jamal", 2.85M);
            expectedItemDict2["C3"] = ExpectedCandyAhmad;
            expectedInventoryDict2["Ahmad Jamal"] = 5;
            //C4 | Billy Strayhorn | 2.85 | Candy
            Candy ExpectedCandyStrayhorn = new Candy("Billy Strayhorn", 2.85M);
            expectedItemDict2["C4"] = ExpectedCandyStrayhorn;
            expectedInventoryDict2["Billy Strayhorn"] = 5;
            //D1 | Roberto Clemente | 1.30 | Gum
            Gum ExpectedGumClemente = new Gum("Roberto Clemente", 1.30M);
            expectedItemDict2["D1"] = ExpectedGumClemente;
            expectedInventoryDict2["Roberto Clemente"] = 5;
            //D2 | Mario Lemieux | 1.70 | Drink
            Drink ExpectedDrinkMario = new Drink("Mario Lemieux", 1.70M);
            expectedItemDict2["D2"] = ExpectedDrinkMario;
            expectedInventoryDict2["Mario Lemieux"] = 5;
            //D3 | Steven Adams | 1.75 | Chip
            Chip ExpectedChipAdams = new Chip("Steven Adams", 1.75M);
            expectedItemDict2["D3"] = ExpectedChipAdams;
            expectedInventoryDict2["Steven Adams"] = 5;
            //D4 | Erroll Garner | 1.60 | Candy
            Candy ExpectedCandyGarner = new Candy("Erroll Garner", 1.60M);
            expectedItemDict2["D4"] = ExpectedCandyGarner;
            expectedInventoryDict2["Erroll Garner"] = 5;

            // Act
            sut1.ReadInventoryInput(input1);
            sut2.ReadInventoryInput(input2);

            // Assert
            Assert.AreEqual(expectedItemDict1["A1"].Name, sut1.VendingMachineItems["A1"].Name);
            Assert.AreEqual(expectedItemDict1["A1"].Price, sut1.VendingMachineItems["A1"].Price);
            Assert.AreEqual(expectedItemDict1["A2"].Name, sut1.VendingMachineItems["A2"].Name);
            Assert.AreEqual(expectedItemDict1["A2"].Price, sut1.VendingMachineItems["A2"].Price);
            Assert.AreEqual(expectedItemDict1["A3"].Name, sut1.VendingMachineItems["A3"].Name);
            Assert.AreEqual(expectedItemDict1["A3"].Price, sut1.VendingMachineItems["A3"].Price);
            Assert.AreEqual(expectedItemDict1["A4"].Name, sut1.VendingMachineItems["A4"].Name);
            Assert.AreEqual(expectedItemDict1["A4"].Price, sut1.VendingMachineItems["A4"].Price);
            Assert.AreEqual(expectedItemDict1["B1"].Name, sut1.VendingMachineItems["B1"].Name);
            Assert.AreEqual(expectedItemDict1["B1"].Price, sut1.VendingMachineItems["B1"].Price);
            Assert.AreEqual(expectedItemDict1["B2"].Name, sut1.VendingMachineItems["B2"].Name);
            Assert.AreEqual(expectedItemDict1["B2"].Price, sut1.VendingMachineItems["B2"].Price);
            Assert.AreEqual(expectedItemDict1["B3"].Name, sut1.VendingMachineItems["B3"].Name);
            Assert.AreEqual(expectedItemDict1["B3"].Price, sut1.VendingMachineItems["B3"].Price);
            Assert.AreEqual(expectedItemDict1["B4"].Name, sut1.VendingMachineItems["B4"].Name);
            Assert.AreEqual(expectedItemDict1["B4"].Price, sut1.VendingMachineItems["B4"].Price);
            Assert.AreEqual(expectedItemDict1["C1"].Name, sut1.VendingMachineItems["C1"].Name);
            Assert.AreEqual(expectedItemDict1["C1"].Price, sut1.VendingMachineItems["C1"].Price);
            Assert.AreEqual(expectedItemDict1["C2"].Name, sut1.VendingMachineItems["C2"].Name);
            Assert.AreEqual(expectedItemDict1["C2"].Price, sut1.VendingMachineItems["C2"].Price);
            Assert.AreEqual(expectedItemDict1["C3"].Name, sut1.VendingMachineItems["C3"].Name);
            Assert.AreEqual(expectedItemDict1["C3"].Price, sut1.VendingMachineItems["C3"].Price);
            Assert.AreEqual(expectedItemDict1["C4"].Name, sut1.VendingMachineItems["C4"].Name);
            Assert.AreEqual(expectedItemDict1["C4"].Price, sut1.VendingMachineItems["C4"].Price);
            Assert.AreEqual(expectedItemDict1["D1"].Name, sut1.VendingMachineItems["D1"].Name);
            Assert.AreEqual(expectedItemDict1["D1"].Price, sut1.VendingMachineItems["D1"].Price);
            Assert.AreEqual(expectedItemDict1["D2"].Name, sut1.VendingMachineItems["D2"].Name);
            Assert.AreEqual(expectedItemDict1["D2"].Price, sut1.VendingMachineItems["D2"].Price);
            Assert.AreEqual(expectedItemDict1["D3"].Name, sut1.VendingMachineItems["D3"].Name);
            Assert.AreEqual(expectedItemDict1["D3"].Price, sut1.VendingMachineItems["D3"].Price);
            Assert.AreEqual(expectedItemDict1["D4"].Name, sut1.VendingMachineItems["D4"].Name);
            Assert.AreEqual(expectedItemDict1["D4"].Price, sut1.VendingMachineItems["D4"].Price);

            //            A1 | Potato Crisps | 3.05 | Chip
            Assert.AreEqual(expectedInventoryDict1["Potato Crisps"], sut1.Inventory["Potato Crisps"]);
            //A2 | Stackers | 1.45 | Chip
            Assert.AreEqual(expectedInventoryDict1["Stackers"], sut1.Inventory["Stackers"]);
            //A3 | Grain Waves | 2.75 | Chip
            Assert.AreEqual(expectedInventoryDict1["Grain Waves"], sut1.Inventory["Grain Waves"]);
            //A4 | Cloud Popcorn | 3.65 | Chip
            Assert.AreEqual(expectedInventoryDict1["Cloud Popcorn"], sut1.Inventory["Cloud Popcorn"]);
            //B1 | Moonpie | 1.80 | Candy
            Assert.AreEqual(expectedInventoryDict1["Moonpie"], sut1.Inventory["Moonpie"]);
            //B2 | Cowtales | 1.50 | Candy
            Assert.AreEqual(expectedInventoryDict1["Cowtales"], sut1.Inventory["Cowtales"]);
            //B3 | Wonka Bar | 1.50 | Candy
            Assert.AreEqual(expectedInventoryDict1["Wonka Bar"], sut1.Inventory["Wonka Bar"]);
            //B4 | Crunchie | 1.75 | Candy
            Assert.AreEqual(expectedInventoryDict1["Crunchie"], sut1.Inventory["Crunchie"]);
            //C1 | Cola | 1.25 | Drink
            Assert.AreEqual(expectedInventoryDict1["Cola"], sut1.Inventory["Cola"]);
            //C2 | Dr.Salt | 1.50 | Drink
            Assert.AreEqual(expectedInventoryDict1["Dr. Salt"], sut1.Inventory["Dr. Salt"]);
            //C3 | Mountain Melter | 1.50 | Drink
            Assert.AreEqual(expectedInventoryDict1["Mountain Melter"], sut1.Inventory["Mountain Melter"]);
            //C4 | Heavy | 1.50 | Drink
            Assert.AreEqual(expectedInventoryDict1["Heavy"], sut1.Inventory["Heavy"]);
            //D1 | U - Chews | 0.85 | Gum
            Assert.AreEqual(expectedInventoryDict1["U-Chews"], sut1.Inventory["U-Chews"]);
            //D2 | Little League Chew| 0.95 | Gum
            Assert.AreEqual(expectedInventoryDict1["Little League Chew"], sut1.Inventory["Little League Chew"]);
            //D3 | Chiclets | 0.75 | Gum
            Assert.AreEqual(expectedInventoryDict1["Chiclets"], sut1.Inventory["Chiclets"]);
            //D4 | Triplemint | 0.75 | Gum

            Assert.AreEqual(expectedItemDict2["A1"].Name, sut2.VendingMachineItems["A1"].Name);
            Assert.AreEqual(expectedItemDict2["A1"].Price, sut2.VendingMachineItems["A1"].Price);
            Assert.AreEqual(expectedItemDict2["A2"].Name, sut2.VendingMachineItems["A2"].Name);
            Assert.AreEqual(expectedItemDict2["A2"].Price, sut2.VendingMachineItems["A2"].Price);
            Assert.AreEqual(expectedItemDict2["A3"].Name, sut2.VendingMachineItems["A3"].Name);
            Assert.AreEqual(expectedItemDict2["A3"].Price, sut2.VendingMachineItems["A3"].Price);
            Assert.AreEqual(expectedItemDict2["A4"].Name, sut2.VendingMachineItems["A4"].Name);
            Assert.AreEqual(expectedItemDict2["A4"].Price, sut2.VendingMachineItems["A4"].Price);
            Assert.AreEqual(expectedItemDict2["B1"].Name, sut2.VendingMachineItems["B1"].Name);
            Assert.AreEqual(expectedItemDict2["B1"].Price, sut2.VendingMachineItems["B1"].Price);
            Assert.AreEqual(expectedItemDict2["B2"].Name, sut2.VendingMachineItems["B2"].Name);
            Assert.AreEqual(expectedItemDict2["B2"].Price, sut2.VendingMachineItems["B2"].Price);
            Assert.AreEqual(expectedItemDict2["B3"].Name, sut2.VendingMachineItems["B3"].Name);
            Assert.AreEqual(expectedItemDict2["B3"].Price, sut2.VendingMachineItems["B3"].Price);
            Assert.AreEqual(expectedItemDict2["B4"].Name, sut2.VendingMachineItems["B4"].Name);
            Assert.AreEqual(expectedItemDict2["B4"].Price, sut2.VendingMachineItems["B4"].Price);
            Assert.AreEqual(expectedItemDict2["C1"].Name, sut2.VendingMachineItems["C1"].Name);
            Assert.AreEqual(expectedItemDict2["C1"].Price, sut2.VendingMachineItems["C1"].Price);
            Assert.AreEqual(expectedItemDict2["C2"].Name, sut2.VendingMachineItems["C2"].Name);
            Assert.AreEqual(expectedItemDict2["C2"].Price, sut2.VendingMachineItems["C2"].Price);
            Assert.AreEqual(expectedItemDict2["C3"].Name, sut2.VendingMachineItems["C3"].Name);
            Assert.AreEqual(expectedItemDict2["C3"].Price, sut2.VendingMachineItems["C3"].Price);
            Assert.AreEqual(expectedItemDict2["C4"].Name, sut2.VendingMachineItems["C4"].Name);
            Assert.AreEqual(expectedItemDict2["C4"].Price, sut2.VendingMachineItems["C4"].Price);
            Assert.AreEqual(expectedItemDict2["D1"].Name, sut2.VendingMachineItems["D1"].Name);
            Assert.AreEqual(expectedItemDict2["D1"].Price, sut2.VendingMachineItems["D1"].Price);
            Assert.AreEqual(expectedItemDict2["D2"].Name, sut2.VendingMachineItems["D2"].Name);
            Assert.AreEqual(expectedItemDict2["D2"].Price, sut2.VendingMachineItems["D2"].Price);
            Assert.AreEqual(expectedItemDict2["D3"].Name, sut2.VendingMachineItems["D3"].Name);
            Assert.AreEqual(expectedItemDict2["D3"].Price, sut2.VendingMachineItems["D3"].Price);
            Assert.AreEqual(expectedItemDict2["D4"].Name, sut2.VendingMachineItems["D4"].Name);
            Assert.AreEqual(expectedItemDict2["D4"].Price, sut2.VendingMachineItems["D4"].Price);

            //            A1 | Pirates | 3.45 | Gum
            Assert.AreEqual(expectedInventoryDict2["Pirates"], sut1.Inventory["Pirates"]);
            //A2 | Penguins | 1.30 | Gum
            Assert.AreEqual(expectedInventoryDict2["Penguins"], sut1.Inventory["Penguins"]);
            //A3 | Steelers | 3.70 | Chip
            Assert.AreEqual(expectedInventoryDict2["Steelers"], sut1.Inventory["Steelers"]);
            //A4 | Andy Warhol | 1.70 | Gum
            Assert.AreEqual(expectedInventoryDict2["Andy Warhol"], sut1.Inventory["Andy Warhol"]);
            //B1 | Mac Miller | 1.10 | Candy
            Assert.AreEqual(expectedInventoryDict2["Mac Miller"], sut1.Inventory["Mac Miller"]);
            //B2 | Wiz Khalifa | 3.15 | Candy
            Assert.AreEqual(expectedInventoryDict2["Wiz Khalifa"], sut1.Inventory["Wiz Khalifa"]);
            //B3 | Gillian Jacobs | 1.20 | Chip
            Assert.AreEqual(expectedInventoryDict2["Gillian Jacobs"], sut1.Inventory["Gillian Jacobs"]);
            //B4 | Mary Lou Williams| 2.85 | Gum
            Assert.AreEqual(expectedInventoryDict2["Mary Lou Williams"], sut1.Inventory["Mary Lou Williams"]);
            //C1 | George Benson | 1.95 | Chip
            Assert.AreEqual(expectedInventoryDict2["George Benson"], sut1.Inventory["George Benson"]);
            //C2 | Art Blakey | 2.10 | Drink
            Assert.AreEqual(expectedInventoryDict2["Art Blakey"], sut1.Inventory["Art Blakey"]);
            //C3 | Ahmad Jamal | 2.85 | Candy
            Assert.AreEqual(expectedInventoryDict2["Ahmad Jamal"], sut1.Inventory["Ahmad Jamal"]);
            //C4 | Billy Strayhorn | 2.85 | Candy
            Assert.AreEqual(expectedInventoryDict2["Billy Strayhorn"], sut1.Inventory["Billy Strayhorn"]);
            //D1 | Roberto Clemente | 1.30 | Gum
            Assert.AreEqual(expectedInventoryDict2["Roberto Clemente"], sut1.Inventory["Roberto Clemente"]);
            //D2 | Mario Lemieux | 1.70 | Drink
            Assert.AreEqual(expectedInventoryDict2["Mario Lemieux"], sut1.Inventory["Mario Lemieux"]);
            //D3 | Steven Adams | 1.75 | Chip
            Assert.AreEqual(expectedInventoryDict2["Steven Adams"], sut1.Inventory["Steven Adams"]);
            //D4 | Erroll Garner | 1.60 | Candy
            Assert.AreEqual(expectedInventoryDict2["Erroll Garner"], sut1.Inventory["Erroll Garner"]);
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
            string input = "oneitem.txt";

            Dictionary<string, Item> expectedItemDict = new Dictionary<string, Item>();
            Dictionary<string, int> expectedInventoryDict = new Dictionary<string, int>();

            Chip chipExpected = new Chip("Grain Waves", 2.75M);

            expectedItemDict["A3"] = chipExpected;

            expectedInventoryDict["Grain Waves"] = 5;

            // Act
            sut.ReadInventoryInput(input);

            // Assert
            Assert.AreEqual(expectedItemDict["A1"].Name, sut.VendingMachineItems["A1"].Name);
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
            CollectionAssert.AreEquivalent(expectedItemDict, sut.VendingMachineItems);
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
            CollectionAssert.AreEquivalent(expectedItemDict, sut.VendingMachineItems);
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
            CollectionAssert.AreEquivalent(expectedItemDict, sut.VendingMachineItems);
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
            CollectionAssert.AreEquivalent(expectedItemDict, sut.VendingMachineItems);
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
            CollectionAssert.AreEquivalent(expectedItemDict, sut.VendingMachineItems);
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
            CollectionAssert.AreEquivalent(expectedItemDict, sut.VendingMachineItems);
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
            CollectionAssert.AreEquivalent(expectedItemDict, sut.VendingMachineItems);
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
            Machine sut = new Machine();
            string input1 = "vendingmachine.csv";
            string input2 = "happypaths.txt";

            string expected1 = "A1|Potato Crisps|3.05|Chip|In Stock: 5\r\nA2|Stackers|1.45|Chip|In Stock: 5\r\nA3|Grain Waves|2.75|Chip|In Stock: 5\r\nA4|Cloud Popcorn|3.65|Chip|In Stock: 5\r\n" +
                "B1|Moonpie|1.80|Candy|In Stock: 5\r\nB2|Cowtales|1.50|Candy|In Stock: 5\r\nB3|Wonka Bar|1.50|Candy|In Stock: 5\r\nB4|Crunchie|1.75|Candy|In Stock: 5\r\n" +
                "C1|Cola|1.25|Drink|In Stock: 5\r\nC2|Dr. Salt|1.50|Drink|In Stock: 5\r\nC3|Mountain Melter|1.50|Drink|In Stock: 5\r\nC4|Heavy|1.50|Drink|In Stock: 5\r\n" +
                "D1|U-Chews|0.85|Gum|In Stock: 5\r\nD2|Little League Chew|0.95|Gum|In Stock: 5\r\nD3|Chiclets|0.75|Gum|In Stock: 5\r\nD4|Triplemint|0.75|Gum|In Stock: 5";

            string expected2 = "A1|Pirates|3.45|Gum|In Stock: 5\r\nA2|Penguins|1.30|Gum|In Stock: 5\r\nA3|Steelers|3.70|Chip|In Stock: 5\r\nA4|Andy Warhol|1.70|Gum|In Stock: 5\r\n" +
                "B1|Mac Miller|1.10|Candy|In Stock: 5\r\nB2|Wiz Khalifa|3.15|Candy|In Stock: 5\r\nB3|Gillian Jacobs|1.20|Chip|In Stock: 5\r\nB4|Mary Lou Williams|2.85|Gum|In Stock: 5\r\n" +
                "C1|George Benson|1.95|Chip\r\nC2|Art Blakey|2.10|Drink\r\nC3|Ahmad Jamal|2.85|Candy\r\nC4|Billy Strayhorn|2.85|Candy\r\n" +
                "D1|Roberto Clemente|1.30|Gum|In Stock: 5\r\nD2|Mario Lemieux|1.70|Drink|In Stock: 5\r\nD3|Steven Adams|1.75|Chip|In Stock: 5\r\nD4|Erroll Garner|1.60|Candy|In Stock: 5";

            // Act
            string actual1 = sut.DisplayVendingMachineItems(input1);
            string actual2 = sut.DisplayVendingMachineItems(input2);

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
