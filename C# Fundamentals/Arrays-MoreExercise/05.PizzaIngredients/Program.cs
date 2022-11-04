using System;
using System.Linq;
namespace _05.PizzaIngredients
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] ingredients = Console.ReadLine().Split(' ');

            int searchedLenght = int.Parse(Console.ReadLine());

            int ingredientCounter = 0;

            string ingredientsInPizza = string.Empty;

            for (int i = 0; i < ingredients.Length; i++)
            {
                string currentIngredient = ingredients[i];
                if (ingredientCounter == 10)
                {
                    return;
                }
                if (currentIngredient.Length == searchedLenght)
                {
                    ingredientCounter++;
                    ingredientsInPizza += $"{currentIngredient} ";
                    Console.WriteLine($"Adding {currentIngredient}");
                }

            }
            string[] ingredientsInPizzaArray = ingredientsInPizza.Split(" ",StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine($"Made pizza with total of {ingredientCounter} ingredients.");
            Console.WriteLine($"The ingredients are: {string.Join(" ", ingredientsInPizzaArray)}.");
        }
    }
}
