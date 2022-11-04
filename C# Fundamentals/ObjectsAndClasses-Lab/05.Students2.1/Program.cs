using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Students2._1
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

                string firstName = personInfo[0];
                string lastName = personInfo[1];
                int age = int.Parse(personInfo[2]);
                string town = personInfo[3];

                Student student = students
                        .FirstOrDefault(x => x.FirstName == firstName
                        && x.LastName == lastName);

                if (student != null)
                {
                    student.Town = town;
                    student.Age = age;
                }
                else
                {
                    student = new Student(firstName,
                        lastName,
                        age,
                        town);
                    students.Add(student);
                }
            }
            string desiredTown = Console.ReadLine();

            foreach (Student student in students
                .Where(x => x.Town == desiredTown))
            {

                Console.WriteLine($"{student.FirstName} " +
                    $"{student.LastName} is {student.Age} years old.");
            }
        }
    }

    public class Student
    {
        public Student(string firstName, string lastName, int age, string town)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Town = town;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }
    }
}