using System;

namespace _08.CinemaTicket
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string day = Console.ReadLine();

            switch (day)
            {
                case "Monday":
                case "Tuesday":
                case "Friday":

                    Console.WriteLine("12");
                    break;
                case "Wednesday":
                case "Thursday":
                    Console.WriteLine("14");
                    break;
                case "Sunday":
                case "Saturday":
                    Console.WriteLine("16");
                    break;
            }
        }
    }
}