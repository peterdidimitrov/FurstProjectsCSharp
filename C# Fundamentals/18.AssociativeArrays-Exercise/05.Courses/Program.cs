using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var courses = new Dictionary<string, List<string>>();

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] data = input.Split(" : ");
                string courseName = data[0];
                string studentName = data[1];

                if (!courses.ContainsKey(courseName))
                {
                    courses.Add(courseName, new List<string>());
                    courses[courseName].Add(studentName);
                }
                else
                {
                    courses[courseName].Add(studentName);
                }
            }
            foreach (var item in courses)
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count}");
                foreach (var name in item.Value)
                {
                    Console.WriteLine($"-- {name}");
                }
            }
        }
    }
}
