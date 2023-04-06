namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    public class AquariumsTests
    {
        private Aquarium aquarium;
        [SetUp]
        public void SetUp()
        {
            this.aquarium = new Aquarium("Tony", 5);
        }
        [Test]
        public void Test1()
        {
            Assert.IsNotNull(aquarium);
            Assert.That(aquarium, Is.Not.Null);
            Assert.That(aquarium.Name, Is.EqualTo("Tony"));
            Assert.That(aquarium.Capacity, Is.EqualTo(5));
        }
        [Test]
        public void Test2()
        {

            Assert.Throws<ArgumentNullException>(() => new Aquarium("", 10), $"Invalid aquarium name!");
            Assert.Throws<ArgumentNullException>(() => new Aquarium(null, 10), $"Invalid aquarium name!");
            Assert.Throws<ArgumentException>(() => new Aquarium("Good", -1), $"Invalid aquarium capacity!");
        }
        [Test]
        public void Test3()
        {

            Fish fish = new Fish("Pesho");
            this.aquarium.Add(fish);

            Assert.That(aquarium.Count, Is.EqualTo(1));

        }
        [Test]
        public void Test4()
        {
            Fish fish = new Fish("Pesho");
            this.aquarium.Add(fish);
            this.aquarium.Add(fish);
            this.aquarium.Add(fish);
            this.aquarium.Add(fish);
            this.aquarium.Add(fish);

            Assert.Throws<InvalidOperationException>(() => this.aquarium.Add(fish), "Aquarium is full!");
        }
        [Test]
        public void Test5()
        {
            Fish fish = new Fish("Pesho");
            this.aquarium.Add(fish);
            aquarium.RemoveFish("Pesho");

            Assert.That(aquarium.Count, Is.EqualTo(0));

        }
        [Test]
        public void Test6()
        {
            Fish fish = new Fish("Pesho");
            this.aquarium.Add(fish);            

            Assert.Throws<InvalidOperationException>(() => this.aquarium.RemoveFish("Gosho"), $"Fish with the name Gosho doesn't exist!");
        }
        [Test]
        public void Test7()
        {
            Fish fish = new Fish("Pesho");
            this.aquarium.Add(fish);
            var result = aquarium.SellFish("Pesho");

            Assert.That(result, Is.EqualTo(fish));
        }
        [Test]
        public void Test8()
        {
            Assert.Throws<InvalidOperationException>(() => this.aquarium.SellFish("Gosho"), $"ish with the name Goisho doesn't exist!");
        }
        [Test]
        public void Test9()
        {
            Fish fish = new Fish("Pesho");
            this.aquarium.Add(fish);
            var result = aquarium.Report();

            Assert.That(result, Is.EqualTo($"Fish available at Tony: Pesho"));
        }
    }
}
