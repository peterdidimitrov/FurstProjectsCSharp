using System;

namespace _04._Vacation_Books_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pagesNum = int.Parse(Console.ReadLine());
            int pageForOneHour = int.Parse(Console.ReadLine());
            int dayNum = int.Parse(Console.ReadLine());
            
            int sum = (pagesNum / pageForOneHour) / dayNum;
            
            Console.WriteLine(sum);
        }
    }
}
