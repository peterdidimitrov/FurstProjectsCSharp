using System;

namespace _09.SkiTrip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string typeRoom = Console.ReadLine();
            string assessment = Console.ReadLine();
            
            int nights = days - 1;
            double sum = 0;

            switch (typeRoom)
            {
                case "room for one person":
                    sum = nights * 18;
                    break;
                case "apartment":
                    sum = nights * 25;
                    if (nights < 10)
                    {
                        sum *= 0.70;
                    }
                    else if (nights >= 10 && nights <= 15)
                    {
                        sum *= 0.65;
                    }
                    else if (nights > 15)
                    {
                        sum *= 0.50;
                    }
                    break;
                case "president apartment":
                    sum = nights * 35;
                    if (nights < 10)
                    {
                        sum *= 0.90;
                    }
                    else if (nights >= 10 && nights <= 15)
                    {
                        sum *= 0.85;
                    }
                    else if (nights > 15)
                    {
                        sum *= 0.80;
                    }
                    break;
            }
            if (assessment == "positive")
            {
                sum *= 1.25;
            }
            else if (assessment == "negative")
            {
                sum *= 0.90;
            }
            Console.WriteLine($"{sum:f2}");
        }
    }
}
