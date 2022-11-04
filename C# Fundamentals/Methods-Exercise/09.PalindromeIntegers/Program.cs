using System;
using System.Linq;

namespace _09.PalindromeIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string numbers;
            numbers = IsPalindrom();
        }

        private static string IsPalindrom()
        {
            string numbers;
            while ((numbers = Console.ReadLine()) != "END")
            {
                string newString = new string(numbers.Reverse().ToArray());
                if (numbers == newString)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
            }

            return numbers;
        }
    }
}
