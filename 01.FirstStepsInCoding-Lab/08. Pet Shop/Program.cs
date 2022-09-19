using System;

namespace _08._Pet_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numPackFoodForDogs = int.Parse(Console.ReadLine());
            int numPackFoodForCats = int.Parse(Console.ReadLine());
            
            double sum = (numPackFoodForDogs * 2.50) + (numPackFoodForCats * 4);
            
            Console.WriteLine($"{sum} lv.");
        }
    }
}
