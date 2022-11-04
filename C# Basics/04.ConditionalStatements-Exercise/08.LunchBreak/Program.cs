using System;

namespace _08.LunchBreak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double durationOtMovie = double.Parse(Console.ReadLine());
            double durationOfAllBreak = double.Parse(Console.ReadLine());
            
            double durationOfLunch = durationOfAllBreak / 8;
            double durationOfBreak = durationOfAllBreak / 4;
            
            double diff = durationOfAllBreak - durationOtMovie - durationOfBreak - durationOfLunch;
            double formatDiff = Math.Abs(diff);

            if (diff >= 0)
            {
                Console.WriteLine($"You have enough time to watch {name} and left with {Math.Ceiling(formatDiff)} minutes free time.");
            } else
            {
                Console.WriteLine($"You don't have enough time to watch {name}, you need {Math.Ceiling(formatDiff)} more minutes.");
            }
            
        }
    }
}
