using System;
using System.Collections.Generic;
using System.Numerics;

namespace _02.AMinerTask
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var resources = new Dictionary<string, BigInteger>();
            
            string input;
            
            while ((input = Console.ReadLine()) != "stop")
            {
                if (!resources.ContainsKey(input))
                {
                    resources.Add(input, BigInteger.Parse(Console.ReadLine()));
                }
                else
                {
                    resources[input] = BigInteger.Parse(Console.ReadLine()) + resources[input];
                }
            }
            foreach (var item in resources)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
