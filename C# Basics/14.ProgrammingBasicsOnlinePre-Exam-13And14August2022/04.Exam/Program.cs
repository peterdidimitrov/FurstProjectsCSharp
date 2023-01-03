using System;

namespace _04.Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numStudents = int.Parse(Console.ReadLine());
            int topGrade = 0;
            int goodGrade = 0;
            int badGrade = 0;
            int fail = 0;
            double sumGrade = 0;

            for (int i = 1; i <= numStudents; i++)    
            {
                double grade = double.Parse(Console.ReadLine());
                sumGrade += grade;
                if (grade >= 5.00)
                {
                    topGrade++;
                }
                else if (grade < 5.00 && grade >= 4.00)
                {
                    goodGrade++;
                }
                else if (grade < 4.00 && grade >= 3.00)
                {
                   badGrade++;
                }
                else if (grade < 3.00)
                {
                    fail++;
                }
            }
            double diffTopGrade = (double)topGrade / numStudents * 100;
            double diffGoodGrade = (double)goodGrade / numStudents * 100;
            double diffBadGrade = (double)badGrade / numStudents * 100;
            double diffFail = (double)fail / numStudents * 100;
            double diff = sumGrade / numStudents;

            Console.WriteLine($"Top students: {diffTopGrade:f2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {diffGoodGrade:f2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {diffBadGrade:f2}%");
            Console.WriteLine($"Fail: {diffFail:f2}%");
            Console.WriteLine($"Average: {diff:f2}");
        }
    }
}
