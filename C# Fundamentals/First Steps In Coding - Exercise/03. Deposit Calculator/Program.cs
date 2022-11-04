using System;

namespace _03._Deposit_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double deposit = double.Parse(Console.ReadLine());
            double term = double.Parse(Console.ReadLine());
            double persent = double.Parse(Console.ReadLine());

            double sum = deposit + term * ((deposit * (persent / 100)) / 12);

            Console.WriteLine(sum);
        }
    }
}
