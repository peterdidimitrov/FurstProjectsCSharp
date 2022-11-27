using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.AdAstra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> foods = new List<string>();
            List<string> dates = new List<string>();
            List<int> calories = new List<int>();

            string pattern = @"([\||#])(?<item>[A-za-z\s]+)\1(?<date>\d{2}/\d{2}/\d{2})\1(?<calories>\d{1,5})\1";
            Regex regex = new Regex(pattern);

            string text = Console.ReadLine();
            int sumOfCalories = 0;


            MatchCollection validInputs = regex.Matches(text);
            foreach (Match product in validInputs)
            {
                string itemName = product.Groups["item"].Value;
                string date = product.Groups["date"].Value;
                int currCalories = int.Parse(product.Groups["calories"].Value);
                sumOfCalories += currCalories;
                foods.Add(itemName);
                dates.Add(date);
                calories.Add(currCalories);
            }
            int days = sumOfCalories / 2000;
            Console.WriteLine($"You have food to last you for: {days} days!");
            for (int i = 0; i < foods.Count; i++)
            {
                string item = foods[i];
                string date = dates[i];
                int currCalories = calories[i];
                Console.WriteLine($"Item: {item}, Best before: {date}, Nutrition: {currCalories}");

            }
        }
    }
}
