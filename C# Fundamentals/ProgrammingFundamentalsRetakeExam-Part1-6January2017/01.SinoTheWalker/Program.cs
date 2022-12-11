using System;
using System.Globalization;

class SinoTheWalker
{
    static void Main()
    {
        string leavingTime = Console.ReadLine();
        int steps = int.Parse(Console.ReadLine()) % 86400;
        int secPerStep = int.Parse(Console.ReadLine()) % 86400;

        long seconds = steps * secPerStep;

        DateTime dt = DateTime.ParseExact(leavingTime, "HH:mm:ss", CultureInfo.InvariantCulture);

        string result = dt.AddSeconds(seconds).ToString("HH:mm:ss");

        Console.WriteLine("Time Arrival: {0}", result);
    }
}