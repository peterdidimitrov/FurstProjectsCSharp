using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Motorcycle motor = new(10, 10);
            Console.WriteLine(motor.Fuel);
            Car car = new(100, 8.5);

            Console.WriteLine(car.Fuel);
            Console.WriteLine(motor.Fuel);
            CrossMotorcycle cross = new(100, 30);
            Console.WriteLine(cross.FuelConsumption);

            car.Drive(50.5);

            Console.WriteLine(car.Fuel);
        }
    }
}