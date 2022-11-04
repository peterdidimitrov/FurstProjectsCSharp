using System;

namespace _05.Journey
{
    internal class Program
    {
        static void Main(string[] args)
        {
           double budget = double.Parse(Console.ReadLine());
           string season = Console.ReadLine();
           string destination = "";
           string typeTrip = "";

           if (budget <= 100)
           {
                destination = "Bulgaria";
                switch (season)
                {
                    case "summer":
                        typeTrip = "Camp";
                        budget *= 0.30;
                        break;
                    case "winter":
                        typeTrip = "Hotel";
                        budget *= 0.70;
                        break;
                }
           }
           else if (budget > 100 && budget <= 1000)
           {
                destination = "Balkans";
                switch (season)
                {
                    case "summer":
                        typeTrip = "Camp";
                        budget *= 0.40;
                        break;
                    case "winter":
                        typeTrip = "Hotel";
                        budget *= 0.80;
                        break;
                }
            }
            else if (budget > 1000)
            {
                destination = "Europe";
                typeTrip = "Hotel";
                budget *= 0.90;
            }
            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{typeTrip} - {budget:f2}");
        }
    }
}
