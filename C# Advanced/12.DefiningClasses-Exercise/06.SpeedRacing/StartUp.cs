namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> list = new();
            
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = carInfo[0];
                double fuelAmount = double.Parse(carInfo[1]);
                double fuelConsumption = double.Parse(carInfo[2]);

                Car car = new Car(model, fuelAmount, fuelConsumption, 0);

                list.Add(car);
            }
            string commands = string.Empty;
            while ((commands = Console.ReadLine()) != "End")
            {
                string[] commArg = commands
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string currCommand = commArg[0];
                string carModel = commArg[1];
                double amountOfKm = double.Parse(commArg[2]);

                foreach (var item in list)
                {
                    double usedFuel = item.FuelConsumptionPerKilometer* amountOfKm;
                    if (item.Model == carModel)
                    {
                        item.Moving(item, usedFuel, amountOfKm);
                    }
                }
            }
            
            foreach (var vehicle in list)
            {
                Console.WriteLine($"{vehicle.Model} {vehicle.FuelAmount:f2} {vehicle.TravelledDistance}");
            }

        }
    }
}