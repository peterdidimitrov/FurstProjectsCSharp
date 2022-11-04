using System;

namespace _11.FruitShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string day = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());
            bool isWeekend = (day == "Saturday") || (day == "Sunday");
            bool isNotWeekend = (day == "Monday") || (day == "Tuesday") || (day == "Wednesday") || (day == "Thursday") || (day == "Friday");

            double sum = 0;
            if (isNotWeekend)
            {
                switch (product)
                {
                    case "banana":
                        sum += quantity * 2.5;
                        break;
                    case "apple":
                        sum += quantity * 1.20;
                        break;
                    case "orange":
                        sum += quantity * 0.85;
                        break;
                    case "grapefruit":
                        sum += quantity * 1.45;
                        break;
                    case "kiwi":
                        sum += quantity * 2.70;
                        break;
                    case "pineapple":
                        sum += quantity * 5.5;
                        break;
                    case "grapes":
                        sum += quantity * 3.85;
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
                if (sum != 0)
                {
                    Console.WriteLine($"{sum:f2}");
                }

            }
            else if (isWeekend)
            {
                switch (product)
                {
                    case "banana":
                        sum += quantity * 2.7;
                        break;
                    case "apple":
                        sum += quantity * 1.25;
                        break;
                    case "orange":
                        sum += quantity * 0.90;
                        break;
                    case "grapefruit":
                        sum += quantity * 1.60;
                        break;
                    case "kiwi":
                        sum += quantity * 3;
                        break;
                    case "pineapple":
                        sum += quantity * 5.6;
                        break;
                    case "grapes":
                        sum += quantity * 4.2;
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
                if (sum != 0)
                {
                    Console.WriteLine($"{sum:f2}");
                }
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}