using System;

namespace _07.WorkingHours
{
    public class Program
    {
        public static void Main(string[] args)
        {

            int houer = int.Parse(Console.ReadLine());
            string day = Console.ReadLine();
            if (houer >= 10 && houer <= 18)
            {
                switch (day)
                {
                    case "Monday":
                    case "Tuesday":
                    case "Wednesday":
                    case "Thursday":
                    case "Friday":
                    case "Saturday":
                        Console.WriteLine("open");
                        break;
                    case "Sunday":
                        Console.WriteLine("closed");
                        break;
                }

            }
            else
            {
                Console.WriteLine("closed");
            }
        }
    }
}