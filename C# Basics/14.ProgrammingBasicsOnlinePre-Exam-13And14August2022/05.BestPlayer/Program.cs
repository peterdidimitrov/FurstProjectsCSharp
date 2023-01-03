using System;

namespace _05.BestPlayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double max = 0;
            string bestPlayer = " ";
            string command = Console.ReadLine();
            while (command != "END")
            {
                int goal = int.Parse(Console.ReadLine());

                if (goal > max)
                {
                    max = goal;
                    bestPlayer = command;
                }
                if (max >= 10)
                {
                    break;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"{bestPlayer} is the best player!");

            if (max >= 3)
            {
                Console.WriteLine($"He has scored {max} goals and made a hat-trick !!!");
            }
            else
            {
                Console.WriteLine($"He has scored {max} goals.");
            }
        }
    }
}
