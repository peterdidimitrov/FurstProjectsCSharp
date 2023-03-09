namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine()
                .Split();
            string[] truckInfo = Console.ReadLine()
                .Split();

            Car car = new(double.Parse(carInfo[1]), double.Parse(carInfo[2]));
            Truck truck = new(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine()
                .Split();
                if (commands[0] == "Drive")
                {
                    if (commands[1] == "Car")
                    {
                        Console.WriteLine(car.Drive(double.Parse(commands[2])));
                    }
                    else if (commands[1] == "Truck")
                    {

                        Console.WriteLine(truck.Drive(double.Parse(commands[2])));
                    }
                }
                else if (commands[0] == "Refuel")
                {
                    if (commands[1] == "Car")
                    {
                        car.Refuel(double.Parse(commands[2]));
                    }
                    else if (commands[1] == "Truck")
                    {
                        truck.Refuel(double.Parse(commands[2]));
                    }
                }
            }
            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
        }
    }
}