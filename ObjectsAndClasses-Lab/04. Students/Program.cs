using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            List<Student> students = new List<Student>();
            while ((input = Console.ReadLine()) != "end")
            {
                string[] personInfo = input
                    .Split();

                string furstName = personInfo[0];
                string lastName = personInfo[1];
                int age = int.Parse(personInfo[2]);
                string town = personInfo[3];

                Student student = new Student(furstName, lastName, age, town);

                students.Add(student);
            }
            string desiredTown = Console.ReadLine();

            foreach (Student student in students)
            {
                if (student.Town == desiredTown)
                {
                    Console.WriteLine($"{student.FurstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }
    }
    public class Student
    {
        public Student(string furstName, string lastName, int age, string town)
        {
            FurstName = furstName;
            LastName = lastName;
            Age = age;
            Town = town;
        }
        public string FurstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }
    }
}
