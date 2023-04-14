using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Models.Races
{
    public class Race : IRace
    {
        private string name;
        private int laps;
        private readonly List<IDriver> drivers;

        public Race(string name, int laps)
        {
            Name = name;
            Laps = laps;

            drivers = new List<IDriver>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, 5));
                }
                name = value;
            }
        }

        public int Laps
        {
            get { return laps; }
            private set 
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfLaps, 1));
                }
                laps = value; }
        }

        public IReadOnlyCollection<IDriver> Drivers => drivers.AsReadOnly();

        public void AddDriver(IDriver driver)
        {
            var desiredDriver = drivers.FirstOrDefault(x => x.Name == driver.Name);

            if (driver == null)
            {
                throw new ArgumentNullException(string.Format(ExceptionMessages.DriverInvalid));
            }
            if (!driver.CanParticipate)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriverNotParticipate, driver.Name));
            }
            if (desiredDriver != null)
            {
                throw new ArgumentNullException(string.Format(ExceptionMessages.DriverAlreadyAdded, desiredDriver.Name, this.Name));
            }

            drivers.Add(driver);
        }
    }
}
