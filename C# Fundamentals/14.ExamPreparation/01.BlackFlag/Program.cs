using System;

namespace _01.BlackFlag
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int dailyPlunder = int.Parse(Console.ReadLine());
            double expectedPlunder = double.Parse(Console.ReadLine());

            double actualPlunder = 0;

            for (int i = 1; i <= days; i++)
            {
                actualPlunder += dailyPlunder;
                if (i % 3 == 0)
                {
                    actualPlunder += dailyPlunder * 0.5;
                }
                if (i % 5 == 0)
                {
                    actualPlunder *= 0.70;
                }
            }
            if (actualPlunder >= expectedPlunder)
            {
                Console.WriteLine($"Ahoy! {actualPlunder:f2} plunder gained.");
            }
            else
            {
                double persent = actualPlunder / expectedPlunder * 100;
                Console.WriteLine($"Collected only {persent:f2}% of the plunder.");
            }
        }
    }
}
