using BorderControl.Core.Interfaces;
using BorderControl.IO.Interfaces;
using BorderControl.Models;
using BorderControl.Models.Interfaces;

namespace BorderControl.Core;
public class EngineWithEndsWith : IEngine
{
    private IReader reader;
    private IWriter writer;

    public EngineWithEndsWith(IReader reader, IWriter writer)
    {
        this.reader = reader;
        this.writer = writer;
    }

    public void Run()
    {
        List<IPassers> passers = new();

        string info;
        while ((info = reader.ReadLine()) != "End")
        {
            string[] passarsInfo = info
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (passarsInfo.Length == 3)
            {
                IPassers citizen = new Citizen(passarsInfo[0], int.Parse(passarsInfo[1]), passarsInfo[2]);
                passers.Add(citizen);
            }
            else if (passarsInfo.Length == 2)
            {
                IPassers robot = new Robot(passarsInfo[0], passarsInfo[1]);
                passers.Add(robot);
            }
        }

        string lastDigitsOfFakeIds = reader.ReadLine();

        writer.WriteLine(String.Join(Environment.NewLine, FindeFakeIds(passers, lastDigitsOfFakeIds)));
    }

    private static List<string> FindeFakeIds(List<IPassers> passers, string lastDigitsOfFakeIds)
    {

        List<string> fakeIds = new();

        foreach (var passer in passers)
        {
            string id = passer.Id;
            
            if (id.EndsWith(lastDigitsOfFakeIds))
            {
                fakeIds.Add(passer.Id);
            }
        }
        return fakeIds;
    }
}