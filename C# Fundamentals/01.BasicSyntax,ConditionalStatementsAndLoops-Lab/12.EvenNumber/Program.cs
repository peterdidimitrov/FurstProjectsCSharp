﻿using System;

namespace _12.EvenNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int number = int.Parse(Console.ReadLine());
                if (number < 0)
                {
                    number = Math.Abs(number);
                }
                if (number % 2 == 1)
                {
                    Console.WriteLine("Please write an even number.");
                }
                else
                {
                    Console.WriteLine($"The number is: {number}");
                    break;
                }
            }
        }
    }
}
