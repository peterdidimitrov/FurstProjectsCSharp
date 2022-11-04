using System;

namespace _06.Cake
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int lenth = int.Parse(Console.ReadLine());
            int area = width * lenth;
            string command = Console.ReadLine();
            while (command != "STOP")
            {
                int piecesNum = int.Parse(command);
                area -= piecesNum;
                if (area <= 0)
                {
                    break;
                }
                command = Console.ReadLine();
            }
            if (command == "STOP")
            {
                Console.WriteLine($"{area} pieces are left.");
            }

            if (area < 0)
            {
                Console.WriteLine($"No more cake left! You need {Math.Abs(area)} pieces more.");
            }
        }
    }
}