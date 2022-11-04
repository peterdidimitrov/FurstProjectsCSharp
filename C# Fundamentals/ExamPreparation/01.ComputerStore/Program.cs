using System;

namespace _01.ComputerStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command;
            double totalPrice = 0;
            double totalTaxes = 0;
            bool isOrderInvalid = false;

            while (true)
            {
                command = Console.ReadLine();
                if (command == "special" || command == "regular")
                {
                    break;
                }
                double price = double.Parse(command);
                if (price < 0)
                {
                    Console.WriteLine("Invalid price!");
                    continue;
                }
                totalPrice += price;
            }
            if (totalPrice == 0)
            {
                Console.WriteLine("Invalid order!");
                isOrderInvalid = true;
            }
            totalTaxes = totalPrice * 0.2;
            double totalPriceWhitTaxes = totalTaxes + totalPrice;

            if (command == "special")
            {
                totalPriceWhitTaxes *= 0.9;
            }
            if (!isOrderInvalid)
            {
                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {totalPrice:f2}$");
                Console.WriteLine($"Taxes: {totalTaxes:f2}$");
                Console.WriteLine($"-----------");
                Console.WriteLine($"Total price: {totalPriceWhitTaxes:f2}$");
            }
        }
    }
}