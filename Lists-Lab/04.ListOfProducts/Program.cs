﻿using System;
using System.Linq;
using System.Collections.Generic;

namespace _04.ListOfProducts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfProduct = int.Parse(Console.ReadLine());
            List<string> products = new List<string>();
            for (int i = 0; i < numOfProduct; i++)
            {
                products.Add(Console.ReadLine());
            }
            products.Sort();
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{products[i]}");

            }

        }
    }
}
