using System;

namespace _02.BonusScore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            double bonus = 0;
            double sum = 0;
            if (num <= 100)
            {
                bonus += 5;
            }
            else if (num > 100 && num <= 1000)
            {
                bonus = num * 0.2;
            }
            else if (num > 1000)
            {
                bonus = num * 0.1;
            }

            if (num % 2 == 0)
            {
                bonus += 1;
            }
            if (num % 10 == 5)
            {
                bonus += 2;
            }
            sum = bonus + num;

            Console.WriteLine(bonus);
            Console.WriteLine(sum);

        }
    }
}