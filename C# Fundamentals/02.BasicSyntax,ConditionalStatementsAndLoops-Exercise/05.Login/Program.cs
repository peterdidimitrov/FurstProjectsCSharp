using System;
using System.Linq;

namespace _05.Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userName = Console.ReadLine();

            for (int attempts = 0; attempts < 4; attempts++)
            {
                string input = Console.ReadLine();
                string pass = String.Join("", userName.Reverse());
                
                if (input == pass)
                {
                    Console.WriteLine($"User {userName} logged in.");
                    break;
                }
                else
                {
                    if (attempts == 3)
                    {
                        Console.WriteLine($"User {userName} blocked!");
                    }
                    else
                    {
                        Console.WriteLine("Incorrect password. Try again.");
                    }
                }

            }

        }
    }
}
