using System;

namespace _07.Moving
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int higth = int.Parse(Console.ReadLine());
            int volume = width * length * higth;

            double sum = 0;
            bool isTheSpaseEnought = true;

            string command = Console.ReadLine();
            while (command != "Done")
            {
                int boxesNum = int.Parse(command);

                sum += boxesNum;
                if (volume < sum)
                {
                    isTheSpaseEnought = false;

                    break;
                }

                command = Console.ReadLine();
            }
            double diff = volume - sum;
            if (isTheSpaseEnought)
            {
                Console.WriteLine($"{Math.Abs(diff)} Cubic meters left.");
            }
            else
            {
                Console.WriteLine($"No more free space! You need {Math.Abs(diff)} Cubic meters more.");
            }

        }
    }
}