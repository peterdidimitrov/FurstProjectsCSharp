using System;

namespace МЕ01._SoftUni_Reception
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfStudentPer1hour1 = int.Parse(Console.ReadLine());
            int numOfStudentPer1hour2 = int.Parse(Console.ReadLine());
            int numOfStudentPer1hour3 = int.Parse(Console.ReadLine());
            int studenCount = int.Parse(Console.ReadLine());

            int houerCount = 0;
            int maxStudenForHouer = numOfStudentPer1hour1 + numOfStudentPer1hour2 + numOfStudentPer1hour3;


            if (studenCount % maxStudenForHouer == 0)
            {
                houerCount = studenCount / maxStudenForHouer;
            }
            else if (studenCount % maxStudenForHouer != 0)
            {
                houerCount = studenCount / maxStudenForHouer + 1;
            }

            if (houerCount > 3 && houerCount % 3 == 0)
            {
                houerCount += houerCount / 3 - 1;
            }
            else if (houerCount > 3)
            {
                houerCount += houerCount / 3;
            }

            Console.WriteLine($"Time needed: {houerCount}h.");
        }
    }

}