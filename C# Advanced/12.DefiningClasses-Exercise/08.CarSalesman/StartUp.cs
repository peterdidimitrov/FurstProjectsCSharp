namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> carList = new();
            List<Engine> engineList = new();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] engineInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (engineInfo.Length == 4)
                {
                    Engine engine = new Engine(engineInfo[0], int.Parse(engineInfo[1]), int.Parse(engineInfo[2]), engineInfo[3]);
                    engineList.Add(engine);
                }
                else if (engineInfo.Length == 2)
                {
                    Engine engine = new Engine(engineInfo[0], int.Parse(engineInfo[1]));
                    engineList.Add(engine);
                }
                else if (engineInfo.Length == 3)
                {
                    int displacement;
                    if (int.TryParse(engineInfo[2], out displacement))
                    {
                        Engine engine = new Engine(engineInfo[0], int.Parse(engineInfo[1]), displacement);
                        engineList.Add(engine);
                    }
                    else
                    {
                        Engine engine = new Engine(engineInfo[0], int.Parse(engineInfo[1]), engineInfo[2]);
                        engineList.Add(engine);
                    }
                }
            }
            foreach (var engine in engineList)
            {
                if (engine.Efficiency == null)
                {
                    Console.WriteLine($"{engine.Model} {engine.Power} {engine.Displacement} n/a");
                }
                else if (engine.Displacement == 0)
                {
                    Console.WriteLine($"{engine.Model} {engine.Power} n/a {engine.Efficiency}");
                }
                else if (engine.Efficiency == null && engine.Displacement == 0)
                {
                    Console.WriteLine($"{engine.Model} {engine.Power} n/a n/a");
                }
                else
                {
                    Console.WriteLine($"{engine.Model} {engine.Power} {engine.Displacement} {engine.Efficiency}");
                }
            }
        }
    }
}