using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories;
using EasterRaces.Utilities.Messages;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using EasterRaces.Models.Drivers;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races;

namespace EasterRaces.Core.Entities
{
    public class Controller : IChampionshipController
    {
        private CarRepository cars;
        private RaceRepository races;
        private DriverRepository drivers;
        public Controller()
        {
            cars = new CarRepository();
            races = new RaceRepository();
            drivers = new DriverRepository();
        }
        public string AddCarToDriver(string driverName, string carModel)
        {
            var desiredDriver = drivers.GetAll().FirstOrDefault(d => d.Name == driverName);
            var desiredCar = cars.GetAll().FirstOrDefault(c => c.Model == carModel);

            if (desiredDriver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            if (desiredCar == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }
            desiredDriver.AddCar(desiredCar);
            return string.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            var desiredRace = races.GetAll().FirstOrDefault(r => r.Name == raceName);
            var desiredDriver = drivers.GetAll().FirstOrDefault(d => d.Name == driverName);

            if (desiredRace == null)
            {
                return string.Format(ExceptionMessages.RaceNotFound, raceName);
            }
            if (desiredDriver == null)
            {
                return string.Format(ExceptionMessages.DriverNotFound, driverName);
            }

            desiredRace.AddDriver(desiredDriver);
            return string.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = null;
            if (type == "MuscleCar")
            {
                car = new MuscleCar(model, horsePower);
            }
            else if (type == "SportsCar")
            {
                car = new SportsCar(model, horsePower);
            }

            if (cars.GetAll().Contains(car))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
            }

            cars.Add(car);
            return string.Format(OutputMessages.CarCreated, type);
        }

        public string CreateDriver(string driverName)
        {
            IDriver driver = new Driver(driverName);

            if (drivers.GetAll().Contains(driver))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }

            drivers.Add(driver);
            return string.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateRace(string name, int laps)
        {
            IRace race = new Race(name, laps);

            if (races.GetAll().Contains(race))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RaceExists, name));
            }

            races.Add(race);
            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            StringBuilder sb = new StringBuilder();

            IRace race = races.GetAll().FirstOrDefault(r => r.Name == raceName);
            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            List<IDriver> winners = race.Drivers.OrderByDescending(m => m.Car.CalculateRacePoints(race.Laps)).Take(3).ToList();

            IDriver first = winners[0];
            IDriver second = winners[1];
            IDriver third = winners[2];

            first.WinRace();

            sb
                .AppendLine($"Pilot {first.Name} wins the {raceName} race.")
                .AppendLine($"Pilot {second.Name} is second in the {raceName} race.")
                .AppendLine($"Pilot {third.Name} is third in the {raceName} race.");

            races.Remove(race);
            return sb.ToString().Trim();
        }
    }
}
