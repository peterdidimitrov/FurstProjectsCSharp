using System;
using System.Collections.Generic;

namespace _01.CountCharsInAString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine()
                .Split();

            var letters = new Dictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                string currentText = text[i];
                for (int z = 0; z < currentText.Length; z++)
                {
                    char sumbol = currentText[z];
                    if (!letters.ContainsKey(sumbol))
                    {
                        letters.Add(sumbol, 1);
                    }
                    else
                    {
                        letters[sumbol]++;
                    }
                }
            }
            foreach (var item in letters)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");

            }
        }
    }
}
