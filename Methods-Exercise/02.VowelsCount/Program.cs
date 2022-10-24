using System;

namespace _02.VowelsCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int result = CountTheVowels(input);
        }
        static string CountTheVowels(string input, int result)
        {
            int result = 0;
            input = input.ToLower();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i])
                {

                }

            }
            return result;
        }
    }
}
