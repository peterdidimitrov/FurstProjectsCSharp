using System;

namespace _04.CleverLily
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double priceForWashingMachine = double.Parse(Console.ReadLine());
            int priceForToy = int.Parse(Console.ReadLine());

            int toyCount = 0;
            int money = 0;
            int curentMoney = 10;

            for (int i = 1; i <= age; i++)
            {
                if (i % 2 != 0)
                {
                    toyCount++;
                }
                else
                {
                    money += curentMoney;
                    curentMoney += 10;
                    money--;
                }
            }
            money += toyCount * priceForToy;
            double diff = Math.Abs(money - priceForWashingMachine);

            if (money >= priceForWashingMachine)
            {
                Console.WriteLine($"Yes! {diff:f2}");
            }
            else
            {
                Console.WriteLine($"No! {diff:f2}");

            }
        }
    }
}
