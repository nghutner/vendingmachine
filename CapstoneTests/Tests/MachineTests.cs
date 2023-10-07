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
            string[] input1 = { "A1", "Potato Crisps", "3.05", "Chip" };

        }

        [TestMethod]

        public void AddToDictionaryHappyPaths()
        {

            // Arrange
            Machine sut = new Machine();
            

            // Act
            

            // Assert
        }
    }
}
