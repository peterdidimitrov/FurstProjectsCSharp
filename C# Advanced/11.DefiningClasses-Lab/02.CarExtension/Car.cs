﻿using System.Text;

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

        //propurties
        public string Make { get { return make; } set { make = value; } }
        public string Model { get { return model; } set { model = value; } }
        public int Year { get { return year; } set { year = value; } }
        public double FuelQuantity { get { return fuelQuantity; } set { fuelQuantity = value; } }
        public double FuelConsumption { get { return fuelConsumption; } set { fuelConsumption = value; } }
        
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
            return stringBuilder.ToString();
        }
    }
}
