using System;

namespace _05.Salary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numTabs = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());
            bool isYouLostTheSalary = false;
            for (int i = 0; i < numTabs; i++)
            {
                string site = Console.ReadLine();
                switch (site)
                {
                    case "Facebook":
                        salary -= 150;
                        break;
                    case "Instagram":
                        salary -= 100;
                        break;
                    case "Reddit":
                        salary -= 50;
                        break;
                }
                if (salary <= 0)
                {
                    isYouLostTheSalary = true;
                    Console.WriteLine("You have lost your salary.");
                    break;
                }
            }
            if (!isYouLostTheSalary)
            {
                Console.WriteLine(salary);
            }
        }
    }
}
