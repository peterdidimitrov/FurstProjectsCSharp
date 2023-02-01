using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        //fields
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        private Engine engine;
        private List<Tire> tires;

        //constructors
        public Car()
        {
            Make = "VW";
            Model = "Golf";
            Year = 2025;
            FuelQuantity = 200;
            FuelConsumption = 10;
        }
        public Car(string make, string model, int year) : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption) : this(make, model, year)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, List<Tire> tires) : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            this.Engine = engine;
            this.Tires = tires;
        }


        //propurties
        public string Make { get { return make; } set { make = value; } }
        public string Model { get { return model; } set { model = value; } }
        public int Year { get { return year; } set { year = value; } }
        public double FuelQuantity { get { return fuelQuantity; } set { fuelQuantity = value; } }
        public double FuelConsumption { get { return fuelConsumption; } set { fuelConsumption = value; } }
        public Engine Engine { get { return engine; } set { engine = value; } }
        public List<Tire> Tires { get { return tires; } set { tires = value; } }

        //methods
        public void Drive(double distance)
        {
            double needetfuel = distance * fuelConsumption;
            if (needetfuel < fuelQuantity)
            {
                fuelQuantity -= needetfuel;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }
        public string WhoAmI()
        {
            StringBuilder stringBuilder = new StringBuilder();


            stringBuilder.AppendLine($"Make: {this.Make}");
            stringBuilder.AppendLine($"Model: {this.Model}");
            stringBuilder.AppendLine($"Year: {this.Year}");
            stringBuilder.AppendLine($"Fuel: {this.FuelQuantity:F2}");
            stringBuilder.AppendLine($"Engine: {Environment.NewLine}{this.Engine.ShowEngine()}");
            stringBuilder.AppendLine($"Tires:");
            for (int i = 0; i < 4; i++)
            {
                stringBuilder.AppendLine($"-> Year: {this.Tires[i].Year}");
                stringBuilder.AppendLine($"-> Pressure: {this.Tires[i].Pressure}");
            }
            return stringBuilder.ToString();
        }
    }
}
