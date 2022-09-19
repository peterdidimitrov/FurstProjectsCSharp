using System;

namespace _04.FishingBoat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int numFishman = int.Parse(Console.ReadLine());

            double rentTax = 0;
            bool isSeasonAutumn = false;

            switch (season)
            {
                case "Spring":
                    rentTax = 3000;
                    break;
                case "Summer":
                    rentTax = 4200;
                    break;
                case "Autumn":
                    isSeasonAutumn = true;
                    rentTax = 4200;
                    break;
                case "Winter":
                    rentTax = 2600;
                    break;
            }
            if (numFishman <= 6)
            {
                rentTax *= 0.9;
            }
            else if (numFishman > 7 && numFishman <= 11)
            {
                rentTax *= 0.85;
            }
            else if (numFishman > 12)
            {
                rentTax *= 0.75;
            }
            if (!isSeasonAutumn)
            {
                if (numFishman % 2 == 0)
                {
                    rentTax *= 0.95;
                }
            }
            double diff = budget - rentTax;
            if (diff >= 0)
            {
                Console.WriteLine($"Yes! You have {diff} leva left.");
            }
            else
            {
                double formatDiff = Math.Abs(diff);
                Console.WriteLine($"Not enough money! You need {formatDiff:f2} leva.");
            }
        }
    }
}
