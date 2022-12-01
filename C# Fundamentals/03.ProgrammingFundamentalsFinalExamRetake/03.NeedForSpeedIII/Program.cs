using System;
using System.Collections.Generic;

namespace _03.NeedForSpeedIII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var carMileage = new Dictionary<string, int>();
            var carFuel = new Dictionary<string, int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split("|", StringSplitOptions.RemoveEmptyEntries);
                string carName = carInfo[0];
                int mileage = int.Parse(carInfo[1]);
                int fuel = int.Parse(carInfo[2]);

                carMileage.Add(carName, mileage);
                carFuel.Add(carName, fuel);
            }
            string commands;
            while ((commands = Console.ReadLine()) != "Stop")
            {
                string[] commArg = commands
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                string currCommand = commArg[0];
                string carName = commArg[1];

                if (currCommand == "Drive")
                {
                    int distance = int.Parse(commArg[2]);
                    int fuel = int.Parse(commArg[3]);

                    if (carFuel[carName] < fuel)
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else
                    {
                        carMileage[carName] += distance;
                        carFuel[carName] -= fuel;
                        Console.WriteLine($"{carName} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                    }
                    if (carMileage[carName] >= 100000)
                    {
                        carMileage.Remove(carName);
                        carFuel.Remove(carName);
                        Console.WriteLine($"Time to sell the {carName}!");
                    }
                }
                else if (currCommand == "Refuel")
                {
                    int fuel = int.Parse(commArg[2]);
                    if (carFuel[carName] + fuel > 75)
                    {
                        Console.WriteLine($"{carName} refueled with {75 - carFuel[carName]} liters");
                        carFuel[carName] = 75;
                    }
                    else
                    {
                        carFuel[carName] += fuel;
                        Console.WriteLine($"{carName} refueled with {fuel} liters");
                    }
                }
                else if (currCommand == "Revert")
                {
                    int kilometers = int.Parse(commArg[2]);
                    if (carMileage[carName] - kilometers < 10000)
                    {
                        carMileage[carName] = 10000;
                    }
                    else
                    {
                        carMileage[carName] -= kilometers;
                        Console.WriteLine($"{carName} mileage decreased by {kilometers} kilometers");
                    }
                }
            }
            foreach (var car in carMileage)
            {
                int mileage = car.Value;
                int fuel = carFuel[car.Key];

                Console.WriteLine($"{car.Key} -> Mileage: {mileage} kms, Fuel in the tank: {fuel} lt.");
            }
        }
    }
}
