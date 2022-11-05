
using System;

namespace _01.BonusScoringSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int studentNum = int.Parse(Console.ReadLine());
            int lecturesNum = int.Parse(Console.ReadLine());
            int additionalBonus = int.Parse(Console.ReadLine());


            double totalBonus = 0;
            int theHightestBonus = 0;
            int hightestAttend = 0;

            for (int i = 0; i < studentNum; i++)
            {
                int attendanceOfStudent = int.Parse(Console.ReadLine());
                totalBonus = Math.Ceiling((double)attendanceOfStudent / lecturesNum * (5 + additionalBonus));
                if (theHightestBonus <= totalBonus)
                {
                    theHightestBonus = (int)totalBonus;
                    hightestAttend = attendanceOfStudent;
                }
            }
            Console.WriteLine($"Max Bonus: {theHightestBonus}.");
            Console.WriteLine($"The student has attended {hightestAttend} lectures.");

        }
    }
}
