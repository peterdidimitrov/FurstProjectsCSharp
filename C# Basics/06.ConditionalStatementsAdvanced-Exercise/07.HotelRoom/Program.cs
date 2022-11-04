using System;

namespace _07.HotelRoom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());

            double priceForStudio = 0;
            double priceForApartment = 0;

            switch (month)
            {
                case "May":
                case "October":
                    priceForStudio = nights * 50;
                    priceForApartment = nights * 65;
                    if (nights > 7 && nights <= 14)
                    {
                        priceForStudio *= 0.95;
                    }
                    else if (nights > 14)
                    {
                        priceForStudio *= 0.70;
                        priceForApartment *= 0.90;
                    }
                    break;
                case "June":
                case "September":
                    priceForStudio = nights * 75.20;
                    priceForApartment = nights * 68.70;
                    if (nights > 14)
                    {
                        priceForStudio *= 0.80;
                        priceForApartment *= 0.90;
                    }
                    break;
                case "July":
                case "August":
                    priceForStudio = nights * 76;
                    priceForApartment = nights * 77;
                    if (nights > 14)
                    {
                        priceForApartment *= 0.90;
                    }
                    break;
            }
            Console.WriteLine($"Apartment: {priceForApartment:f2} lv.");
            Console.WriteLine($"Studio: {priceForStudio:f2} lv.");
        }
    }
}
