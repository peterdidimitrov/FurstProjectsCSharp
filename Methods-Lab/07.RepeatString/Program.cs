using System;

namespace _07.RepeatString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();
            int timesRepetition = int.Parse(Console.ReadLine());

            string result = RepeatStrimg(inputString, timesRepetition);

            Console.WriteLine(result);
        }

        static string RepeatStrimg(string inputString, int timesRepetition)
        {
            string result = string.Empty;
            for (int i = 0; i < timesRepetition; i++)
            {
                result += inputString;
            }
            return result;
        }
    }
}
