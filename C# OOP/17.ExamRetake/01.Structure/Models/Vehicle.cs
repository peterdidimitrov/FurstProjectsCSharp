using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Models
{
    public abstract class Vehicle : IVehicle
    {
        public Vehicle(string brand, string model, double maxMileage, string licensePlateNumber)
        {
            Brand = brand;
            Model = model;
            MaxMileage = maxMileage;
            LicensePlateNumber = licensePlateNumber;

            BatteryLevel = 100;
            IsDamaged = false;
        }
        private string brand ;
        public string Brand
        {
            get { return brand; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BrandNull);
                }
                brand = value;
            }
        }

        private string model;
        public string Model
        {
            get { return model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ModelNull);
                }
                model = value;
            }
        }

        public double MaxMileage { get; private set; }

        private string licensePlateNumber ;
        public string LicensePlateNumber
        {
            get { return licensePlateNumber; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.LicenceNumberRequired);
                }
                licensePlateNumber = value;
            }
        }

        public int BatteryLevel { get; private set; }

        public bool IsDamaged { get; protected set; }

        public void ChangeStatus()
        {
            if (IsDamaged)
            {
                IsDamaged = true;
            }
            else
            {
                IsDamaged = false;
            }
        }

        public void Drive(double mileage)
        {
            double percentage = Math.Round(mileage / MaxMileage * 100);
            BatteryLevel -= (int)(BatteryLevel * (percentage / 100));
            if (this.GetType().Name == "CargoVan")
            {
                BatteryLevel -= (int)(BatteryLevel * (5 / 100));
            }
        }

        public void Recharge() => BatteryLevel = 100;

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.Append($"{Brand} {Model} License plate: {LicensePlateNumber} Battery: {BatteryLevel}% Status: ");
            if (IsDamaged)
            {
                builder.Append("OK");
            }
            else
            {
                builder.Append("damaged");
            }

            return builder.ToString().TrimEnd();
        }
    }
}
