using System;
using System.Collections.Generic;
using System.Linq;
namespace _07.VehicleCatalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;

            Catalog catalog = new Catalog();

            while ((input = Console.ReadLine()) != "end")
            {
                string[] infoVehicle = input.Split("/");
                string vehicleType = infoVehicle[0];
                string brand = infoVehicle[1];
                string model = infoVehicle[2];
                int value = int.Parse(infoVehicle[3]);

                if (vehicleType == "Truck")
                {
                    Truck truck = new Truck(brand, model, value);
                    catalog.Trucks.Add(truck);
                }
                else
                {
                    Car car = new Car(brand, model, value);
                    catalog.Cars.Add(car);
                }
            }
            if (catalog.Cars.Count > 0)
            {
                Console.WriteLine("Cars:");
            }
            foreach (var vehicle in catalog.Cars.OrderBy(x => x.Brand))
            {
                Console.WriteLine($"{vehicle.Brand}: {vehicle.Model} - {vehicle.HorsePower}hp");
            }

            if (catalog.Trucks.Count > 0)
            {
                Console.WriteLine("Trucks:");
            }
            foreach (var vehicle in catalog.Trucks.OrderBy(x => x.Brand))
            {
                Console.WriteLine($"{vehicle.Brand}: {vehicle.Model} - {vehicle.Weight}kg");
            }
        }
    }
    public class Catalog
    {
        public Catalog()
        {
            Cars = new List<Car>();
            Trucks = new List<Truck>();
        }

        public List<Car> Cars { get; set; }
        public List<Truck> Trucks { get; set; }
    }
    public class Car
    {
        public Car(string brand, string model, int horsePower)
        {
            Brand = brand;
            Model = model;
            HorsePower = horsePower;
        }

        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
    }
    public class Truck
    {
        public Truck(string brand, string model, int weight)
        {
            Brand = brand;
            Model = model;
            Weight = weight;
        }

        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }
    }
}
