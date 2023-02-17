using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BakeryShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<double> water = new Queue<double>(Console.ReadLine()
                .Split(" ").Select(double.Parse));

            Stack<double> flour = new Stack<double>(Console.ReadLine()
                .Split(" ").Select(double.Parse));

            Dictionary<string, int> orderedProducts = new Dictionary<string, int>();

            while (water.Any() && flour.Any())
            {
                if ((water.Peek() * 100 / (water.Peek() + flour.Peek()) == 50))
                {
                    water.Dequeue();
                    flour.Pop();

                    if (!orderedProducts.ContainsKey("Croissant"))
                    {
                        orderedProducts.Add("Croissant", 1);
                    }
                    else
                    {
                        orderedProducts["Croissant"]++;
                    }
                }
                else if ((water.Peek() * 100 / (water.Peek() + flour.Peek()) == 40))
                {
                    water.Dequeue();
                    flour.Pop();

                    if (!orderedProducts.ContainsKey("Muffin"))
                    {
                        orderedProducts.Add("Muffin", 1);
                    }
                    else
                    {
                        orderedProducts["Muffin"]++;
                    }
                }
                else if ((water.Peek() * 100 / (water.Peek() + flour.Peek()) == 30))
                {
                    water.Dequeue();
                    flour.Pop();

                    if (!orderedProducts.ContainsKey("Baguette"))
                    {
                        orderedProducts.Add("Baguette", 1);
                    }
                    else
                    {
                        orderedProducts["Baguette"]++;
                    }
                }
                else if ((water.Peek() * 100 / (water.Peek() + flour.Peek()) == 20))
                {
                    water.Dequeue();
                    flour.Pop();

                    if (!orderedProducts.ContainsKey("Bagel"))
                    {
                        orderedProducts.Add("Bagel", 1);
                    }
                    else
                    {
                        orderedProducts["Bagel"]++;
                    }
                }
                else
                {
                    double remaningFlour = flour.Pop() - water.Dequeue();
                    flour.Push(remaningFlour);

                    if (!orderedProducts.ContainsKey("Croissant"))
                    {
                        orderedProducts.Add("Croissant", 1);
                    }
                    else
                    {
                        orderedProducts["Croissant"]++;
                    }
                }
            }

            foreach (var product in orderedProducts.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{product.Key}: {product.Value}");
            }

            if (!water.Any())
            {
                Console.WriteLine("Water left: None");
            }
            else
            {
                Console.WriteLine($"Water left: {string.Join(", ", water)}");
            }

            if (!flour.Any())
            {
                Console.WriteLine("Flour left: None");
            }
            else
            {
                Console.WriteLine($"Flour left: {string.Join(", ", flour)}");
            }
        }
    }
}