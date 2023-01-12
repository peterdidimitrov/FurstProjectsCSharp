namespace _8.TrafficJam
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            int greenCars = int.Parse(Console.ReadLine());
            int passedCars = 0;
            var cars = new Queue<string>();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "green")
                {
                    for (int i = 0; i < greenCars; i++)
                    {
                        if (cars.Count > 0)
                        {
                            string car = cars.Dequeue();
                            Console.WriteLine($"{car} passed!");
                            passedCars++;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }
            }
            Console.WriteLine($"{passedCars} cars passed the crossroads.");
        }
    }
}