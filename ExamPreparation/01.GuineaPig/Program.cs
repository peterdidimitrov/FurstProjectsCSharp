using System;
using System.Numerics;

namespace _Problem1GuineaPig
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal quantityOfFoodInGrams = decimal.Parse(Console.ReadLine()) * 1000;
            decimal quantityOfHayInGrams = decimal.Parse(Console.ReadLine()) * 1000;
            decimal quantityOfCoverInGrams = decimal.Parse(Console.ReadLine()) * 1000;
            decimal weightInGrams = decimal.Parse(Console.ReadLine()) * 1000;

            decimal eatenFoodForMonthGrams = 0;
            decimal usedHayForMonthGrams = 0;
            decimal usedCoverForMonthGrams = 0;

            bool isTheFoodEnought = true;

            for (int i = 1; i <= 30; i++)
            {
                eatenFoodForMonthGrams += 300;
                if (i % 2 == 0)
                {
                    usedHayForMonthGrams += (quantityOfFoodInGrams - eatenFoodForMonthGrams) * (decimal)0.05;
                }
                if (i % 3 == 0)
                {
                    usedCoverForMonthGrams += Math.Round((weightInGrams / 3), 2, MidpointRounding.AwayFromZero);
                }
            }
            if (eatenFoodForMonthGrams >= quantityOfFoodInGrams ||
                    usedHayForMonthGrams >= quantityOfHayInGrams ||
                    usedCoverForMonthGrams >= quantityOfCoverInGrams)
            {
                isTheFoodEnought = false;
                Console.WriteLine("Merry must go to the pet store!");
                return;
            }
            if (isTheFoodEnought)
            {
                decimal excessFood = (quantityOfFoodInGrams - eatenFoodForMonthGrams) / 1000;
                decimal excessHay = (quantityOfHayInGrams - usedHayForMonthGrams) / 1000;
                decimal excessCover = (quantityOfCoverInGrams - usedCoverForMonthGrams) / 1000;

                Console.WriteLine($"Everything is fine! Puppy is happy! Food: {excessFood:f2}, Hay: {excessHay:f2}, Cover: {excessCover:f2}.");
            }
        }
    }
}