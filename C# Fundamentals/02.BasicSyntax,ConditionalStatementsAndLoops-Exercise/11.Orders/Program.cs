using System;

namespace _11.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
                //The output should consist of N + 1 line.For each order you must print a single line in the following format:
                    //•	"The price for the coffee is: ${price}"
                    //On the last line you need to print the total price in the following format:
                    //•	 "Total: ${totalPrice}"
            //The price must be formatted to 2 decimal places

            int countOfOrders = int.Parse(Console.ReadLine());
            double totalSum = 0;

            for (int n = 0; n < countOfOrders; n++)
            {
                double pricePerCapsule = double.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                int capsulesCount = int.Parse(Console.ReadLine());
                double currentSum = 0;
                currentSum += (days * capsulesCount) * pricePerCapsule;

                Console.WriteLine($"The price for the coffee is: ${currentSum:f2}");

                totalSum += currentSum;
            }
            Console.WriteLine($"Total: ${totalSum:f2}");
        }
    }
}
