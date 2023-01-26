namespace _05.FilterByAge
{
    class FilterByAge
    {
        static void Main(string[] args)
        {
            Func<Person, int, bool> youngerFunc = (person, givenAge) => person.Age < givenAge;
            Func<Person, int, bool> olderFunc = (person, givenAge) => person.Age >= givenAge;

            int n = int.Parse(Console.ReadLine());
            List<Person> allPersons = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] cmdArr = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string name = cmdArr[0];
                int age = int.Parse(cmdArr[1]);

                allPersons.Add(new Person(name, age));
            }

            string condition = Console.ReadLine();
            int ageFilter = int.Parse(Console.ReadLine());
            string[] printFilter = Console.ReadLine()
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            switch (condition)
            {
                case "younger":
                    allPersons = allPersons.Where(p => youngerFunc(p, ageFilter)).ToList();
                    break;
                case "older":
                    allPersons = allPersons.Where(p => olderFunc(p, ageFilter)).ToList();
                    break;
            }

            foreach (var person in allPersons)
            {
                List<string> output = new List<string>();
                if (printFilter.Contains("name"))
                {
                    output.Add(person.Name);
                }

                if (printFilter.Contains("age"))
                {
                    output.Add(person.Age.ToString());
                }

                Console.WriteLine(string.Join(" - ", output));
            }
        }
    }

    internal class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }
}