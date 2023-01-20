namespace _07.ParkingLot

{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            var carNumbers = new HashSet<string>();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] commArg = command.Split(", ");
                string direction = commArg[0];
                string carNumber = commArg[1];

                if (direction == "IN")
                {
                    carNumbers.Add(carNumber);
                }
                else
                {
                    carNumbers.Remove(carNumber);
                }
            }
            if (carNumbers.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var car in carNumbers)
                {
                    Console.WriteLine(car);
                }
            }
        }
    }
}
