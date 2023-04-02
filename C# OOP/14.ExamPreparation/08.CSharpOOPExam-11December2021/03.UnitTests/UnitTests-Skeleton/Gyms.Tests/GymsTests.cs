using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    public class GymsTests
    {
        private Gym gym;
        [SetUp]
        public void SetUp()
        {
            this.gym = new Gym("Tony", 10);
        }
        [Test]
        public void GymInitializeCorrect()
        {
            Assert.IsNotNull(gym);
            Assert.That(gym, Is.Not.Null);
            Assert.That(gym.Name, Is.EqualTo("Tony"));
            Assert.That(gym.Capacity, Is.EqualTo(10));
        }
        [Test]
        public void GymInitializeWhitIncorretParamsShouldThrowsArgumentNullException()
        {
            Gym gym;

            Assert.Throws<ArgumentNullException>(() => new Gym("", 10), $"Invalid gym name.");
            Assert.Throws<ArgumentNullException>(() => new Gym(null, 10), $"Invalid gym name.");
            Assert.Throws<ArgumentException>(() => new Gym("Good", -1), $"Invalid gym capacity.");

        }
        [Test]
        public void AddAthletShouldAddOneAthlete()
        {
            Athlete athlete = new Athlete("Pesho");
            this.gym.AddAthlete(athlete);

            Assert.That(gym.Count, Is.EqualTo(1));

        }
        [Test]
        public void AddAthletThatalreadyExistsShouldThrowsException()
        {
            Athlete athlete = new Athlete("Pesho");
            this.gym.AddAthlete(athlete);
            this.gym.AddAthlete(athlete);
            this.gym.AddAthlete(athlete);
            this.gym.AddAthlete(athlete);
            this.gym.AddAthlete(athlete);
            this.gym.AddAthlete(athlete);
            this.gym.AddAthlete(athlete);
            this.gym.AddAthlete(athlete);
            this.gym.AddAthlete(athlete);
            this.gym.AddAthlete(athlete);

            Assert.Throws<InvalidOperationException>(() => this.gym.AddAthlete(athlete), "The gym is full.");
        }
        [Test]
        public void RemoveAthleteShouldRemoveOneAthlete()
        {
            Athlete athlete = new Athlete("Pesho");
            this.gym.AddAthlete(athlete);
            gym.RemoveAthlete("Pesho");

            Assert.That(gym.Count, Is.EqualTo(0));

        }
        [Test]
        public void RemoveAthleteThatAlreadyDoesNotExistsShouldThrowsException()
        {
            Athlete athlete = new Athlete("Pesho");
            this.gym.AddAthlete(athlete);
            this.gym.AddAthlete(athlete);
            this.gym.AddAthlete(athlete);
            this.gym.AddAthlete(athlete);
            this.gym.AddAthlete(athlete);
            this.gym.AddAthlete(athlete);
            this.gym.AddAthlete(athlete);
            this.gym.AddAthlete(athlete);
            this.gym.AddAthlete(athlete);
            this.gym.AddAthlete(athlete);

            Assert.Throws<InvalidOperationException>(() => this.gym.RemoveAthlete("Gosho"), $"The athlete Gosho doesn't exist.");
        }
        [Test]
        public void InjureAthleteShouldReturnTrueAndCorrectAthlete()
        {
            Athlete athlete = new Athlete("Pesho");
            this.gym.AddAthlete(athlete);
            var result = gym.InjureAthlete("Pesho");

            Assert.That(athlete.IsInjured, Is.EqualTo(true));
            Assert.That(result, Is.EqualTo(athlete));
        }
        [Test]
        public void InjureAthleteShouldThrowsInvalidOperationExceptionWhenAthleteIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => this.gym.InjureAthlete("Gosho"), $"The athlete Gosho doesn't exist.");
        }
        [Test]
        public void ReportShouldReturnsReport()
        {
            Athlete athlete = new Athlete("Pesho");
            this.gym.AddAthlete(athlete);
            var result = gym.Report();

            Assert.That(result, Is.EqualTo("Active athletes at Tony: Pesho"));
        }
    }
}
