using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void AxeGettersTest()
        {
            var axe = new Axe(10, 10);

            Assert.AreEqual(10, axe.AttackPoints);
            Assert.AreEqual(10, axe.DurabilityPoints);
        }
        [Test]
        public void AxeLoosesDurabilityAfterAttack()
        {
            //Arrange
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);

            //Act
            axe.Attack(dummy);

            //Assert
            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe Durability doesn't change after attack.");
        }
        [Test]
        public void BrokenAxeShouldThrowException()
        {
            Assert.That(() =>
            {
                Axe axe = new Axe(10, 0);
                Dummy dummy = new Dummy(10, 10);

                axe.Attack(dummy);
            },
            Throws.Exception.TypeOf<InvalidOperationException>(),
            "Axe is broken.");
        }
    }
}