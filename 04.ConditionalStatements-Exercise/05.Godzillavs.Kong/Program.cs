using System;

namespace _05.Godzillavs.Kong
{
    public class Program
{
    public static void Main(string[] args)
    {

        double budget = double.Parse(Console.ReadLine());
        int statists = int.Parse(Console.ReadLine());
        double outfitPrice = double.Parse(Console.ReadLine());

        double deckor = budget * 0.10;
        double totalForOufit = statists * outfitPrice;
        if (statists > 150)
        {
            totalForOufit = totalForOufit * 0.90;
        }

        double sum = totalForOufit + deckor;
        double diff = budget - sum;
        double formatDiff = Math.Abs(diff);

        if (diff < 0)
        {
            Console.WriteLine("Not enough money!");
            Console.WriteLine($"Wingard needs {formatDiff:F2} leva more.");
        }
        else
        {
            Console.WriteLine("Action!");
            Console.WriteLine($"Wingard starts filming with {formatDiff:F2} leva left.");
        }
    }
}
}