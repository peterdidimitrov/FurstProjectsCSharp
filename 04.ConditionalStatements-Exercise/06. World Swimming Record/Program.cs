using System;

namespace _06.WorldSwimmingRecord
{
    public class Program
    {
        public static void Main(string[] args)
        {

            double recordInSec = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double timeInSecForOneMeter = double.Parse(Console.ReadLine());

            double totalTime = (distance * timeInSecForOneMeter) + (Math.Floor(distance / 15) * 12.5);
            double diff = totalTime - recordInSec;
            double formatDiff = Math.Abs(diff);

            if (recordInSec > totalTime)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {totalTime:F2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {formatDiff:F2} seconds slower.");
            }
        }
    }
}