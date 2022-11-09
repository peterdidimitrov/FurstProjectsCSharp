﻿using System;
using System.Text;

namespace _02.RepeatStrings
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();
            StringBuilder result = new StringBuilder();

            foreach (string word in words)
            {
                int count = word.Length;
                for (int i = 0; i < count; i++)
                {
                    result.Append(word);
                }
            }
            Console.Write(result);
        }
    }
}
