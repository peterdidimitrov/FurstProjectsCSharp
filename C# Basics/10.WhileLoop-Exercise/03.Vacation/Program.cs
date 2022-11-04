using System;

namespace _03.Vacation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            double moneyForTrip = double.Parse(Console.ReadLine());
            double money = double.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            double currentSum = double.Parse(Console.ReadLine());

            int days = 0;
            int spendDay = 0;

            while (true)
            {
                switch (command)
                {
                    case "spend":
                        money -= currentSum;
                        spendDay++;
                        days++;
                        if (currentSum > money)
                        {
                            money = 0;
                            break;
                        }
                        break;
                    case "save":
                        spendDay = 0;
                        days++;
                        money += currentSum;
                        break;
                }
                if (money >= moneyForTrip)
                {
                    Console.WriteLine($"You saved the money for {days} days.");
                    break;
                }
                if (spendDay == 5)
                {
                    Console.WriteLine("You can't save the money.");
                    Console.WriteLine(days);
                    break;
                }


                command = Console.ReadLine();
                currentSum = double.Parse(Console.ReadLine());
            }
        }
    }
}
