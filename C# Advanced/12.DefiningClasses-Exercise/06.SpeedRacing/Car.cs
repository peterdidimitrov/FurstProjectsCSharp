using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer, double travelledDistance)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            TravelledDistance = travelledDistance;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public void Moving(Car car, double usedFuel, double amuontOfKm)
        {
            if (car.FuelAmount - usedFuel >= 0)
            {
                car.FuelAmount -= usedFuel;
                car.TravelledDistance += amuontOfKm;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
