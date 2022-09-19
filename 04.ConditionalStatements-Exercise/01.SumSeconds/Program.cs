using System;

namespace _01.SumSeconds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int time1 = int.Parse(Console.ReadLine());
            int time2 = int.Parse(Console.ReadLine());
            int time3 = int.Parse(Console.ReadLine());

            int sum = time1 + time2 + time3;
            double minutes = sum / 60;
            double seconds = sum % 60;

            if (seconds < 10)
            {
                Console.WriteLine($"{Math.Floor(minutes)}:0{seconds}");
            }
            else
            {
                Console.WriteLine($"{Math.Floor(minutes)}:{seconds}");
            }
        }
    }
}