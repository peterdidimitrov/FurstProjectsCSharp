using System;

namespace _08.TennisRanklist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double numTurnaments = double.Parse(Console.ReadLine());
            double numStartPoints = int.Parse(Console.ReadLine());
            double totalPoints = numStartPoints;
            int numWinTourn = 0;
            for (int i = 0; i < numTurnaments; i++)
            {
                string stage = Console.ReadLine();
                switch (stage)
                {
                    case "W":
                        totalPoints += 2000;
                        numWinTourn++;
                        break;
                    case "F":
                        totalPoints += 1200;
                        break;
                    case "SF":
                        totalPoints += 720;
                        break;
                }
            }
            double avg = Math.Floor((totalPoints - numStartPoints) / numTurnaments);
            double persWinTourn = numWinTourn / numTurnaments * 100;
            Console.WriteLine($"Final points: {totalPoints}");
            Console.WriteLine($"Average points: {avg}");
            Console.WriteLine($"{persWinTourn:f2}%");
        }
    }
}
