using NUnit.Framework;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
            [Test]
            public void InicializeRepairsShop_ValidParameters()
            {
                Car car = new Car("BMW", 158);
                Assert.That(car.CarModel, Is.EqualTo("BMW"));
            }
           
        }
    }
}