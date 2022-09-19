using System;

namespace _08.OnTimeForTheExam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hoursExam = int.Parse(Console.ReadLine());
            int minsExam = int.Parse(Console.ReadLine());
            int hoursArrive = int.Parse(Console.ReadLine());
            int minArrive = int.Parse(Console.ReadLine());

            int timeExam = hoursExam * 60 + minsExam;
            int timeArrive = hoursArrive * 60 + minArrive;

            double diff = Math.Abs(timeArrive - timeExam);
            double h = Math.Floor(diff / 60);
            double m = diff % 60;


            if (timeExam < timeArrive)
            {
                Console.WriteLine("Late");
                if (diff >= 60)
                {
                    if (m < 10)
                    {
                        Console.WriteLine($"{h}:0{m} hours after the start");
                    }
                    else
                    {
                        Console.WriteLine($"{h}:{m} hours after the start");
                    }
                }
                else
                {
                    Console.WriteLine($"{m} minutes after the start");
                }
            }
            else if (timeArrive == timeExam || timeExam - timeArrive <= 30)
            {
                Console.WriteLine("On time");
                if (diff > 0)
                {
                    Console.WriteLine($"{m} minutes before the start");
                }
            }
            else
            {
                Console.WriteLine("Early");
                if (h > 0)
                {
                    if (m < 10)
                    {
                        Console.WriteLine($"{h}:0{m} hours before the start");
                    }
                    else
                    {
                        Console.WriteLine($"{h}:{m} hours before the start");
                    }
                }
                else
                {
                    Console.WriteLine($"{m} minutes before the start");
                }
            }

        }
    }
}
