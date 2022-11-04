using System;

namespace _06.Oscars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double pointsFromAcademy = double.Parse(Console.ReadLine());
            int numAsses = int.Parse(Console.ReadLine());

            double totalPoints = pointsFromAcademy;
            bool isTheWiner = false;

            for (int i = 0; i < numAsses; i++)
            {
                string nameAsses = Console.ReadLine();
                double pointsFromAsses = double.Parse(Console.ReadLine());
                

                totalPoints += (nameAsses.Length * pointsFromAsses) / 2;

                if (totalPoints >= 1250.5)
                {
                    isTheWiner = true;
                    Console.WriteLine($"Congratulations, {name} got a nominee for leading role with {totalPoints:f1}!");
                    break;
                }

            }
            double diff = Math.Abs(totalPoints - 1250.5);
            if (!isTheWiner)
            {
                Console.WriteLine($"Sorry, {name} you need {diff:f1} more!");
            }
        }
    }
}
