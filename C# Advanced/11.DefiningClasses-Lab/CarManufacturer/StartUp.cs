using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            string line = string.Empty;

            List<Tire> tires = new List<Tire>();

            while ((line = Console.ReadLine()) != "No more tires")
            {
                double[] tiresArg = line
                .Split().Select(double.Parse).ToArray();

                for (int i = 0; i < tiresArg.Length; i += 2)
                {
                    int year = (int)tiresArg[i];
                    double pressure = tiresArg[i + 1];
                    var tire = new Tire(year, pressure);
                    tires.Add(tire);
                }
            }

            var engine = new Engine(0, 0);
            string lineEngine = string.Empty;
            while ((lineEngine = Console.ReadLine()) != "Engines done")
            {
                double[] engineArg = lineEngine
                .Split().Select(double.Parse).ToArray();
                engine.HorsePower = (int)engineArg[0];
                engine.CubicCapacity = engineArg[1];
            }
            var car = new Car("Lanmborgini", "Urus", 2010, 250, 9, engine, tires);
            Console.WriteLine(car.WhoAmI());
        }
    }
}