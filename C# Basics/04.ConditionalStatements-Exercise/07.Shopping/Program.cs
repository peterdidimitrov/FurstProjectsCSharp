using System;

namespace _07.Shopping
{
    public class Program
    {
        public static void Main(string[] args)
        {

            double budget = double.Parse(Console.ReadLine());
            int videoCard = int.Parse(Console.ReadLine());
            int procesors = int.Parse(Console.ReadLine());
            int RAM = int.Parse(Console.ReadLine());

            int priceForVideoCard = 250;
            double sumVideoCard = priceForVideoCard * videoCard;

            double priceForProcesor = sumVideoCard * 0.35;
            double priceForRAM = sumVideoCard * 0.10;


            double totalSum = sumVideoCard + priceForProcesor * procesors + priceForRAM * RAM;
            if (videoCard > procesors)
            {
                totalSum = totalSum * 0.85;
            }
            double diff = totalSum - budget;
            double formatDiff = Math.Abs(diff);

            if (budget >= totalSum)
            {
                Console.WriteLine($"You have {formatDiff:F2} leva left!");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {formatDiff:F2} leva more!");
            }
        }
    }
}