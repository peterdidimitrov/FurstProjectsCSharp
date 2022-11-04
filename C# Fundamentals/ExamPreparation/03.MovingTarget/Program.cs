using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MovingTarget
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] comArg = command.Split();

                string action = comArg[0];
                int index = int.Parse(comArg[1]);

                if (action == "Shoot")
                {
                    int power = int.Parse(comArg[2]);
                    ShootTheTarget(index, power, targets);
                }
                else if (action == "Add")
                {
                    int value = int.Parse(comArg[2]);
                    AddingTheTarget(index, value, targets);
                }
                else if (action == "Strike")
                {
                    int radius = int.Parse(comArg[2]);
                    StrikingTheTarget(index, radius, targets);
                }
            }
            Console.WriteLine(string.Join("|", targets));
        }

        static void ShootTheTarget(int index, int power, List<int> targets)
        {
            if (index <= targets.Count - 1 && index >= 0)
            {
                int currentTarget = targets[index];
                currentTarget -= power;
                if (currentTarget <= 0)
                {
                    targets.RemoveAt(index);
                }
                else
                {
                    targets.Insert(index, currentTarget);
                    targets.RemoveAt(index + 1);
                }
            }

        }
        static void AddingTheTarget(int index, int value, List<int> targets)
        {
            if (index <= targets.Count - 1 && index >= 0)
            {
                targets.Insert(index, value);
            }
            else
            {   
                Console.WriteLine("Invalid placement!");
            }
        }
        static void StrikingTheTarget(int index, int radius, List<int> targets)
        {
            if (index + radius <= targets.Count - 1 && index - radius >= 0)
            {
                targets.RemoveRange(index - radius, radius * 2 + 1);
            }
            else
            {
                Console.WriteLine("Strike missed!");
            }
        }
    }
}