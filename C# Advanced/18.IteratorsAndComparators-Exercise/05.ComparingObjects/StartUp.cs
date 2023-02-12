using ComparingObjects;

namespace 
    ComparingObjects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] personProps = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Person person = new()
                {
                    Name = personProps[0],
                    Age = int.Parse(personProps[1]),
                    Town = personProps[2]
                };

                people.Add(person);
            }
        }
    }
}