﻿using System.Reflection;

namespace AuthorProblem
{
    public class Tracker
    {
        public Tracker()
        {
        }

        public void PrintMethodsByAuthor()
        {
            Type type = typeof(StartUp);
            foreach (var method in type.GetMethods((BindingFlags)60))
            {
                AuthorAttribute[] attributes = method.GetCustomAttributes<AuthorAttribute>().ToArray();
                foreach (var attribute in attributes)
                {
                    Console.WriteLine($"{method.Name} is written by {attribute.Name}");
                }
            }
        }
    }
}