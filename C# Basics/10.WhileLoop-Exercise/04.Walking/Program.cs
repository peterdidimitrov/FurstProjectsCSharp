using System;

namespace _04.Walking
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int totalSteps = 0;

            while (command != "Going home")
            {
                int steps = int.Parse(command);
                totalSteps += steps;
                if (totalSteps >= 10000)
                {
                    break;
                }
                command = Console.ReadLine();
            }
            if (command == "Going home")
            {
                int stepsToHome = int.Parse(Console.ReadLine());
                totalSteps += stepsToHome;
            }

            double diff = totalSteps - 10000;

            if (totalSteps >= 10000)
            {
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{diff} steps over the goal!");
            }
            else
            {
                Console.WriteLine($"{Math.Abs(diff)} more steps to reach goal.");
            }
        }
    }
}