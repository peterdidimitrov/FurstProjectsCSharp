using System;
using System.Numerics;
namespace _02.CharacterMultiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            
            string str1 = input[0];
            string str2 = input[1];

            BigInteger sum = 0;

            if (str1.Length >= str2.Length)
            {
                for (int i = 0; i < str2.Length; i++)
                {
                    sum += (int)str1[i] * (int)str2[i];
                }
                for (int i = str2.Length; i < str1.Length; i++)
                {
                    sum += (int)str1[i];
                }
            }
            else
            {
                for (int i = 0; i < str1.Length; i++)
                {
                    sum += (int)str1[i] * (int)str2[i];
                }
                for (int i = str1.Length; i < str2.Length; i++)
                {
                    sum += (int)str2[i];
                }
            }
            Console.WriteLine(sum);
        }
    }
}
