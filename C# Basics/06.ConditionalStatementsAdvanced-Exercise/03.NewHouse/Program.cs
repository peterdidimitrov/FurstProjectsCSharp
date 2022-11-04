using System;

namespace _03.NewHouse
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int numFlouers = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double sum = 0;

            switch (type)
            {
                case "Roses":
                    sum += numFlouers * 5;
                    if (numFlouers > 80)
                    {
                        sum = sum * 0.90;
                    }
                    break;
                case "Dahlias":
                    sum += numFlouers * 3.80;
                    if (numFlouers > 90)
                    {
                        sum = sum * 0.85;
                    }
                    break;
                case "Tulips":
                    sum += numFlouers * 2.80;
                    if (numFlouers > 80)
                    {
                        sum = sum * 0.85;
                    }
                    break;
                case "Narcissus":
                    sum += numFlouers * 3;
                    if (numFlouers < 120)
                    {
                        sum = sum * 1.15;
                    }
                    break;
                case "Gladiolus":
                    sum += numFlouers * 2.50;
                    if (numFlouers < 80)
                    {
                        sum = sum * 1.20;
                    }
                    break;
            }

            double diff = budget - sum;
            if (budget >= sum)
            {
                Console.WriteLine($"Hey, you have a great garden with {numFlouers} {type} and {diff:f2} leva left.");
            }
            else
            {
                double fomatDiff = Math.Abs(diff);
                Console.WriteLine($"Not enough money, you need {fomatDiff:f2} leva more.");
            }

        }
    }
}