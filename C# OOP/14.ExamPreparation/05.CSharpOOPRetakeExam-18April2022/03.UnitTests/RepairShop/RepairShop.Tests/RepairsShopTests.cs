using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
            [Test]
            public void InicializeCar_ValidParameters()
            {
                Car car = new Car("BMW", 1);
                
                Assert.IsNotEmpty(car.CarModel);
                Assert.IsNotNull(car.CarModel);
                Assert.That(car.CarModel, Is.EqualTo("BMW"));
                Assert.That(car.NumberOfIssues, Is.EqualTo(1));
                Assert.False(car.IsFixed);
            }
            [Test]
            public void InicializeGarage_ValidParameters()
            {
                Garage garage = new Garage("Pesho's garage", 2);

                Assert.IsNotEmpty(garage.Name);
                Assert.IsNotNull(garage.Name);
                Assert.That(garage.Name, Is.EqualTo("Pesho's garage"));
                Assert.That(garage.MechanicsAvailable, Is.EqualTo(2));
            }
            [Test]
            public void InicializeGarage_InvalidName()
            {
                Garage garage;

                Assert.Throws<ArgumentNullException>(() => garage = new Garage(null, 2), "Invalid garage name.");
            }
            [Test]
            public void InicializeGarage_InvalidMechanicsAvailableEqualToZero()
            {
                Garage garage;

                Assert.Throws<ArgumentException>(() => garage = new Garage("Pesho's garage", 0), "At least one mechanic must work in the garage.");
            }
            [Test]
            public void InicializeGarage_InvalidMechanicsAvailableUnderZero()
            {
                Garage garage;

                Assert.Throws<ArgumentException>(() => garage = new Garage("Pesho's garage", -1), "At least one mechanic must work in the garage.");
            }
        }
    }
}