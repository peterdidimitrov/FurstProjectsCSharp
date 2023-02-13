using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Barista3._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> coffeeQuantities = new Queue<int>(Console.ReadLine()
                .Split(", ").Select(int.Parse));

            Stack<int> milkQuantities = new Stack<int>(Console.ReadLine()
                .Split(", ").Select(int.Parse));

            Dictionary<int, string> coffeeDrinks = new Dictionary<int, string>();
            Dictionary<string, int> makedDrinks = new Dictionary<string, int>();

            coffeeDrinks.Add(50, "Cortado");
            coffeeDrinks.Add(75, "Espresso");
            coffeeDrinks.Add(100, "Capuccino");
            coffeeDrinks.Add(150, "Americano");
            coffeeDrinks.Add(200, "Latte");
            while (coffeeQuantities.Any() && milkQuantities.Any())
            {
                int sumOfQuantities = coffeeQuantities.Peek() + milkQuantities.Peek();
                if (coffeeDrinks.ContainsKey(sumOfQuantities))
                {
                    string currDrink = coffeeDrinks[sumOfQuantities];
                    if (!makedDrinks.ContainsKey(currDrink))
                    {
                        makedDrinks.Add(currDrink, 1);
                    }
                    else
                    {
                        makedDrinks[currDrink]++;
                    }
                    coffeeQuantities.Dequeue();
                    milkQuantities.Pop();
                }
                else
                {
                    coffeeQuantities.Dequeue();
                    int temp = milkQuantities.Pop() - 5;
                    milkQuantities.Push(temp);
                }
            }

            if (coffeeQuantities.Any() || milkQuantities.Any())
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }

            if (!coffeeQuantities.Any())
            {
                Console.WriteLine("Coffee left: none");
            }
            else
            {
                Console.WriteLine($"Coffee left: {string.Join(", ", coffeeQuantities)}");
            }
            if (!milkQuantities.Any())
            {
                Console.WriteLine("Milk left: none");
            }
            else
            {
                Console.WriteLine($"Milk left: {string.Join(", ", milkQuantities)}");
            }
            foreach (var drink in makedDrinks.OrderBy(x => x.Value).ThenByDescending(x => x.Key))
            {
                string name = drink.Key;
                int count = drink.Value;
                Console.WriteLine($"{name}: {count}");
            }
        }
    }
}
