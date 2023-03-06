using BirthdayCelebrations.Core.Interfaces;
using BirthdayCelebrations.IO.Interfaces;
using BirthdayCelebrations.Models;
using BirthdayCelebrations.Models.ICallable;
using BirthdayCelebrations.Models.Interfaces;

namespace BirthdayCelebrations.Core;
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
        List<IBorn> born = new();
        List<IPassers> passers = new();

        string info;
        while ((info = reader.ReadLine()) != "End")
        {
            string[] bornInfo = info
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            
            string type = bornInfo[0];

            if (type == "Citizen")
            {
                IBorn citizen = new Citizen(bornInfo[1], int.Parse(bornInfo[2]), bornInfo[3], bornInfo[4]);
                born.Add(citizen);
            }
            else if (type == "Robot")
            {
                IPassers robot = new Robot(bornInfo[0], bornInfo[1]);
                passers.Add(robot);
            }
            else if (type == "Pet")
            {
                IBorn pet = new Pet(bornInfo[1], bornInfo[2]);
                born.Add(pet);
            }
        }

        string year = reader.ReadLine();

        writer.WriteLine(String.Join(Environment.NewLine, FindeAllBirthdates(born, year)));
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