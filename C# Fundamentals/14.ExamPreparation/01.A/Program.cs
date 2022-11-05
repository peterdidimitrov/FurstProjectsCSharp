using System;
using System.Numerics;
using System.Linq;

namespace _01.A
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dayNum = int.Parse(Console.ReadLine());
            int playersNum = int.Parse(Console.ReadLine());
            decimal energy = decimal.Parse(Console.ReadLine());

            decimal waterPerDayForOnePerson = decimal.Parse(Console.ReadLine());
            decimal foodPerDayForOnePerson = decimal.Parse(Console.ReadLine());

            decimal totalFood = dayNum * playersNum * foodPerDayForOnePerson;
            decimal totalWater = dayNum * playersNum * waterPerDayForOnePerson;

            for (int i = 1; i <= dayNum; i++)
            {
                decimal energyLoss = decimal.Parse(Console.ReadLine());
                energy -= energyLoss;
                if (energy <= 0)
                {
                    Console.WriteLine($"You will run out of energy. You will be left with {totalFood:f2} food and {totalWater:f2} water.");
                    return;
                }
                if (i % 2 == 0)
                {
                    energy += energy * 0.05m;
                    totalWater -= totalWater * 0.30m;
                }
                if (i % 3 == 0)
                {
                    energy += energy * 0.10m;
                    totalFood -= totalFood / playersNum;
                }
                //Console.WriteLine(energy);
            }
            if (energy > 0)
            {
                Console.WriteLine($"You are ready for the quest. You will be left with - {energy:f2} energy!");
            }
        }
    }
}
