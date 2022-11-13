namespace _02.CharacterMultiplier
{
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string str1 = input[0];
            string str2 = input[1];
            int sum = GetStringSum(str1, str2);
            Console.WriteLine(sum);
        }

        private static int GetStringSum(string str1, string str2)
        {
            int sum = 0;

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
            return sum;
        }
    }
}
