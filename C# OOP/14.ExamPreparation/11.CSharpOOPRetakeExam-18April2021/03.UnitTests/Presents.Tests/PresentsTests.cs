namespace Presents.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class PresentsTests
    {
        [Test]
        public void Test1()
        {
            var preasent = new Present("Topka", 10);
            Assert.That(preasent.Name, Is.EqualTo("Topka"));
            Assert.That(preasent.Magic, Is.EqualTo(10));
        }
        [Test]
        public void Test2()
        {
            var preasent = new Present("Topka", 10);
            var bag = new Bag();
            

            var result = bag.Create(preasent);

            Assert.That(bag.GetPresents().Count, Is.EqualTo(1));
            Assert.That(result, Is.EqualTo($"Successfully added present Topka."));
        }
        [Test]
        public void Test3()
        {
            Present preasent = null;
            var bag = new Bag();

            Assert.Throws<ArgumentNullException>(() => bag.Create(preasent), "Present is null");
        }
        [Test]
        public void Test4()
        {
            Present preasent = new Present("Topka", 10);
            //Present preasent1 = new Present("Topka", 10);
            var bag = new Bag();

            bag.Create(preasent);

            Assert.Throws<InvalidOperationException>(() => bag.Create(preasent), "This present already exists!");
        }
        [Test]
        public void Test5()
        {
            var preasent = new Present("Topka", 10);
            var bag = new Bag();

            bag.Create(preasent);

            bag.Remove(preasent);

            Assert.That(bag.GetPresents().Count, Is.EqualTo(0));
        }
        [Test]
        public void Test6()
        {
            var preasent = new Present("Topka", 10);
            var preasent1 = new Present("Topka1", 12);
            var bag = new Bag();

            bag.Create(preasent);
            bag.Create(preasent1);
            

            Assert.That(bag.GetPresentWithLeastMagic(), Is.EqualTo(preasent));
        }
        [Test]
        public void Test7()
        {
            var preasent = new Present("Topka", 10);

            var bag = new Bag();
            bag.Create(preasent);
            var result = bag.GetPresent("Topka");


            Assert.That(result, Is.EqualTo(preasent));
        }
    }
}
