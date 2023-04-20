using NUnit.Framework;
using System;

namespace Computers.Tests
{
    [TestFixture]
    public class ComputerManagerTests
    {
        private ComputerManager computerManager;

        [SetUp]
        public void SetUp()
        {
            this.computerManager = new ComputerManager();
        }

        [Test]
        public void AddComputer_ShouldThrowArgumentNullException_WhenComputerIsNull()
        {
            // Arrange
            Computer computer = null;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => this.computerManager.AddComputer(computer));
        }

        [Test]
        public void AddComputer_ShouldThrowArgumentException_WhenComputerAlreadyExists()
        {
            // Arrange
            string manufacturer = "Fujitsu";
            string model = "Pravezt";
            decimal price = 2500;
            Computer computer1 = new Computer(manufacturer, model, price);
            Computer computer2 = new Computer(manufacturer, model, price);
            this.computerManager.AddComputer(computer1);

            // Act and Assert
            Assert.Throws<ArgumentException>(() => this.computerManager.AddComputer(computer2));
        }

        [Test]
        public void AddComputer_ShouldAddComputer_WhenComputerIsValid()
        {
            // Arrange
            string manufacturer = "Fujitsu";
            string model = "Pravezt";
            decimal price = 1200;
            Computer computer = new Computer(manufacturer, model, price);

            // Act
            this.computerManager.AddComputer(computer);

            // Assert
            Assert.AreEqual(1, this.computerManager.Count);
            Assert.AreEqual(computer, this.computerManager.GetComputer(manufacturer, model));
        }

        [Test]
        public void RemoveComputer_ShouldRemoveComputer_WhenComputerExists()
        {
            // Arrange
            string manufacturer = "Fujitsu";
            string model = "Pravezt";
            decimal price = 1600;
            Computer computer = new Computer(manufacturer, model, price);
            this.computerManager.AddComputer(computer);

            // Act
            Computer removedComputer = this.computerManager.RemoveComputer(manufacturer, model);

            // Assert
            Assert.AreEqual(0, this.computerManager.Count);
            Assert.AreEqual(computer, removedComputer);
        }

        [Test]
        public void RemoveComputer_ShouldThrowArgumentException_WhenComputerDoesNotExist()
        {
            // Arrange
            string manufacturer = "Fujitsu";
            string model = "Pravezt";

            // Act and Assert
            Assert.Throws<ArgumentException>(() => this.computerManager.RemoveComputer(manufacturer, model));
        }

        [Test]
        public void GetComputer_ShouldReturnCorrectComputer_WhenComputerExists()
        {
            // Arrange
            string manufacturer = "Fujitsu";
            string model = "Pravezt";
            decimal price = 2000;
            Computer computer = new Computer(manufacturer, model, price);
            this.computerManager.AddComputer(computer);

            // Act
            Computer result = this.computerManager.GetComputer(manufacturer, model);

            // Assert
            Assert.AreEqual(computer, result);
        }

        [Test]
        public void GetComputer_ShouldThrowArgumentException_WhenComputerDoesNotExist()
        {
            // Arrange
            string manufacturer = "Fujitsu";
            string model = "Pravezt";

            // Act and Assert
            Assert.Throws<ArgumentException>(() => this.computerManager.GetComputer(manufacturer, model));
        }

        //[Test]
        //public void GetComputersByManufacturer_ShouldReturnCorrectComputers_WhenComputersExist()
        //{
        //    // Arrange
        //    string manufacturer = "Dell";
        //    string model
    }
}
