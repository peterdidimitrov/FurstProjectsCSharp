using System;

namespace _01.StudentInformation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string studentName = Console.ReadLine();
            int ages = int.Parse(Console.ReadLine());
            double grade = double.Parse(Console.ReadLine());

            Console.WriteLine($"Name: {studentName}, Age: {ages}, Grade: {grade:f2}");
        }
    }
}
