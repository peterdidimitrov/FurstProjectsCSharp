using System;

namespace _07._Projects_Creation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int numProjects = int.Parse(Console.ReadLine());
            int totalhours = numProjects * 3;
            
            Console.WriteLine($"The architect {name} will need {totalhours} hours to complete {numProjects} project/s.");
        }
    }
}
