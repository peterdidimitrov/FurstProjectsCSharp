﻿using System;

namespace _08.Graduation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int grades = 1;
            double sum = 0;
            int excluded = 0;
            bool isExcluded = false;
            while (grades <= 12)
            {
                double grade = double.Parse(Console.ReadLine());
                if (grade < 4.00)
                {
                    excluded++;
                    if (excluded > 1)
                    {
                        Console.WriteLine($"{name} has been excluded at {grades - 1} grade");
                        isExcluded = true;
                        break;
                    }
                }
                grades++;
                sum += grade;
            }
            double average = sum / 12;
            if (!isExcluded)
            {
                Console.WriteLine($"{name} graduated. Average grade: {average:f2}");
            }

        }
    }
}