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
        private string brand;
        private string model;
        private string licensePlateNumber;

        public Vehicle(string brand, string model, double maxMileage, string licensePlateNumber)
        {
            Brand = brand;
            Model = model;
            MaxMileage = maxMileage;
            LicensePlateNumber = licensePlateNumber;
            BatteryLevel = 100;
            IsDamaged = false;
        }

        public string Brand
        {
            get => brand;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BrandNull);
                }
                brand = value;
            }
        }

        public string Model
        {
            get => model;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ModelNull);
                }
                model = value;
            }
        }

        public string LicensePlateNumber
        {
            get => licensePlateNumber;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.LicenceNumberRequired);
                }
                licensePlateNumber = value;
            }
        }

        public double MaxMileage { get; private set; }
               

        public int BatteryLevel { get; private set; }

        public bool IsDamaged { get; private set; }

        public void Drive(double mileage)
        {
            double batteryUsage = mileage / MaxMileage;
           
            if (this.GetType().Name == "CargoVan")
            {
                batteryUsage += 0.05; 
            }

            double batteryLevelDecrease = 100 * batteryUsage;

            batteryLevelDecrease = Math.Round(batteryLevelDecrease);

            BatteryLevel -= (int)(batteryLevelDecrease);
           

        }
        public void Recharge()
        {
            BatteryLevel = 100;
        }

        public void ChangeStatus()
        {
            if (IsDamaged == false)
            {
                IsDamaged = true;
            }
            else
            {
                IsDamaged = false;
            }
        }

        public override string ToString()
        {
            string currentStatus;
            if (IsDamaged == false)
            {
                currentStatus = "OK";
            }
            else
            {
                currentStatus = "damaged";
            }

            return $"{Brand} {Model} License plate: {LicensePlateNumber} Battery: {BatteryLevel}% Status: {currentStatus}";
        }

    }
}
