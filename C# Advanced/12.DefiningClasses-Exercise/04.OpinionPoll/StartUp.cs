namespace DefiningClasses;

public class StartUp
{
    static void Main(string[] args)
    {
        int count = int.Parse(Console.ReadLine());

        var listOfPeople = new List<Person>();

        for (int i = 0; i < count; i++)
        {
            string[] personProperties = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Person person = new(personProperties[0], int.Parse(personProperties[1]));

            listOfPeople.Add(person);
        }

        var sortedListOfPeople = listOfPeople.Where(p => p.Age > 30).OrderBy(p => p.Name);

        foreach (var person in sortedListOfPeople)
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }
    }
}