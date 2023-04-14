using NUnit.Framework;
using TheRace;

namespace TheRace.Tests
{
    [TestFixture]
    public class RaceEntryTests
    {
        private UnitDriver driver;
        private UnitCar car;
        private RaceEntry raceEntry;

        [SetUp]
        public void Setup()
        {
            this.car = new UnitCar("Audi", 200, 2000);
            this.driver = new UnitDriver("Pesho", car);
            this.raceEntry = new RaceEntry();
        }

        [Test]
        public void AddDriver_ShouldAddDriver_WhenDriverIsValid()
        {
            // Act
            string result = this.raceEntry.AddDriver(driver);

            // Assert
            Assert.AreEqual($"Driver {driver.Name} added in race.", result);
            Assert.AreEqual(1, this.raceEntry.Counter);
        }

        [Test]
        public void AddDriver_ShouldThrowInvalidOperationException_WhenDriverIsNull()
        {
            // Arrange
            UnitDriver nullDriver = null;

            // Act & Assert
            Assert.That(() => this.raceEntry.AddDriver(nullDriver),
                Throws.InvalidOperationException.With.Message.EqualTo("Driver cannot be null."));
        }

        [Test]
        public void AddDriver_ShouldThrowInvalidOperationException_WhenDriverIsAlreadyAdded()
        {
            // Arrange
            this.raceEntry.AddDriver(driver);

            // Act & Assert
            Assert.That(() => this.raceEntry.AddDriver(driver),
                Throws.InvalidOperationException.With.Message.EqualTo($"Driver {driver.Name} is already added."));
        }

        [Test]
        public void CalculateAverageHorsePower_ShouldThrowInvalidOperationException_WhenParticipantsAreLessThanMin()
        {
            // Arrange
            this.raceEntry.AddDriver(driver);

            // Act & Assert
            Assert.That(() => this.raceEntry.CalculateAverageHorsePower(),
                Throws.InvalidOperationException.With.Message.EqualTo("The race cannot start with less than 2 participants."));
        }

        [Test]
        public void CalculateAverageHorsePower_ShouldReturnCorrectResult_WhenParticipantsAreValid()
        {
            // Arrange
            UnitCar secondCar = new UnitCar("Opel", 280, 3000);
            UnitDriver secondDriver = new UnitDriver("Gosho", secondCar);
            this.raceEntry.AddDriver(driver);
            this.raceEntry.AddDriver(secondDriver);

            // Act
            double result = this.raceEntry.CalculateAverageHorsePower();

            // Assert
            Assert.AreEqual(240, result);
        }
    }
}
