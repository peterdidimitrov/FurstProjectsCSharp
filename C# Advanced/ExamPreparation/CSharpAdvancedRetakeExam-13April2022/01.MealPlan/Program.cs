using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.MealPlan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> meals = new Queue<string>(Console.ReadLine()
                .Split(" "));

            Stack<int> calories = new Stack<int>(Console.ReadLine()
                .Split(" ").Select(int.Parse));

            int countOfMeals = 0;

            int calForNextDay = 0;

            Dictionary<string, int> mealsCal = new Dictionary<string, int>();
            mealsCal.Add("salad", 350);
            mealsCal.Add("soup", 490);
            mealsCal.Add("pasta", 680);
            mealsCal.Add("steak", 790);

            while (meals.Any() && calories.Any())
            {
                int currentMealCal = mealsCal[meals.Dequeue()];
                int decreasedCal = calories.Pop() - currentMealCal;
                calories.Push(decreasedCal);

                countOfMeals++;

                if (calories.Peek() < 0)
                {
                    calForNextDay = Math.Abs(calories.Pop());
                    if (calories.Any())
                    {
                        int temp = calories.Pop() - calForNextDay;
                        calories.Push(temp);
                    }
                }
                else if (calories.Peek() == 0)
                {
                    calories.Pop();
                }
            }

            if (!meals.Any())
            {
                Console.WriteLine($"John had {countOfMeals} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", calories)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {countOfMeals} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
            }
        }
    }
}
