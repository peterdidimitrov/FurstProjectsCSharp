using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [Test]
        public void CreateSmartphone_InvalidParameters()
        {
            Smartphone smartphone = new Smartphone("Nokia", 100);

            Assert.IsNotNull(smartphone.ModelName);
            Assert.IsNotNull(smartphone.CurrentBateryCharge);
            Assert.IsFalse(smartphone.CurrentBateryCharge == 0);
            Assert.That(smartphone.ModelName, Is.EqualTo("Nokia"));
            Assert.That(smartphone.CurrentBateryCharge, Is.EqualTo(100));
            Assert.That(smartphone.MaximumBatteryCharge, Is.EqualTo(100));

        }
        [Test]
        public void InicializeShop_InvalidCapacity()
        {
            Shop shop;
            Assert.Throws<ArgumentException>(() => shop = new Shop(-1), "Invalid capacity.");

        }
        [Test]
        public void AddSmartphone_AddingOnePhone()
        {
            Shop shop = shop = new Shop(100);

            Smartphone smartphone = new Smartphone("Nokia", 100);
            shop.Add(smartphone);

            Assert.That(shop.Count, Is.EqualTo(1));
        }
        [Test]
        public void AddSmartphone_CapacityIsFull()
        {
            Shop shop = shop = new Shop(1);

            Smartphone smartphone = new Smartphone("Nokia", 100);
            Smartphone smartphone1 = new Smartphone("Simmens", 100);

            shop.Add(smartphone);

            Assert.True(shop.Capacity == shop.Count);
            Assert.Throws<InvalidOperationException>(() => shop.Add(smartphone1), "The shop is full.");
        }
        [Test]
        public void RemoveSmartphone_RemovingOnePhone()
        {
            Shop shop = shop = new Shop(100);

            Smartphone smartphone = new Smartphone("Nokia", 100);
            shop.Add(smartphone);

            shop.Remove("Nokia");

            Assert.That(shop.Count, Is.EqualTo(0));
        }
        [Test]
        public void RemoveSmartphone_InvalidModelNamePhoneDoesNotExist()
        {
            Shop shop = shop = new Shop(100);

            Smartphone smartphone = new Smartphone("Nokia", 100);

            Assert.Throws<InvalidOperationException>(() => shop.Remove("Nokia"), $"The phone model {smartphone.ModelName} doesn't exist.");
        }
        [Test]
        public void AddSmatrphone_InvalidModelNamePhoneExist()
        {
            Shop shop = shop = new Shop(100);

            Smartphone smartphone = new Smartphone("Nokia", 100);
            Smartphone smartphone1 = new Smartphone("Nokia", 100);

            shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(() => shop.Add(smartphone1), $"The phone model {smartphone1.ModelName} already exist.");
        }
        [Test]
        public void ChargePhone_InvalidModelNamePhoneDoesNotExist()
        {
            Shop shop = shop = new Shop(100);

            Smartphone smartphone = new Smartphone("Nokia", 100);

            Assert.Throws<InvalidOperationException>(() => shop.ChargePhone(smartphone.ModelName), $"The phone model {smartphone.ModelName} doesn't exist.");
        }
        [Test]
        public void TestPhone_InvalidModelNamePhoneDoesNotExist()
        {
            Shop shop = shop = new Shop(100);

            Smartphone smartphone = new Smartphone("Nokia", 100);

            Assert.Throws<InvalidOperationException>(() => shop.TestPhone(smartphone.ModelName, 100), $"The phone model {smartphone.ModelName} doesn't exist.");
        }
        [Test]
        public void TestPhone_IsWorkingCurrentBateryChargeEqualTo50()
        {
            Shop shop = shop = new Shop(100);

            Smartphone smartphone = new Smartphone("Nokia", 100);
            shop.Add(smartphone);

            int batteryUsage = 50;

            shop.TestPhone(smartphone.ModelName, batteryUsage);

            Assert.That(smartphone.CurrentBateryCharge, Is.EqualTo(50));
        }
        [Test]
        public void TestPhone_LowOnBatery()
        {
            Shop shop = shop = new Shop(100);

            Smartphone smartphone = new Smartphone("Nokia", 10);
            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() => shop.TestPhone(smartphone.ModelName, 100), $"The phone model {smartphone.ModelName} is low on batery.");
        }
        [Test]
        public void ChargePhone_IsWorkingChargeTo100()
        {
            Shop shop = shop = new Shop(100);

            Smartphone smartphone = new Smartphone("Nokia", 100);
            smartphone.CurrentBateryCharge = 50;

            shop.Add(smartphone);

            shop.ChargePhone(smartphone.ModelName);

            Assert.That(smartphone.CurrentBateryCharge, Is.EqualTo(100));
        }
    }
}