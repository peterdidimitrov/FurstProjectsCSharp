using System;

namespace _01.ConvertMetersToKilometers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double distanceInMeters = int.Parse(Console.ReadLine());
            double distanceInKilometers = distanceInMeters / 1000;

            Console.WriteLine($"{distanceInKilometers:f2}");
        }
    }
}
