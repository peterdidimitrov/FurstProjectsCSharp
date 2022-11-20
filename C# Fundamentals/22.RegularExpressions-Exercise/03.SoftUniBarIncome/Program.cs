using System;
using System.Text.RegularExpressions;

namespace _03.SoftUniBarIncome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var regex = @"^[^\%\$\.\|]*?\%(?<customer>[A-z][a-z]+)\%[^\%\$\.\|]*?\<(?<product>\w+)\>[^\%\$\.\|]*?\|(?<count>\d+)\|[^\%\$\.\|]*?(?<price>\d+(\.\d+)?)\$[^\%\$\.\|]*?$";
            double incom = 0;
            string input;

            //Console.WriteLine("Bought furniture:");
            while ((input = Console.ReadLine()) != "end of shift")
            {
                var purchase = Regex.Matches(input, regex);

                foreach (Match item in purchase)
                {
                    var customer = item.Groups["customer"].Value;
                    var product = item.Groups["product"].Value;
                    var count = item.Groups["count"].Value;
                    var price = item.Groups["price"].Value;
                    

                    double totalPrice = double.Parse(price) * int.Parse(count);
                    incom += totalPrice;

                    Console.WriteLine($"{customer}: {product} - {totalPrice:f2}");
                }
            }
            Console.WriteLine($"Total income: {incom:f2}");
        }
    }
}
