using System;

namespace _04.ToyShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double priceForTheTrip = double.Parse(Console.ReadLine());
            int puzelsNum = int.Parse(Console.ReadLine());
            int dollsNum = int.Parse(Console.ReadLine());
            int bearsNum = int.Parse(Console.ReadLine());
            int minionsNum = int.Parse(Console.ReadLine());
            int trucksNum = int.Parse(Console.ReadLine());

            int countToys = puzelsNum + dollsNum + bearsNum + minionsNum + trucksNum;
            double sum = puzelsNum * 2.60 + dollsNum * 3 + bearsNum * 4.10 + minionsNum * 8.20 + trucksNum * 2;

            if (countToys >= 50)
            {
                sum = sum * 0.75;
            }

            double totalSum = sum * 0.90;
            double diff = totalSum - priceForTheTrip;

            if (diff >= 0)
            {
                Console.WriteLine($"Yes! {diff:F2} lv left.");
            } else
            {
                double money = Math.Abs(diff);
                Console.WriteLine($"Not enough money! {money:F2} lv needed.");
            }            
        }
    }
}
