using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyLooseHealthAfterAttacked()
        {
            //Arrange
            Axe axe = new Axe(1, 10);
            Dummy dummy = new Dummy(10, 10);

            //Act
            axe.Attack(dummy);

            //Assert
            Assert.That(dummy.Health, Is.EqualTo(9), "Dummy does not change after attack.");
        }
        [Test]
        public void DeadDummyShouldThrowException()
        {
            Assert.That(() =>
            {
                Axe axe = new Axe(10, 10);
                Dummy dummy = new Dummy(0, 10);

                axe.Attack(dummy);
                dummy.TakeAttack(10);
            },
            Throws.Exception.TypeOf<InvalidOperationException>(),
            "Dummy is dead.");
        }
        [Test]
        public void DeadDummyShouldGiveXP()
        {
            //Arrange
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);

            //Act
            axe.Attack(dummy);


            //Assert
            Assert.That(dummy.GiveExperience, Is.EqualTo(10), "Dummy is dead and give XP.");
        }
        [Test]
        public void WhenDummyAliveItShouldNotGiveXP()
        {
            Assert.That(() =>
            {
                Axe axe = new Axe(1, 10);
                Dummy dummy = new Dummy(10, 10);

                axe.Attack(dummy);
                dummy.GiveExperience();
            },
            Throws.Exception.TypeOf<InvalidOperationException>(),
            "Target is not dead.");
        }
        [Test]
        public void WhenHealthDropByZeroDummyIsDead()
        {
            //Arrange
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(1, 10);

            //Act
            axe.Attack(dummy);

            //Assert
            Assert.That(dummy.IsDead, Is.True);
        }
    }
}