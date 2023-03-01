namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                string commands;

                while ((commands = Console.ReadLine().ToLower()) != "end")
                {
                    string[] commandArguments = commands
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string doughType = commandArguments[1];
                    string bakingTechnique = commandArguments[2];
                    double weight = double.Parse(commandArguments[3]);

                    Dough dough = new Dough(doughType, bakingTechnique, weight);
                    Console.WriteLine(dough.GetCalories());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}