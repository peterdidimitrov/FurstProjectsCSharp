using System;

namespace _12.TradeCommissions
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string city = Console.ReadLine();
            double sails = double.Parse(Console.ReadLine());

            double comision = 0;

            switch (city)
            {
                case "Sofia":
                    if (sails >= 0 && sails <= 500)
                    {
                        comision += sails * 0.05;
                    }
                    else if (sails > 500 && sails <= 1000)
                    {
                        comision += sails * 0.07;
                    }
                    else if (sails > 1000 && sails <= 10000)
                    {
                        comision += sails * 0.08;
                    }
                    else if (sails > 10000)
                    {
                        comision += sails * 0.12;
                    }
                    break;
                case "Varna":
                    if (sails >= 0 && sails <= 500)
                    {
                        comision += sails * 0.045;
                    }
                    else if (sails > 500 && sails <= 1000)
                    {
                        comision += sails * 0.075;
                    }
                    else if (sails > 1000 && sails <= 10000)
                    {
                        comision += sails * 0.1;
                    }
                    else if (sails > 10000)
                    {
                        comision += sails * 0.13;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;
                case "Plovdiv":
                    if (sails >= 0 && sails <= 500)
                    {
                        comision += sails * 0.055;
                    }
                    else if (sails > 500 && sails <= 1000)
                    {
                        comision += sails * 0.08;
                    }
                    else if (sails > 1000 && sails <= 10000)
                    {
                        comision += sails * 0.12;
                    }
                    else if (sails > 10000)
                    {
                        comision += sails * 0.145;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;
                default:
                    Console.WriteLine("error");
                    break;
            }
            if (comision != 0)
            {
                Console.WriteLine($"{comision:f2}");
            }
        }
    }
}