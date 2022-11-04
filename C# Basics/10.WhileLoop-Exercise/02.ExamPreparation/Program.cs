using System;

namespace _02.ExamPreparation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int negativeGrade = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();
            int grade = int.Parse(Console.ReadLine());

            string taskName = "";
            double sum = 0.0;
            int countNegGrade = 0;
            int countTasks = 0;
            bool isTimeForBreak = false;

            while (command != "Enough")
            {
                countTasks++;

                if (grade <= 4)
                {
                    countNegGrade++;
                    if (countNegGrade == negativeGrade)
                    {
                        isTimeForBreak = true;
                        Console.WriteLine($"You need a break, {countNegGrade} poor grades.");
                        break;
                    }
                }
                sum += grade;
                taskName = command;
                command = Console.ReadLine();
                if (command != "Enough")
                {
                    grade = int.Parse(Console.ReadLine());
                }

            }
            if (!isTimeForBreak)
            {
                double avg = sum / countTasks;
                Console.WriteLine($"Average score: {avg:f2}");
                Console.WriteLine($"Number of problems: {countTasks}");
                Console.WriteLine($"Last problem: {taskName}");
            }

        }
    }
}