using System;
using System.Linq;
using System.Collections.Generic;

namespace _07.CompanyUsers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var companies = new Dictionary<string, List<string>>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] strings = input
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string companyName = strings[0];
                string employeeId = strings[1];

                if (!companies.ContainsKey(companyName))
                {
                    companies.Add(companyName, new List<string>());
                    companies[companyName].Add(employeeId);
                }
                else
                {
                    if (companies[companyName].Contains(employeeId))
                    {
                        continue;
                    }
                    else
                    {
                        companies[companyName].Add(employeeId);
                    }
                }
            }
            foreach (var item in companies)
            {
                Console.WriteLine($"{item.Key}");
                foreach (var employee in item.Value)
                {
                    Console.WriteLine($"-- {employee}");
                }
            }
        }
    }
}
