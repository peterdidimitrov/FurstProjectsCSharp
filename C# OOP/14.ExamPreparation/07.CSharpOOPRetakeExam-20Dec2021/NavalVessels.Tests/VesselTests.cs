using NavalVessels.Core;
using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using NavalVessels.Repositories.Contracts;

namespace NavalVessels.Tests
{
    public class VesselTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void InitializeVesselsShoudThrowException()
        {
            IVessel vessel;
            Assert.Throws<ArgumentException>(() => new Battleship(null, 10, 15), "Vessel name cannot be null or empty.");
        }
        [Test]
        public void InitializeCaptainShoudThrowException()
        {
            ICaptain captain;
            Assert.Throws<ArgumentNullException>(() => new Captain(null), "Captain full name cannot be null or empty string.");
        }
    }
}