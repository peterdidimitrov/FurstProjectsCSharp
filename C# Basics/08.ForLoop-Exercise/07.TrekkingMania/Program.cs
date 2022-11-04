using System;

namespace _07.TrekkingMania
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numGrupes = int.Parse(Console.ReadLine());
            double climbersMusala = 0;
            double climbersMonblan = 0;
            double climbersKilimanjaro = 0;
            double climbersK2 = 0;
            double climbersEverest = 0;
            double totalPeople = 0;
            for (int i = 0; i < numGrupes; i++)
            {
                int numPeopleInGrupes = int.Parse(Console.ReadLine());
                if (numPeopleInGrupes <= 5)
                {
                    climbersMusala += numPeopleInGrupes;
                    totalPeople += numPeopleInGrupes;
                }
                else if (numPeopleInGrupes >= 6 && numPeopleInGrupes <= 12)
                {
                    climbersMonblan += numPeopleInGrupes;
                    totalPeople += numPeopleInGrupes;
                }
                else if (numPeopleInGrupes >= 13 && numPeopleInGrupes <= 25)
                {
                    climbersKilimanjaro += numPeopleInGrupes;
                    totalPeople += numPeopleInGrupes;
                }
                else if (numPeopleInGrupes >= 26 && numPeopleInGrupes <= 40)
                {
                    climbersK2 += numPeopleInGrupes;
                    totalPeople += numPeopleInGrupes;
                }
                else if (numPeopleInGrupes >= 41)
                {
                    climbersEverest += numPeopleInGrupes;
                    totalPeople += numPeopleInGrupes;
                }
            }
            double persMusala = climbersMusala / totalPeople * 100;
            double persMonblan = climbersMonblan / totalPeople * 100;
            double persKilimanjaro = climbersKilimanjaro / totalPeople * 100;
            double persK2 = climbersK2 / totalPeople * 100;
            double persEverest = climbersEverest / totalPeople * 100;

            Console.WriteLine($"{persMusala:f2}%");
            Console.WriteLine($"{persMonblan:f2}%");
            Console.WriteLine($"{persKilimanjaro:f2}%");
            Console.WriteLine($"{persK2:f2}%");
            Console.WriteLine($"{persEverest:f2}%");
        }
    }
}
