using System;

namespace _01.Cinema
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int numRows = int.Parse(Console.ReadLine());
            int numColums = int.Parse(Console.ReadLine());

            double income = 0;
            int totalSeats = numRows * numColums;

            switch (type)
            {
                case "Premiere":
                    income += totalSeats * 12;
                    break;
                case "Normal":
                    income += totalSeats * 7.5;
                    break;
                case "Discount":
                    income += totalSeats * 5;
                    break;
            }
            Console.WriteLine($"{income:f2} leva");
        }
    }
}