using System;

namespace _05.SpecialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int num = int.Parse(input);


            for (int i = 1; i <= num; i++)
            {
                int currentNum = i;
                int sum = 0;
                sum += currentNum % 10;
                sum += currentNum /= 10;

                bool isItSpecialNum;
                if (sum == 5 || sum == 7 || sum == 11)
                {
                    isItSpecialNum = true;
                }
                else
                {
                    isItSpecialNum = false;
                }


                Console.WriteLine($"{i} -> {isItSpecialNum}");
            }
        }
    }
}