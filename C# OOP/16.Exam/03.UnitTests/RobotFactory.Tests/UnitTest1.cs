using NUnit.Framework;
using System.Linq;

namespace RobotFactory.Tests
{
    public class Tests
    {
        private Factory factory;
        [SetUp]
        public void Setup()
        {
            factory = new Factory("Gosho", 10);
        }

        [Test]
        public void CtroShouldWork()
        {
            Factory factory = new Factory("Gosho", 10);
            Assert.That(factory.Name, Is.EqualTo("Gosho"));
            Assert.That(factory.Capacity, Is.EqualTo(10));
            Assert.IsNotNull(factory.Robots);
            Assert.IsNotNull(factory.Supplements);
        }

        [Test]
        public void ProduceRobotShoulThrow()
        {
            Factory factory = new Factory("Gosho", 0);
            //Robot robot = new Robot("1gfg", 10.0, 10);
            //factory.ProduceRobot("1gfg", 10.0, 10);

            Assert.That(factory.ProduceRobot("1gfg", 10.0, 10), Is.EqualTo("The factory is unable to produce more robots for this production day!"));
            Assert.That(factory.Robots.Count, Is.EqualTo(0));
        }

        [Test]
        public void ProduceRobotShouldWork()
        {
            Factory factory = new Factory("Gosho", 10);
            Assert.That(factory.ProduceRobot("1gfg", 10.0, 10), Is.EqualTo($"Produced --> Robot model: 1gfg IS: 10, Price: 10.00"));
            Assert.That(factory.Robots.Count, Is.EqualTo(1));
        }

        [Test]
        public void ProduceSupplShouldWork()
        {

            Assert.That(factory.ProduceSupplement("Bira", 10), Is.EqualTo("Supplement: Bira IS: 10"));
            Assert.That(factory.Supplements.Count, Is.EqualTo(1));
        }

        [Test]
        public void UpgradeShouldReturnFalse()
        {
            Robot robot = new Robot("1gfg", 10.0, 10);
            Supplement supl = new Supplement("Bira", 9);
            factory.ProduceRobot("1gfg", 10.0, 10);
            factory.ProduceSupplement("Bira", 10);

            Assert.IsFalse(factory.UpgradeRobot(robot, supl));
        }

        [Test]
        public void UpgradeShouldReturnTrue()
        {
            Robot robot = new Robot("1gfg", 10.0, 10);
            Supplement supl = new Supplement("Bira", 10);
            factory.ProduceRobot("1gfg", 10.0, 10);
            factory.ProduceSupplement("Bira", 10);

            Assert.IsTrue(factory.UpgradeRobot(robot, supl));
            Assert.That(robot.Supplements.Count, Is.EqualTo(1));
        }

        [Test]
        public void SellRobotShouldWork()
        {

            Robot robot1 = new Robot("1gf", 12.0, 11);
            factory.ProduceRobot("1gfg", 10.0, 10);
            factory.ProduceRobot("1gf", 12.0, 11);
            Robot robot = factory.Robots.FirstOrDefault(r => r.Model == "1gfg");
            var expectedOut = factory.SellRobot(10);
            Assert.That(expectedOut, Is.EqualTo(robot));

        }
    }
}