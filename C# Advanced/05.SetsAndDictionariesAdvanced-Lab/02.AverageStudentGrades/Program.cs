namespace _02.AverageStudentGrades
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            int studentCount = int.Parse(Console.ReadLine());



            var students = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < studentCount; i++)
            {
                string[] input = Console.ReadLine().Split();

                string name = input[0];
                decimal grade = decimal.Parse(input[1]);

                if (!students.ContainsKey(name))
                {
                    students.Add(name, new List<decimal>());
                    students[name].Add(grade);
                }
                else
                {
                    students[name].Add(grade);
                }
            }

            foreach (var student in students)
            {
                Console.WriteLine($"{student.Key} -> {string.Join(" ", student.Value.Select(s => s.ToString("F2")))} (avg: {student.Value.Average():f2})");
            }
        }
    }
}