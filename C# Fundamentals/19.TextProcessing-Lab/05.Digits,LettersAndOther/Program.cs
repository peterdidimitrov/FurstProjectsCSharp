﻿using System;
using System.Text;

namespace _05.Digits_LettersAndOther
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string text = Console.ReadLine();

            StringBuilder digits = new StringBuilder();
            StringBuilder letters = new StringBuilder();
            StringBuilder other = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsDigit(text[i]))
                {
                    digits.Append(text[i]);
                }
                else if (char.IsLetter(text[i]))
                {
                    letters.Append(text[i]);
                }
                else
                {
                    other.Append(text[i]);
                }
            }

            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.Write(other);
        }
    }
}
