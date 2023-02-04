namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> carList = new();
            List<Engine> engineList = new();

            int n = int.Parse(Console.ReadLine());

            var engine = new Engine();

            for (int i = 0; i < n; i++)
            {
                string[] engineInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (engineInfo.Length == 4)
                {
                    engine = new Engine(engineInfo[0], int.Parse(engineInfo[1]), int.Parse(engineInfo[2]), engineInfo[3]);
                    engineList.Add(engine);
                }
                else if (engineInfo.Length == 2)
                {
                    engine = new Engine(engineInfo[0], int.Parse(engineInfo[1]));
                    engineList.Add(engine);
                }
                else if (engineInfo.Length == 3)
                {
                    int displacement;
                    if (int.TryParse(engineInfo[2], out displacement))
                    {
                        engine = new Engine(engineInfo[0], int.Parse(engineInfo[1]), displacement);
                        engineList.Add(engine);
                    }
                    else
                    {
                        engine = new Engine(engineInfo[0], int.Parse(engineInfo[1]), engineInfo[2]);
                        engineList.Add(engine);
                    }
                }
            }
            int m = int.Parse(Console.ReadLine());

            for (int j = 0; j < m; j++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                //"{model} {engine} {weight} {color}"

                engine = engineList.Find(x => x.Model == carInfo[1]);

                if (carInfo.Length == 4)
                {
                    Car car = new Car(carInfo[0], engine, int.Parse(carInfo[2]), carInfo[3]);
                    carList.Add(car);
                }
                else if (carInfo.Length == 2)
                {
                    Car car = new Car(carInfo[0], engine);
                    carList.Add(car);
                }
                else if (carInfo.Length == 3)
                {
                    int displacement;
                    if (int.TryParse(carInfo[2], out displacement))
                    {
                        Car car = new Car(carInfo[0], engine, displacement);
                        carList.Add(car);
                    }
                    else
                    {
                        Car car = new Car(carInfo[0], engine, carInfo[2]);
                        carList.Add(car);
                    }
                }
            }

            //foreach (var car in carList)
            //{
            //    if (engine.Efficiency == null)
            //    {
            //        Console.WriteLine($"{engine.Model} {engine.Power} {engine.Displacement} n/a");
            //    }
            //    else if (engine.Displacement == 0)
            //    {
            //        Console.WriteLine($"{engine.Model} {engine.Power} n/a {engine.Efficiency}");
            //    }
            //    else if (engine.Efficiency == null && engine.Displacement == 0)
            //    {
            //        Console.WriteLine($"{engine.Model} {engine.Power} n/a n/a");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"{engine.Model} {engine.Power} {engine.Displacement} {engine.Efficiency}");
            //    }
            //}
            foreach (var car in carList)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}