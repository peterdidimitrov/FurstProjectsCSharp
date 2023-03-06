using FoodShortage.Core.Interfaces;
using FoodShortage.IO.Interfaces;
using FoodShortage.Models;
using FoodShortage.Models.Interfaces;
using FoodShortage.Models.Interfaces;

namespace FoodShortage.Core;
public class Engine : IEngine
{
    private IReader reader;
    private IWriter writer;

    public Engine(IReader reader, IWriter writer)
    {
        this.reader = reader;
        this.writer = writer;
    }

    public void Run()
    {
        List<IBuyer> buyers = new();

        int buyersCount = int.Parse(reader.ReadLine());

        for (int i = 0; i < buyersCount; i++)
        {
            string[] buyerInfo = reader.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (buyerInfo.Length == 4)
            {
                IBuyer citizen = new Citizen(buyerInfo[0], int.Parse(buyerInfo[1]), buyerInfo[2], buyerInfo[3]);
                buyers.Add(citizen);
            }
            else if (buyerInfo.Length == 3)
            {
                IBuyer rebel = new Rebel(buyerInfo[0], int.Parse(buyerInfo[1]), buyerInfo[2]);
                buyers.Add(rebel);
            }
        }

        string nameOfBuyer;
        
        while ((nameOfBuyer = reader.ReadLine()) != "End")
        {
            buyers.FirstOrDefault(b => b.Name == nameOfBuyer)?.Buy();
        }

        writer.WriteLine(buyers.Sum(b => b.Food).ToString());
    }

    private static List<string> FindeAllBirthdates(List<IBorn> born, string year)
    {

        List<string> biologicalOrganisms = new();

        foreach (var entity in born)
        {

            string date = entity.Date;

            if (date.EndsWith(year))
            {
                biologicalOrganisms.Add(date);
            }
        }

        return biologicalOrganisms;
    }
}