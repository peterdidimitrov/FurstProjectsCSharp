using WildFarm.Core.Interfaces;
using WildFarm.Factories.Interfaces;
using WildFarm.IO.Interfaces;
using WildFarm.Models.Animals;
using WildFarm.Models.Interfaces;

namespace WildFarm.Core;

public class Engine : IEngine
{
    private readonly IReader reader;
    private readonly IWriter writer;
    private readonly IAnimalFactory animalFactory;
    private readonly IFoodFactory foodFactory;

    private readonly ICollection<IAnimal> animals;

    public Engine(IReader reader, IWriter writer, IAnimalFactory animalFactory, IFoodFactory foodFactory)
    {
        this.reader = reader;
        this.writer = writer;
        this.animalFactory = animalFactory;
        this.foodFactory = foodFactory;

        animals = new List<IAnimal>();
    }

    public void Run()
    {
        string commands;
        while ((commands = reader.ReadLine()) != "End")
        {
            try
            {
                string[] commandArguments = commands
                    .Split();
                animals.Add(animalFactory.Create(commandArguments));
                writer.WriteLine(animals.Last().ProducingSound());
            }
            catch (Exception ex)
            {
                writer.WriteLine(ex.Message);
            }
            string[] vegetableArg = reader.ReadLine()
                .Split();

            try
            {
                animals.Last().Eat(foodFactory.Create(vegetableArg[0], int.Parse(vegetableArg[1])));
            }
            catch (Exception ex)
            {
                writer.WriteLine(ex.Message);
            }
        }

        foreach (var animal in animals)
        {
            writer.WriteLine(animal.ToString());
        }
    }
}