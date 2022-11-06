using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.StudentAcademy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var students = new Dictionary<string, List<double>>();

            int countOfInputs = int.Parse(Console.ReadLine());
            for (int i = 0; i < countOfInputs; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!students.ContainsKey(name))
                {
                    students.Add(name, new List<double>());
                    students[name].Add(grade);
                }
                else
                {
                    students[name].Add(grade);
                }
            }
            foreach (var item in students)
            {
                double sumGrade = 0;
                double avgGrade = 0;
                foreach (var grade in item.Value)
                {
                    sumGrade += grade;
                }
                avgGrade += sumGrade / item.Value.Count;
                if (avgGrade >= 4.50)
                {
                    Console.WriteLine($"{item.Key} -> {avgGrade:f2}");
                }
            }
        }
    }
}
