using System;

namespace _03.SantasHoliday
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int daysOfHoliday = (int.Parse(Console.ReadLine())) - 1;
            string typeOfRoom = Console.ReadLine();
            string asses = Console.ReadLine();

            double sum = 0;

            switch (typeOfRoom)
            {
                case "room for one person":
                        sum += daysOfHoliday * 18;
                    break;
                case "apartment":
                    if (daysOfHoliday < 10)
                    {
                        sum += (daysOfHoliday * 25) * 0.7;
                    }
                    else if (daysOfHoliday >= 10 && daysOfHoliday <= 15)
                    {
                        sum += (daysOfHoliday * 25) * 0.65;
                    }
                    else if (daysOfHoliday > 15)
                    {
                        sum += (daysOfHoliday * 25) * 0.5;
                    }
                    break;
                case "president apartment":
                    if (daysOfHoliday < 10)
                    {
                        sum += (daysOfHoliday * 35) * 0.9;
                    }
                    else if (daysOfHoliday >= 10 && daysOfHoliday <= 15)
                    {
                        sum += (daysOfHoliday * 35) * 0.85;
                    }
                    else if (daysOfHoliday > 15)
                    {
                        sum += (daysOfHoliday * 35) * 0.80;
                    }
                    break;
            }
            if (asses == "positive")
            {
                sum *= 1.25;
            }
            else
            {
                sum *= 0.90;
            }
            Console.WriteLine($"{sum:f2}");
        }
    }
}
