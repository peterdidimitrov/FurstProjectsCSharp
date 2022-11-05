using System;

namespace _04.BackIn30Minutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int houer = int.Parse(Console.ReadLine());
            int minets = int.Parse(Console.ReadLine());

            int houerToMinets = houer * 60;
            int totalMinets = houerToMinets + minets;

            int timePlusMinets = totalMinets + 30;
            int newMinets = timePlusMinets % 60;
            double newHouer = timePlusMinets / 60;

            if (newHouer > 23)
            {
                newHouer = 0;
            }

            if (newMinets < 10)
            {
                Console.WriteLine($"{Math.Round(newHouer)}:0{newMinets}");
            }
            else
            {
                Console.WriteLine($"{Math.Round(newHouer)}:{newMinets}");
            }
        }
    }
}
