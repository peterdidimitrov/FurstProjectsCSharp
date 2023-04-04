using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public abstract class Racer : IRacer
    {
        private string username;
        private string racingBehavior;
        private int drivingExperience;
        private ICar car;

        protected Racer(string username, string racingBehavior, int drivingExperience, ICar car)
        {
            Username = username;
            RacingBehavior = racingBehavior;
            DrivingExperience = drivingExperience;
            Car = car;
        }

        public string Username 
        {
            get { return username; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerName);
                }
                username = value;
            }
        }
        public string RacingBehavior
        {
            get { return racingBehavior; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerBehavior);
                }
                racingBehavior = value;
            }
        }
        public int DrivingExperience
        {
            get { return drivingExperience; }
            protected set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerDrivingExperience);
                }
                drivingExperience = value; 
            }
        }

        public ICar Car
        {
            get { return car; }
            private set 
            {
                if (value == null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerCar);
                }
                car = value;
            }
        }
        public bool IsAvailable() => Car.FuelAvailable >= Car.FuelConsumptionPerRace;

        public virtual void Race()
        {
            Car.Drive();
        }
        public override string ToString()
        {
            Type type = GetType();
            var builder = new StringBuilder();

            builder.AppendLine($"{type.Name}: {username}");
            builder.AppendLine($"--Driving behavior: {racingBehavior}");
            builder.AppendLine($"--Driving experience: {drivingExperience}");
            builder.AppendLine($"--Car: {Car.Make} {Car.Model} ({Car.VIN})");

            return builder.ToString().TrimEnd();
        }
    }
}
