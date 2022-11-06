using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var products = new Dictionary<string, List<double>>();

            string input;
            while ((input = Console.ReadLine()) != "buy")
            {
                string[] productsArg = input.Split(" ");
                string name = productsArg[0];
                double price = double.Parse(productsArg[1]);
                int quantity = int.Parse(productsArg[2]);

                if (!products.ContainsKey(name))
                {
                    products.Add(name, new List<double>());
                    products[name].Add(price);
                    products[name].Add(quantity);

                }
                else
                {
                    products[name][1] += quantity;
                    if (products[name][0] != price)
                    {
                        products[name][0] = price;
                    }
                }
            }
            foreach (var item in products)
            {
                double totalPrice = products[item.Key][0] * products[item.Key][1];
                Console.WriteLine($"{item.Key} -> {totalPrice:f2}");

            }
        }
    }
}
